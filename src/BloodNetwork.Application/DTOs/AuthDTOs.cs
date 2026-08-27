using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.DTOs;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Password,
    string? Email = null,
    UserRole Role = UserRole.Requester
);

public record LoginRequest(
    string PhoneNumber,
    string Password
);

public record RefreshTokenRequest(
    string RefreshToken
);

public record AuthResponse(
    string AccessToken,
    string RefreshToken,
    UserDto User
);

public record UserDto(
    Guid Id,
    string FirstName,
    string LastName,
    string PhoneNumber,
    string? Email,
    UserRole Role,
    bool IsPhoneVerified,
    bool MustChangePassword,
    DateTime CreatedAt
);

public record FirstLoginChangeRequest(
    string NewEmail,
    string NewPassword,
    string CurrentPassword
);

public record UpdateProfileRequest(
    string CurrentPassword,
    string? NewEmail = null,
    string? NewPhoneNumber = null,
    string? NewPassword = null
);
