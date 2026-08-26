using BloodNetwork.Application.Common;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;

namespace BloodNetwork.Application.Services;

public class AuthService
{
    private readonly IRepository<User> _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthService(
        IRepository<User> userRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher,
        IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var existingPhone = await _userRepository.AnyAsync(
            u => u.PhoneNumber == request.PhoneNumber, cancellationToken);

        if (existingPhone)
            return Result<AuthResponse>.Failure("A user with this phone number already exists");

        if (!string.IsNullOrEmpty(request.Email))
        {
            var existingEmail = await _userRepository.AnyAsync(
                u => u.Email == request.Email, cancellationToken);

            if (existingEmail)
                return Result<AuthResponse>.Failure("A user with this email already exists");
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

        var dto = MapToDto(user);
        var accessToken = _jwtTokenService.GenerateAccessToken(user.Id, user.PhoneNumber, user.Role);
        var refreshToken = _jwtTokenService.GenerateRefreshToken();

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
        var refreshToken = _jwtTokenService.GenerateRefreshToken();

        return Result<AuthResponse>.Success(new AuthResponse(accessToken, refreshToken, dto));
    }

    public async Task<Result<UserDto>> GetCurrentUserAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);

        if (user is null)
            return Result<UserDto>.Failure("User not found");

        return Result<UserDto>.Success(MapToDto(user));
    }

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
            user.CreatedAt
        );
    }
}
