using BloodNetwork.Application.Configuration;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Interfaces;
using Microsoft.Extensions.Options;

namespace BloodNetwork.Application.Services;

public class SystemSettingsService : ISystemSettingsService
{
    private readonly IRepository<SystemSettings> _repo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly AppSettings _fallbackAppSettings;
    private readonly MatchScoreWeightsOptions _fallbackWeights;

    public SystemSettingsService(
        IRepository<SystemSettings> repo,
        IUnitOfWork unitOfWork,
        IOptions<AppSettings> appSettings,
        IOptions<MatchScoreWeightsOptions> weights)
    {
        _repo = repo;
        _unitOfWork = unitOfWork;
        _fallbackAppSettings = appSettings.Value;
        _fallbackWeights = weights.Value;
    }

    public async Task<SystemSettingsDto> GetAsync()
    {
        var entity = await GetOrCreateAsync();
        return ToDto(entity);
    }

    public async Task<SystemSettingsDto> UpdateAsync(UpdateSystemSettingsRequest request)
    {
        var entity = await GetOrCreateAsync();
        entity.MinimumDonationIntervalDays = request.MinimumDonationIntervalDays;
        entity.DonorProfileConfirmationDays = request.DonorProfileConfirmationDays;
        entity.MaxActiveRequestsPerUser = request.MaxActiveRequestsPerUser;
        entity.ContactCooldownHours = request.ContactCooldownHours;
        entity.ExactBloodGroupWeight = request.ExactBloodGroupWeight;
        entity.CompatibleBloodGroupWeight = request.CompatibleBloodGroupWeight;
        entity.AvailableWeight = request.AvailableWeight;
        entity.UnknownWeight = request.UnknownWeight;
        entity.VerifiedWeight = request.VerifiedWeight;
        entity.UnverifiedWeight = request.UnverifiedWeight;
        entity.ProfileFreshnessWeight = request.ProfileFreshnessWeight;
        entity.Distance0to3kmWeight = request.Distance0to3kmWeight;
        entity.Distance3to10kmWeight = request.Distance3to10kmWeight;
        entity.Distance10to25kmWeight = request.Distance10to25kmWeight;
        entity.DistanceOver25kmWeight = request.DistanceOver25kmWeight;
        entity.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync();
        return ToDto(entity);
    }

    public async Task<AppSettings> GetAppSettingsAsync()
    {
        var e = await GetOrCreateAsync();
        return new AppSettings
        {
            MinimumDonationIntervalDays = e.MinimumDonationIntervalDays,
            DonorProfileConfirmationDays = e.DonorProfileConfirmationDays,
            MaxActiveRequestsPerUser = e.MaxActiveRequestsPerUser,
            ContactCooldownHours = e.ContactCooldownHours
        };
    }

    public async Task<MatchScoreWeightsOptions> GetMatchWeightsAsync()
    {
        var e = await GetOrCreateAsync();
        return new MatchScoreWeightsOptions
        {
            ExactBloodGroup = e.ExactBloodGroupWeight,
            CompatibleBloodGroup = e.CompatibleBloodGroupWeight,
            Available = e.AvailableWeight,
            Unknown = e.UnknownWeight,
            Verified = e.VerifiedWeight,
            Unverified = e.UnverifiedWeight,
            ProfileFreshness = e.ProfileFreshnessWeight,
            Distance0to3km = e.Distance0to3kmWeight,
            Distance3to10km = e.Distance3to10kmWeight,
            Distance10to25km = e.Distance10to25kmWeight,
            DistanceOver25km = e.DistanceOver25kmWeight
        };
    }

    private async Task<SystemSettings> GetOrCreateAsync()
    {
        try
        {
            var existing = await _repo.FirstOrDefaultAsync(_ => true);
            if (existing != null) return existing;

            var created = new SystemSettings
            {
                MinimumDonationIntervalDays = _fallbackAppSettings.MinimumDonationIntervalDays,
                DonorProfileConfirmationDays = _fallbackAppSettings.DonorProfileConfirmationDays,
                MaxActiveRequestsPerUser = _fallbackAppSettings.MaxActiveRequestsPerUser,
                ContactCooldownHours = _fallbackAppSettings.ContactCooldownHours,
                ExactBloodGroupWeight = _fallbackWeights.ExactBloodGroup,
                CompatibleBloodGroupWeight = _fallbackWeights.CompatibleBloodGroup,
                AvailableWeight = _fallbackWeights.Available,
                UnknownWeight = _fallbackWeights.Unknown,
                VerifiedWeight = _fallbackWeights.Verified,
                UnverifiedWeight = _fallbackWeights.Unverified,
                ProfileFreshnessWeight = _fallbackWeights.ProfileFreshness,
                Distance0to3kmWeight = _fallbackWeights.Distance0to3km,
                Distance3to10kmWeight = _fallbackWeights.Distance3to10km,
                Distance10to25kmWeight = _fallbackWeights.Distance10to25km,
                DistanceOver25kmWeight = _fallbackWeights.DistanceOver25km
            };
            await _repo.AddAsync(created);
            await _unitOfWork.SaveChangesAsync();
            return created;
        }
        catch (Exception ex) when (ex.Message.Contains("SystemSettings", StringComparison.OrdinalIgnoreCase) || ex.Message.Contains("42P01"))
        {
            // Table not yet migrated (e.g., old DB before AddSystemSettings) - fallback to in-memory defaults
            return new SystemSettings
            {
                MinimumDonationIntervalDays = _fallbackAppSettings.MinimumDonationIntervalDays,
                DonorProfileConfirmationDays = _fallbackAppSettings.DonorProfileConfirmationDays,
                MaxActiveRequestsPerUser = _fallbackAppSettings.MaxActiveRequestsPerUser,
                ContactCooldownHours = _fallbackAppSettings.ContactCooldownHours,
                ExactBloodGroupWeight = _fallbackWeights.ExactBloodGroup,
                CompatibleBloodGroupWeight = _fallbackWeights.CompatibleBloodGroup,
                AvailableWeight = _fallbackWeights.Available,
                UnknownWeight = _fallbackWeights.Unknown,
                VerifiedWeight = _fallbackWeights.Verified,
                UnverifiedWeight = _fallbackWeights.Unverified,
                ProfileFreshnessWeight = _fallbackWeights.ProfileFreshness,
                Distance0to3kmWeight = _fallbackWeights.Distance0to3km,
                Distance3to10kmWeight = _fallbackWeights.Distance3to10km,
                Distance10to25kmWeight = _fallbackWeights.Distance10to25km,
                DistanceOver25kmWeight = _fallbackWeights.DistanceOver25km
            };
        }
    }

    private static SystemSettingsDto ToDto(SystemSettings e) => new()
    {
        MinimumDonationIntervalDays = e.MinimumDonationIntervalDays,
        DonorProfileConfirmationDays = e.DonorProfileConfirmationDays,
        MaxActiveRequestsPerUser = e.MaxActiveRequestsPerUser,
        ContactCooldownHours = e.ContactCooldownHours,
        ExactBloodGroupWeight = e.ExactBloodGroupWeight,
        CompatibleBloodGroupWeight = e.CompatibleBloodGroupWeight,
        AvailableWeight = e.AvailableWeight,
        UnknownWeight = e.UnknownWeight,
        VerifiedWeight = e.VerifiedWeight,
        UnverifiedWeight = e.UnverifiedWeight,
        ProfileFreshnessWeight = e.ProfileFreshnessWeight,
        Distance0to3kmWeight = e.Distance0to3kmWeight,
        Distance3to10kmWeight = e.Distance3to10kmWeight,
        Distance10to25kmWeight = e.Distance10to25kmWeight,
        DistanceOver25kmWeight = e.DistanceOver25kmWeight,
        UpdatedAt = e.UpdatedAt ?? e.CreatedAt
    };
}
