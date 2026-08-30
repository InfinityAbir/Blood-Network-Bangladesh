using BloodNetwork.Application.Configuration;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BloodNetwork.Application.Services;

public class DonorEngagementService : IDonorEngagementService
{
    private readonly IRepository<DonorProfile> _donorProfileRepo;
    private readonly IRepository<User> _userRepo;
    private readonly ILogger<DonorEngagementService> _logger;
    private readonly AppSettings _appSettings;

    public DonorEngagementService(
        IRepository<DonorProfile> donorProfileRepo,
        IRepository<User> userRepo,
        ILogger<DonorEngagementService> logger,
        IOptions<AppSettings> appSettings)
    {
        _donorProfileRepo = donorProfileRepo;
        _userRepo = userRepo;
        _logger = logger;
        _appSettings = appSettings.Value;
    }

    public async Task<IReadOnlyList<DonorEngagementDto>> GetTopEngagedDonorsAsync(BloodGroup bloodGroup, int count = 10)
    {
        var profiles = await _donorProfileRepo.FindAsync(p => p.BloodGroup == bloodGroup);
        var userIds = profiles.Select(p => p.UserId).ToList();
        var users = await _userRepo.FindAsync(u => userIds.Contains(u.Id) && u.IsActive);
        var userLookup = users.ToDictionary(u => u.Id);

        var results = new List<DonorEngagementDto>();
        foreach (var profile in profiles)
        {
            if (!userLookup.ContainsKey(profile.UserId)) continue;

            var user = userLookup[profile.UserId];
            var score = CalculateEngagementScore(profile);

            results.Add(new DonorEngagementDto
            {
                DonorId = profile.UserId,
                DonorName = $"{user.FirstName} {user.LastName}",
                BloodGroup = profile.BloodGroup,
                EngagementScore = score,
                TotalDonations = profile.TotalDonationCount,
                LastDonationDate = profile.LastDonationDate,
                Status = profile.AvailabilityStatus,
                Verification = profile.VerificationStatus,
                EngagementTier = GetTier(score)
            });
        }

        return results
            .OrderByDescending(d => d.EngagementScore)
            .Take(count)
            .ToList();
    }

    public async Task<DonorEngagementDto?> GetDonorEngagementAsync(Guid donorId)
    {
        var profile = await _donorProfileRepo.FirstOrDefaultAsync(p => p.UserId == donorId);
        if (profile == null)
        {
            _logger.LogWarning("Donor profile not found for userId {DonorId}", donorId);
            return null;
        }

        var user = await _userRepo.GetByIdAsync(donorId);
        if (user == null) return null;

        var score = CalculateEngagementScore(profile);

        return new DonorEngagementDto
        {
            DonorId = profile.UserId,
            DonorName = $"{user.FirstName} {user.LastName}",
            BloodGroup = profile.BloodGroup,
            EngagementScore = score,
            TotalDonations = profile.TotalDonationCount,
            LastDonationDate = profile.LastDonationDate,
            Status = profile.AvailabilityStatus,
            Verification = profile.VerificationStatus,
            EngagementTier = GetTier(score)
        };
    }

    public async Task<int> GetReEngagementScoreAsync(Guid donorId)
    {
        var profile = await _donorProfileRepo.FirstOrDefaultAsync(p => p.UserId == donorId);
        if (profile == null)
        {
            _logger.LogWarning("Donor profile not found for userId {DonorId}", donorId);
            return 0;
        }

        return CalculateEngagementScore(profile);
    }

    public int CalculateEngagementScore(DonorProfile profile)
    {
        int score = 0;

        // Recency Factor (35 points) — threshold from MinimumDonationIntervalDays
        if (profile.LastDonationDate.HasValue)
        {
            var daysSinceLastDonation = (DateTime.UtcNow - profile.LastDonationDate.Value).Days;
            var interval = _appSettings.MinimumDonationIntervalDays;
            score += daysSinceLastDonation switch
            {
                var d when d <= interval => 35,
                var d when d <= interval * 2 => 25,
                var d when d <= 365 => 15,
                _ => 5
            };
        }
        else
        {
            score += 30;
        }

        // History Factor (25 points)
        score += profile.TotalDonationCount switch
        {
            >= 10 => 25,
            >= 7 => 20,
            >= 4 => 15,
            >= 1 => 10,
            _ => 5
        };

        // Availability Factor (20 points)
        score += profile.AvailabilityStatus switch
        {
            AvailabilityStatus.Available => 20,
            AvailabilityStatus.Unknown => 10,
            AvailabilityStatus.RecentlyDonated => 12,
            AvailabilityStatus.Unavailable => 3,
            _ => 0
        };

        // Verification Factor (10 points)
        score += profile.VerificationStatus switch
        {
            VerificationStatus.Verified => 10,
            VerificationStatus.Pending => 5,
            _ => 0
        };

        // Profile Freshness Factor (10 points) — threshold from DonorProfileConfirmationDays
        if (profile.LastProfileConfirmedAt.HasValue)
        {
            var daysSinceConfirmation = (DateTime.UtcNow - profile.LastProfileConfirmedAt.Value).Days;
            var confirm = _appSettings.DonorProfileConfirmationDays;
            score += daysSinceConfirmation switch
            {
                var d when d <= 30 => 10,
                var d when d <= confirm => 7,
                var d when d <= confirm * 2 => 4,
                _ => 1
            };
        }
        else
        {
            score += 0;
        }

        return score;
    }

    private static string GetTier(int score)
    {
        return score switch
        {
            >= 70 => "High",
            >= 40 => "Medium",
            _ => "Low"
        };
    }
}
