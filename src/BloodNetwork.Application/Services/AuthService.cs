using System.Security.Cryptography;
using System.Text;
using BloodNetwork.Application.Common;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BloodNetwork.Application.Services;

public class AuthService
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<RefreshToken> _refreshTokenRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly INotificationService _notificationService;
    private readonly ILogger<AuthService> _logger;

    public AuthService(
        IRepository<User> userRepository,
        IRepository<RefreshToken> refreshTokenRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        IJwtTokenService jwtTokenService,
        INotificationService notificationService,
        ILogger<AuthService> logger)
    {
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _jwtTokenService = jwtTokenService;
        _notificationService = notificationService;
        _logger = logger;
    }

    public async Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var existingPhone = await _userRepository.AnyAsync(
            u => u.PhoneNumber == request.PhoneNumber, cancellationToken);

        if (existingPhone)
        {
            // Auto-cleanup: if account is unverified and older than 24h, delete it
            var staleUser = await _userRepository.FirstOrDefaultAsync(
                u => u.PhoneNumber == request.PhoneNumber && !u.IsPhoneVerified, cancellationToken);
            if (staleUser != null && staleUser.CreatedAt < DateTime.UtcNow.AddHours(-24))
            {
                await _userRepository.DeleteAsync(staleUser);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                existingPhone = false;
            }
        }

        if (existingPhone)
            return Result<AuthResponse>.Failure("A user with this phone number already exists");

        if (!string.IsNullOrEmpty(request.Email))
        {
            var existingEmail = await _userRepository.AnyAsync(
                u => u.Email == request.Email, cancellationToken);

            if (existingEmail)
            {
                var staleEmailUser = await _userRepository.FirstOrDefaultAsync(
                    u => u.Email == request.Email && !u.IsPhoneVerified, cancellationToken);
                if (staleEmailUser != null && staleEmailUser.CreatedAt < DateTime.UtcNow.AddHours(-24))
                {
                    await _userRepository.DeleteAsync(staleEmailUser);
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                    existingEmail = false;
                }
            }
        }

        // Only Admin is forbidden for public registration; Volunteer/Donor/Requester are allowed (G7)
        if (request.Role == UserRole.Admin)
        {
            return Result<AuthResponse>.Failure("Invalid role assignment.");
        }

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            PhoneNumber = request.PhoneNumber,
            Email = request.Email,
            PasswordHash = _passwordHasher.HashPassword(request.Password),
            Role = request.Role,
            IsActive = true,
            IsPhoneVerified = false
        };

        await _userRepository.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        try
        {
            await _notificationService.SendNotificationAsync(
                user.Id,
                "Welcome to Blood Network Bangladesh!",
                $"Hi {user.FirstName}, welcome to Blood Network Bangladesh! Complete your donor profile to start saving lives, or create a blood request to find donors.",
                NotificationType.System,
                null);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to send welcome notification for user {UserId}", user.Id);
        }

        var dto = MapToDto(user);
        var accessToken = _jwtTokenService.GenerateAccessToken(user.Id, user.PhoneNumber, user.Role);
        var refreshToken = await CreateRefreshTokenAsync(user.Id, cancellationToken);

        return Result<AuthResponse>.Success(new AuthResponse(accessToken, refreshToken, dto));
    }

    public async Task<Result<AuthResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.FirstOrDefaultAsync(
            u => u.PhoneNumber == request.PhoneNumber, cancellationToken);

        if (user is null)
            return Result<AuthResponse>.Failure("Invalid phone number or password");

        if (!user.IsActive)
            return Result<AuthResponse>.Failure("Account has been deactivated. Contact support.");

        if (!_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
            return Result<AuthResponse>.Failure("Invalid phone number or password");

        user.LastLoginAt = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var dto = MapToDto(user);
        var accessToken = _jwtTokenService.GenerateAccessToken(user.Id, user.PhoneNumber, user.Role);
        var refreshToken = await CreateRefreshTokenAsync(user.Id, cancellationToken);

        return Result<AuthResponse>.Success(new AuthResponse(accessToken, refreshToken, dto));
    }

    public async Task<Result<AuthResponse>> RefreshTokenAsync(string refreshTokenValue, CancellationToken cancellationToken = default)
    {
        var tokenHash = HashToken(refreshTokenValue);
        var refreshToken = await _refreshTokenRepository.FirstOrDefaultAsync(
            t => t.Token == tokenHash, cancellationToken);

        if (refreshToken == null)
            return Result<AuthResponse>.Failure("Invalid refresh token");

        if (refreshToken.ExpiresAt < DateTime.UtcNow)
            return Result<AuthResponse>.Failure("Invalid or expired refresh token");

        // Detect refresh token reuse — if token is already revoked, it was stolen
        if (refreshToken.IsRevoked)
        {
            _logger.LogWarning("Refresh token reuse detected for user {UserId}. Revoking all tokens.", refreshToken.UserId);

            // Revoke ALL refresh tokens for this user
            var allUserTokens = (await _refreshTokenRepository.FindAsync(t => t.UserId == refreshToken.UserId && !t.IsRevoked, cancellationToken))
                .ToList();

            foreach (var token in allUserTokens)
            {
                token.IsRevoked = true;
                token.RevokedAt = DateTime.UtcNow;
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<AuthResponse>.Failure("Token reuse detected. Please log in again.");
        }

        var user = await _userRepository.GetByIdAsync(refreshToken.UserId, cancellationToken);
        if (user == null || !user.IsActive)
            return Result<AuthResponse>.Failure("User not found or inactive");

        // Revoke the old refresh token
        refreshToken.IsRevoked = true;
        refreshToken.RevokedAt = DateTime.UtcNow;

        // Create a new refresh token
        var newRefreshToken = await CreateRefreshTokenAsync(user.Id, cancellationToken);
        refreshToken.ReplacedByToken = HashToken(newRefreshToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var dto = MapToDto(user);
        var accessToken = _jwtTokenService.GenerateAccessToken(user.Id, user.PhoneNumber, user.Role);

        return Result<AuthResponse>.Success(new AuthResponse(accessToken, newRefreshToken, dto));
    }

    public async Task RevokeRefreshTokenAsync(string refreshTokenValue, CancellationToken cancellationToken = default)
    {
        var tokenHash = HashToken(refreshTokenValue);
        var refreshToken = await _refreshTokenRepository.FirstOrDefaultAsync(
            t => t.Token == tokenHash, cancellationToken);

        if (refreshToken != null)
        {
            refreshToken.IsRevoked = true;
            refreshToken.RevokedAt = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<Result<UserDto>> GetCurrentUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);

        if (user is null)
            return Result<UserDto>.Failure("User not found");

        return Result<UserDto>.Success(MapToDto(user));
    }

    public async Task<Result<UserDto>> ChangeFirstLoginCredentialsAsync(Guid userId, FirstLoginChangeRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user is null)
            return Result<UserDto>.Failure("User not found");

        if (!user.MustChangePassword)
            return Result<UserDto>.Failure("No credential change required");

        if (!_passwordHasher.VerifyPassword(request.CurrentPassword, user.PasswordHash))
            return Result<UserDto>.Failure("Current password is incorrect");

        if (string.IsNullOrWhiteSpace(request.NewEmail) || !request.NewEmail.Contains('@'))
            return Result<UserDto>.Failure("Valid email is required");

        var emailExists = await _userRepository.AnyAsync(u => u.Email == request.NewEmail && u.Id != userId, cancellationToken);
        if (emailExists)
            return Result<UserDto>.Failure("Email already in use");

        if (request.NewPassword.Length < 8 || !System.Text.RegularExpressions.Regex.IsMatch(request.NewPassword, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$"))
            return Result<UserDto>.Failure("Password must be at least 8 characters and include uppercase, lowercase and a number");

        user.Email = request.NewEmail;
        user.PasswordHash = _passwordHasher.HashPassword(request.NewPassword);
        user.MustChangePassword = false;

        // Revoke all existing refresh tokens on password change
        var existingTokens = (await _refreshTokenRepository.FindAsync(t => t.UserId == user.Id && !t.IsRevoked, cancellationToken))
            .ToList();

        foreach (var token in existingTokens)
        {
            token.IsRevoked = true;
            token.RevokedAt = DateTime.UtcNow;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<UserDto>.Success(MapToDto(user));
    }

    public async Task<Result<UserDto>> UpdateProfileAsync(Guid userId, UpdateProfileRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user is null)
            return Result<UserDto>.Failure("User not found");

        // A photo isn't a sensitive credential like email/phone/password, so changing only
        // the photo doesn't force a password re-entry — but any of those still does.
        var changingSensitiveField = !string.IsNullOrWhiteSpace(request.NewEmail)
            || !string.IsNullOrWhiteSpace(request.NewPhoneNumber)
            || !string.IsNullOrWhiteSpace(request.NewPassword);

        if (changingSensitiveField && !_passwordHasher.VerifyPassword(request.CurrentPassword, user.PasswordHash))
            return Result<UserDto>.Failure("Current password is incorrect");

        bool hasChange = false;

        if (request.NewPhotoUrl != null)
        {
            var trimmed = request.NewPhotoUrl.Trim();
            user.PhotoUrl = trimmed.Length == 0 ? null : trimmed;
            hasChange = true;
        }

        if (!string.IsNullOrWhiteSpace(request.NewEmail) && request.NewEmail != user.Email)
        {
            if (!request.NewEmail.Contains('@'))
                return Result<UserDto>.Failure("Valid email is required");
            var emailExists = await _userRepository.AnyAsync(u => u.Email == request.NewEmail && u.Id != userId, cancellationToken);
            if (emailExists)
                return Result<UserDto>.Failure("Email already in use");
            user.Email = request.NewEmail;
            hasChange = true;
        }

        if (!string.IsNullOrWhiteSpace(request.NewPhoneNumber) && request.NewPhoneNumber != user.PhoneNumber)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(request.NewPhoneNumber, @"^01[3-9]\d{8}$"))
                return Result<UserDto>.Failure("Invalid Bangladeshi phone number format (e.g., 01712345678)");
            var phoneExists = await _userRepository.AnyAsync(u => u.PhoneNumber == request.NewPhoneNumber && u.Id != userId, cancellationToken);
            if (phoneExists)
                return Result<UserDto>.Failure("Phone number already in use");
            user.PhoneNumber = request.NewPhoneNumber;
            hasChange = true;
        }

        if (!string.IsNullOrWhiteSpace(request.NewPassword))
        {
            if (request.NewPassword.Length < 8 || !System.Text.RegularExpressions.Regex.IsMatch(request.NewPassword, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$"))
                return Result<UserDto>.Failure("Password must be at least 8 characters and include uppercase, lowercase and a number");
            user.PasswordHash = _passwordHasher.HashPassword(request.NewPassword);
            user.MustChangePassword = false;
            hasChange = true;

            var existingTokens = (await _refreshTokenRepository.FindAsync(t => t.UserId == user.Id && !t.IsRevoked, cancellationToken)).ToList();
            foreach (var token in existingTokens)
            {
                token.IsRevoked = true;
                token.RevokedAt = DateTime.UtcNow;
            }
        }

        if (!hasChange)
            return Result<UserDto>.Failure("No changes provided");

        user.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<UserDto>.Success(MapToDto(user));
    }

    private async Task<string> CreateRefreshTokenAsync(Guid userId, CancellationToken cancellationToken)
    {
        var tokenValue = _jwtTokenService.GenerateRefreshToken();
        var refreshToken = new RefreshToken
        {
            UserId = userId,
            Token = HashToken(tokenValue),
            ExpiresAt = DateTime.UtcNow.AddDays(7),
            IsRevoked = false
        };

        await _refreshTokenRepository.AddAsync(refreshToken, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // Only the raw value is ever returned to the client - the database only ever sees its hash.
        return tokenValue;
    }

    // Refresh tokens are high-entropy opaque values (64 random bytes), so hashing here is
    // purely defense-in-depth against a database dump/backup leak, not brute-force protection.
    private static string HashToken(string token) =>
        Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(token)));

    private static UserDto MapToDto(User user)
    {
        return new UserDto(
            user.Id,
            user.FirstName,
            user.LastName,
            user.PhoneNumber,
            user.Email,
            user.Role,
            user.IsPhoneVerified,
            user.MustChangePassword,
            user.CreatedAt,
            user.PhotoUrl
        );
    }
}
