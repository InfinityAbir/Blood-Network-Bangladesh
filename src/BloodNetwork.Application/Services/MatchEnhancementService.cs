using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BloodNetwork.Application.Services;

public class MatchEnhancementService : IMatchEnhancementService
{
    private readonly IRepository<DonorProfile> _donorProfileRepo;
    private readonly IRepository<User> _userRepo;
    private readonly IRepository<BloodRequest> _requestRepo;
    private readonly IMapService _mapService;
    private readonly ILogger<MatchEnhancementService> _logger;

    public MatchEnhancementService(
        IRepository<DonorProfile> donorProfileRepo,
        IRepository<User> userRepo,
        IRepository<BloodRequest> requestRepo,
        IMapService mapService,
        ILogger<MatchEnhancementService> logger)
    {
        _donorProfileRepo = donorProfileRepo;
        _userRepo = userRepo;
        _requestRepo = requestRepo;
        _mapService = mapService;
        _logger = logger;
    }

    public async Task<IReadOnlyList<EnhancedMatchDto>> GetEnhancedMatchesAsync(
        Guid requestId, IReadOnlyList<BloodRequestMatch> rawMatches)
    {
        var request = await _requestRepo.GetByIdAsync(requestId);
        if (request == null)
        {
            _logger.LogWarning("Blood request {RequestId} not found for enhancement", requestId);
            return Array.Empty<EnhancedMatchDto>();
        }

        var donorIds = rawMatches.Select(m => m.DonorId).Distinct().ToList();
        var donors = await _donorProfileRepo.FindAsync(d => donorIds.Contains(d.UserId));
        var donorLookup = donors.ToDictionary(d => d.UserId);

        var users = await _userRepo.FindAsync(u => donorIds.Contains(u.Id));
        var userLookup = users.ToDictionary(u => u.Id);

        var results = new List<EnhancedMatchDto>();

        foreach (var match in rawMatches)
        {
            if (!donorLookup.TryGetValue(match.DonorId, out var profile)) continue;

            userLookup.TryGetValue(match.DonorId, out var user);
            var donorName = user != null ? $"{user.FirstName} {user.LastName}" : "Unknown Donor";

            var acceptanceProb = CalculateAcceptanceProbability(profile, request);
            var combinedScore = CalculateCombinedScore(match.MatchScore, acceptanceProb);

            results.Add(new EnhancedMatchDto
            {
                MatchId = match.Id,
                DonorId = match.DonorId,
                DonorName = donorName,
                OriginalScore = match.MatchScore,
                AcceptanceProbability = acceptanceProb,
                CombinedScore = combinedScore,
                Priority = GetPriority(combinedScore)
            });
        }

        return results.OrderByDescending(r => r.CombinedScore).ToList();
    }

    public async Task<EnhancedMatchDto> EnhanceSingleMatchAsync(
        BloodRequestMatch match, double? requestLat, double? requestLon)
    {
        var profile = await _donorProfileRepo.FirstOrDefaultAsync(d => d.UserId == match.DonorId);
        var user = await _userRepo.GetByIdAsync(match.DonorId);

        var donorName = user != null ? $"{user.FirstName} {user.LastName}" : "Unknown Donor";

        int acceptanceProb;
        if (requestLat.HasValue && requestLon.HasValue && profile != null)
        {
            acceptanceProb = CalculateAcceptanceProbabilityWithLocation(profile, requestLat.Value, requestLon.Value, false);
        }
        else if (profile != null)
        {
            acceptanceProb = CalculateAcceptanceProbabilityWithLocation(profile, null, null, false);
        }
        else
        {
            acceptanceProb = 0;
        }

        var combinedScore = CalculateCombinedScore(match.MatchScore, acceptanceProb);

        return new EnhancedMatchDto
        {
            MatchId = match.Id,
            DonorId = match.DonorId,
            DonorName = donorName,
            OriginalScore = match.MatchScore,
            AcceptanceProbability = acceptanceProb,
            CombinedScore = combinedScore,
            Priority = GetPriority(combinedScore)
        };
    }

    private int CalculateAcceptanceProbability(DonorProfile profile, BloodRequest request)
    {
        var isEmergency = request.Urgency == Urgency.Critical || request.Urgency == Urgency.Urgent;
        return CalculateAcceptanceProbabilityWithLocation(profile, request.Latitude, request.Longitude, isEmergency);
    }

    private int CalculateAcceptanceProbabilityWithLocation(
        DonorProfile profile, double? requestLat, double? requestLon, bool isEmergency)
    {
        int score = 0;

        // Availability bonus (30)
        score += profile.AvailabilityStatus switch
        {
            AvailabilityStatus.Available => 30,
            AvailabilityStatus.RecentlyDonated => 20,
            AvailabilityStatus.Unknown => 10,
            AvailabilityStatus.Unavailable => 0,
            _ => 0
        };

        // Distance bonus (20)
        if (requestLat.HasValue && requestLon.HasValue &&
            profile.Latitude.HasValue && profile.Longitude.HasValue)
        {
            var distance = _mapService.CalculateDistanceKm(
                profile.Latitude.Value, profile.Longitude.Value,
                requestLat.Value, requestLon.Value);

            score += distance switch
            {
                <= 3 => 20,
                <= 10 => 15,
                <= 25 => 10,
                _ => 5
            };
        }
        else
        {
            score += 10;
        }

        // Verification bonus (15)
        score += profile.VerificationStatus switch
        {
            VerificationStatus.Verified => 15,
            VerificationStatus.Pending => 7,
            _ => 0
        };

        // Recency bonus (15)
        if (profile.LastDonationDate.HasValue)
        {
            var daysSinceLastDonation = (DateTime.UtcNow - profile.LastDonationDate.Value).Days;
            score += daysSinceLastDonation switch
            {
                <= 90 => 15,
                <= 180 => 10,
                <= 365 => 5,
                _ => 2
            };
        }
        else
        {
            score += 15;
        }

        // Availability status match (10) - donor Available AND request is emergency
        if (isEmergency && profile.AvailabilityStatus == AvailabilityStatus.Available)
        {
            score += 10;
        }

        // History bonus (10)
        score += profile.TotalDonationCount switch
        {
            >= 5 => 10,
            >= 2 => 7,
            >= 1 => 4,
            _ => 2
        };

        return score;
    }

    private static int CalculateCombinedScore(int originalScore, int acceptanceProbability)
    {
        return (int)Math.Round(originalScore * 0.5 + acceptanceProbability * 0.5);
    }

    private static string GetPriority(int combinedScore)
    {
        return combinedScore switch
        {
            >= 75 => "Highest",
            >= 60 => "High",
            >= 40 => "Medium",
            _ => "Low"
        };
    }
}
