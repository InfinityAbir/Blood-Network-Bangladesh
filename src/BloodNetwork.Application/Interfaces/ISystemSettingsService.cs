using BloodNetwork.Application.Configuration;
using BloodNetwork.Application.DTOs;

namespace BloodNetwork.Application.Interfaces;

public interface ISystemSettingsService
{
    Task<SystemSettingsDto> GetAsync();
    Task<SystemSettingsDto> UpdateAsync(UpdateSystemSettingsRequest request);
    // Helpers for services that need typed options without DTO mapping
    Task<AppSettings> GetAppSettingsAsync();
    Task<MatchScoreWeightsOptions> GetMatchWeightsAsync();
}
