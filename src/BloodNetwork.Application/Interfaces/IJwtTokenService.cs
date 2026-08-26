using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateAccessToken(Guid userId, string phoneNumber, UserRole role);
    string GenerateRefreshToken();
    bool ValidateRefreshToken(string token);
}
