using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BloodNetwork.Application.Services;

public class DonorEngagementService : IDonorEngagementService
{
    private readonly IRepository<DonorProfile> _donorProfileRepo;
    private readonly IRepository<User> _userRepo;
    private readonly ILogger<DonorEngagementService> _logger;

    public DonorEngagementService(
        IRepository<DonorProfile> donorProfileRepo,
        IRepository<User> userRepo,
        ILogger<DonorEngagementService> logger)
    {
        _donorProfileRepo = donorProfileRepo;
        _userRepo = userRepo;
        _logger = logger;
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

        // Recency Factor (35 points)
        if (profile.LastDonationDate.HasValue)
        {
            var daysSinceLastDonation = (DateTime.UtcNow - profile.LastDonationDate.Value).Days;
            score += daysSinceLastDonation switch
            {
                <= 90 => 35,
                <= 180 => 25,
                <= 365 => 15,
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

        // Profile Freshness Factor (10 points)
        if (profile.LastProfileConfirmedAt.HasValue)
        {
            var daysSinceConfirmation = (DateTime.UtcNow - profile.LastProfileConfirmedAt.Value).Days;
            score += daysSinceConfirmation switch
            {
                <= 30 => 10,
                <= 90 => 7,
                <= 180 => 4,
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
