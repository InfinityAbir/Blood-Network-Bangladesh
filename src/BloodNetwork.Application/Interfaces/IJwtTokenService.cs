using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.Interfaces;

public interface IJwtTokenService
{
    /// <summary>Configured refresh-token lifetime, from Jwt:RefreshExpirationInDays.</summary>
    int RefreshTokenExpirationDays { get; }

    string GenerateAccessToken(Guid userId, string phoneNumber, UserRole role);
    string GenerateRefreshToken();
    bool ValidateRefreshToken(string token);
}
