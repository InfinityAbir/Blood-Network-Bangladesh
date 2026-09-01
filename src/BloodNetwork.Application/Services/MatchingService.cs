using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace BloodNetwork.Application.Services;

public class MatchingService : IMatchingService
{
    private readonly IRepository<BloodRequest> _requestRepo;
    private readonly IRepository<BloodRequestMatch> _matchRepo;
    private readonly IRepository<DonorProfile> _donorProfileRepo;
    private readonly IRepository<User> _userRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapService _mapService;
    private readonly INotificationService _notificationService;
    private readonly ISystemSettingsService _systemSettingsService;
    private readonly ILogger<MatchingService> _logger;

    private static readonly Dictionary<BloodGroup, BloodGroup[]> BloodCompatibility = new()
    {
        { BloodGroup.APositive, new[] { BloodGroup.APositive, BloodGroup.ANegative, BloodGroup.OPositive, BloodGroup.ONegative } },
        { BloodGroup.ANegative, new[] { BloodGroup.ANegative, BloodGroup.ONegative } },
        { BloodGroup.BPositive, new[] { BloodGroup.BPositive, BloodGroup.BNegative, BloodGroup.OPositive, BloodGroup.ONegative } },
        { BloodGroup.BNegative, new[] { BloodGroup.BNegative, BloodGroup.ONegative } },
        { BloodGroup.ABPositive, new[] { BloodGroup.ABPositive, BloodGroup.ABNegative, BloodGroup.APositive, BloodGroup.ANegative, BloodGroup.BPositive, BloodGroup.BNegative, BloodGroup.OPositive, BloodGroup.ONegative } },
        { BloodGroup.ABNegative, new[] { BloodGroup.ABNegative, BloodGroup.ANegative, BloodGroup.BNegative, BloodGroup.ONegative } },
        { BloodGroup.OPositive, new[] { BloodGroup.OPositive, BloodGroup.ONegative } },
        { BloodGroup.ONegative, new[] { BloodGroup.ONegative } }
    };

    public MatchingService(
        IRepository<BloodRequest> requestRepo,
        IRepository<BloodRequestMatch> matchRepo,
        IRepository<DonorProfile> donorProfileRepo,
        IRepository<User> userRepo,
        IUnitOfWork unitOfWork,
        IMapService mapService,
        INotificationService notificationService,
        ISystemSettingsService systemSettingsService,
        ILogger<MatchingService> logger)
    {
        _requestRepo = requestRepo;
        _matchRepo = matchRepo;
        _donorProfileRepo = donorProfileRepo;
        _userRepo = userRepo;
        _unitOfWork = unitOfWork;
        _mapService = mapService;
        _notificationService = notificationService;
        _systemSettingsService = systemSettingsService;
        _logger = logger;
    }

    public async Task<IReadOnlyList<BloodRequestMatch>> MatchRequestAsync(Guid requestId)
    {
        var request = await _requestRepo.GetByIdAsync(requestId);
        if (request == null)
        {
            _logger.LogWarning("Blood request {RequestId} not found for matching", requestId);
            return Array.Empty<BloodRequestMatch>();
        }

        var existingMatches = (await _matchRepo.FindAsync(m => m.BloodRequestId == requestId)) ?? Array.Empty<BloodRequestMatch>();
        var existingDonorIds = existingMatches.Select(m => m.DonorId).ToHashSet();

        var compatibleGroups = BloodCompatibility[request.BloodGroup];
        var candidates = (await _donorProfileRepo.FindAsync(p =>
            !existingDonorIds.Contains(p.UserId) &&
            compatibleGroups.Contains(p.BloodGroup) &&
            p.AvailabilityStatus == AvailabilityStatus.Available &&
            p.VerificationStatus != VerificationStatus.Rejected)) ?? Array.Empty<DonorProfile>();

        var candidateUserIds = candidates.Select(p => p.UserId).ToList();
        var activeUsers = (await _userRepo.FindAsync(u =>
            candidateUserIds.Contains(u.Id) && u.IsActive)) ?? Array.Empty<User>();
        var activeUserLookup = activeUsers.ToDictionary(u => u.Id);

        var filteredCandidates = candidates
            .Where(p => activeUserLookup.ContainsKey(p.UserId))
            .ToList();

        // Prioritize same district + verified donors, limit to avoid OOM at scale
        var prioritized = filteredCandidates
            .OrderByDescending(p => p.DistrictId == request.DistrictId ? 1 : 0)
            .ThenByDescending(p => p.VerificationStatus == VerificationStatus.Verified ? 1 : 0)
            .Take(100)
            .ToList();

        _logger.LogInformation("Found {Count} candidate donors for request {RequestId} (evaluating top {Eval})", filteredCandidates.Count, requestId, prioritized.Count);

        // Dynamic weights from admin-editable SystemSettings (fallback to appsettings.json)
        var weights = await _systemSettingsService.GetMatchWeightsAsync();
        var appSettings = await _systemSettingsService.GetAppSettingsAsync();

        var matches = new List<BloodRequestMatch>();
        foreach (var profile in prioritized)
        {
            var distance = CalculateDistance(profile, request);
            var score = CalculateScore(profile, request, distance, weights, appSettings);
            if (score < 10) continue;

            var match = new BloodRequestMatch
            {
                BloodRequestId = requestId,
                DonorId = profile.UserId,
                MatchScore = score,
                DistanceKm = distance,
                DonorResponse = DonorResponse.Pending
            };

            await _matchRepo.AddAsync(match);
            matches.Add(match);

            _logger.LogInformation(
                "Matched donor {DonorId} (score: {Score}, distance: {Distance}km) to request {RequestId}",
                profile.UserId, score, distance?.ToString("F1") ?? "unknown", requestId);
        }

        if (matches.Count > 0)
        {
            await _unitOfWork.SaveChangesAsync();

            var requestUser = await _userRepo.GetByIdAsync(request.RequesterId);
            var requesterName = requestUser is not null ? $"{requestUser.FirstName} {requestUser.LastName}" : "Someone";

            // Only page donors above a confidence threshold — a 15/100 match still gets a
            // BloodRequestMatch row (for the donor's own match list) but doesn't justify a push.
            const int notifyThreshold = 60;
            var notified = matches.Where(m => m.MatchScore > notifyThreshold).ToList();
            foreach (var match in notified)
            {
                try
                {
                    await _notificationService.SendNotificationAsync(
                        match.DonorId,
                        "New Blood Request Match",
                        $"{requesterName} needs {request.BloodGroup.ToLabel()} blood at {request.HospitalName}. You scored {match.MatchScore}/100 match.",
                        NotificationType.BloodRequestMatch,
                        request.Id);
                    match.ContactedAt = DateTime.UtcNow;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to send match notification to donor {DonorId}", match.DonorId);
                }
            }

            if (notified.Count > 0)
                await _unitOfWork.SaveChangesAsync();
        }

        return matches;
    }

    public async Task<IReadOnlyList<BloodRequestMatch>> GetMatchesForRequestAsync(Guid requestId)
    {
        var matches = await _matchRepo.FindAsync(m => m.BloodRequestId == requestId);
        return matches.OrderByDescending(m => m.MatchScore).ToList();
    }

    public async Task<IReadOnlyList<BloodRequestMatch>> GetMatchesForDonorAsync(Guid donorId)
    {
        var matches = await _matchRepo.FindAsync(m => m.DonorId == donorId);
        return matches.OrderByDescending(m => m.CreatedAt).ToList();
    }

    public async Task<BloodRequestMatch?> GetMatchByIdAsync(Guid matchId)
    {
        return await _matchRepo.GetByIdAsync(matchId);
    }

    public async Task<BloodRequestMatch?> RespondToMatchAsync(Guid matchId, Guid userId, DonorResponse response)
    {
        var match = await _matchRepo.GetByIdAsync(matchId);
        if (match == null || match.DonorId != userId)
            return null;

        match.DonorResponse = response;
        match.RespondedAt = DateTime.UtcNow;

        var request = await _requestRepo.GetByIdAsync(match.BloodRequestId);

        if (response == DonorResponse.Accepted)
        {
            match.AcceptedAt = DateTime.UtcNow;

            // Once a donor accepts an Urgent/Critical request they're committed to the donation,
            // so take them off the market — later matching passes shouldn't page them for another
            // request they can't help with. An accepted Normal request leaves availability
            // untouched: a donor who accepted one Normal request must stay matchable for a later
            // Urgent/Critical one (and the toggle stays theirs to flip manually).
            if (request is not null && (request.Urgency == Urgency.Critical || request.Urgency == Urgency.Urgent))
            {
                var profile = await _donorProfileRepo.FirstOrDefaultAsync(p => p.UserId == userId);
                if (profile is not null)
                {
                    profile.AvailabilityStatus = AvailabilityStatus.Unavailable;
                }
            }
        }
        else if (response == DonorResponse.Declined)
        {
            match.DeclinedAt = DateTime.UtcNow;
        }

        await _unitOfWork.SaveChangesAsync();

        var donorUser = await _userRepo.GetByIdAsync(userId);
        var donorName = donorUser is not null ? $"{donorUser.FirstName} {donorUser.LastName}" : "A donor";
        var responseType = response == DonorResponse.Accepted ? "accepted" : "declined";
        var notifType = response == DonorResponse.Accepted ? NotificationType.DonorAccepted : NotificationType.DonorDeclined;

        if (request != null)
        {
            try
            {
                await _notificationService.SendNotificationAsync(
                    request.RequesterId,
                    $"Donor {responseType}",
                    $"{donorName} has {responseType} your blood request at {request.HospitalName}.",
                    notifType,
                    match.BloodRequestId);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to send donor {Response} notification for request {RequestId}", responseType, match.BloodRequestId);
            }
        }

        return match;
    }

    private bool IsCompatible(BloodGroup donorGroup, BloodGroup requestedGroup)
    {
        if (!BloodCompatibility.TryGetValue(requestedGroup, out var compatibleGroups))
            return false;

        return compatibleGroups.Contains(donorGroup);
    }

    private int CalculateScore(DonorProfile profile, BloodRequest request, double? preCalculatedDistance, DTOs.MatchScoreWeightsOptions weights, Configuration.AppSettings appSettings)
    {
        int score = 0;

        if (profile.BloodGroup == request.BloodGroup)
            score += weights.ExactBloodGroup;
        else if (IsCompatible(profile.BloodGroup, request.BloodGroup))
            score += weights.CompatibleBloodGroup;

        score += profile.AvailabilityStatus switch
        {
            AvailabilityStatus.Available => weights.Available,
            AvailabilityStatus.Unknown => weights.Unknown,
            _ => 0
        };

        score += profile.VerificationStatus switch
        {
            VerificationStatus.Verified => weights.Verified,
            VerificationStatus.Unverified => weights.Unverified,
            VerificationStatus.Rejected => 0,
            _ => 0
        };

        if (profile.LastDonationDate.HasValue)
        {
            var daysSinceLastDonation = (DateTime.UtcNow - profile.LastDonationDate.Value).Days;
            if (daysSinceLastDonation <= appSettings.MinimumDonationIntervalDays)
                score += weights.ProfileFreshness;
        }
        else
        {
            score += weights.ProfileFreshness;
        }

        var distance = preCalculatedDistance ?? CalculateDistance(profile, request);
        if (distance.HasValue)
        {
            score += distance.Value switch
            {
                <= 3 => weights.Distance0to3km,
                <= 10 => weights.Distance3to10km,
                <= 25 => weights.Distance10to25km,
                _ => weights.DistanceOver25km
            };
        }

        return score;
    }

    // Backward compat for tests that call CalculateScore directly (if any)
    private int CalculateScore(DonorProfile profile, BloodRequest request, double? preCalculatedDistance = null)
    {
        // Fallback to defaults when called without dynamic weights (e.g., unit tests without DB)
        var weights = new DTOs.MatchScoreWeightsOptions();
        var appSettings = new Configuration.AppSettings();
        return CalculateScore(profile, request, preCalculatedDistance, weights, appSettings);
    }

    private double? CalculateDistance(DonorProfile profile, BloodRequest request)
    {
        if (!profile.Latitude.HasValue || !profile.Longitude.HasValue ||
            !request.Latitude.HasValue || !request.Longitude.HasValue)
            return null;

        return _mapService.CalculateDistanceKm(
            profile.Latitude.Value, profile.Longitude.Value,
            request.Latitude.Value, request.Longitude.Value);
    }
}
