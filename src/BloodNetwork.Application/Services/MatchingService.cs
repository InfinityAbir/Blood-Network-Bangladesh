using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
    private readonly MatchScoreWeightsOptions _weights;
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
        IOptions<MatchScoreWeightsOptions> weights,
        ILogger<MatchingService> logger)
    {
        _requestRepo = requestRepo;
        _matchRepo = matchRepo;
        _donorProfileRepo = donorProfileRepo;
        _userRepo = userRepo;
        _unitOfWork = unitOfWork;
        _mapService = mapService;
        _notificationService = notificationService;
        _weights = weights.Value;
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

        var existingMatches = await _matchRepo.FindAsync(m => m.BloodRequestId == requestId);
        var existingDonorIds = existingMatches.Select(m => m.DonorId).ToHashSet();

        var allProfiles = await _donorProfileRepo.GetAllAsync();
        var allUsers = await _userRepo.GetAllAsync();
        var userLookup = allUsers.ToDictionary(u => u.Id);

        var candidates = allProfiles
            .Where(p =>
                !existingDonorIds.Contains(p.UserId) &&
                IsCompatible(p.BloodGroup, request.BloodGroup) &&
                p.AvailabilityStatus == AvailabilityStatus.Available &&
                p.VerificationStatus != VerificationStatus.Rejected &&
                userLookup.TryGetValue(p.UserId, out var user) &&
                user.IsActive)
            .ToList();

        _logger.LogInformation("Found {Count} candidate donors for request {RequestId}", candidates.Count, requestId);

        var matches = new List<BloodRequestMatch>();
        foreach (var profile in candidates)
        {
            var score = CalculateScore(profile, request);
            if (score < 10) continue;

            var distance = CalculateDistance(profile, request);

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

            foreach (var match in matches)
            {
                await _notificationService.SendNotificationAsync(
                    match.DonorId,
                    "New Blood Request Match",
                    $"{requesterName} needs {request.BloodGroup} blood at {request.HospitalName}. You scored {match.MatchScore}/100 match.",
                    NotificationType.BloodRequestMatch,
                    request.Id);
            }
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

        if (response == DonorResponse.Accepted)
        {
            match.AcceptedAt = DateTime.UtcNow;
        }
        else if (response == DonorResponse.Declined)
        {
            match.DeclinedAt = DateTime.UtcNow;
        }

        await _unitOfWork.SaveChangesAsync();

        var donorUser = await _userRepo.GetByIdAsync(userId);
        var donorName = donorUser is not null ? $"{donorUser.FirstName} {donorUser.LastName}" : "A donor";
        var request = await _requestRepo.GetByIdAsync(match.BloodRequestId);
        var responseType = response == DonorResponse.Accepted ? "accepted" : "declined";
        var notifType = response == DonorResponse.Accepted ? NotificationType.DonorAccepted : NotificationType.DonorDeclined;

        if (request != null)
        {
            await _notificationService.SendNotificationAsync(
                request.RequesterId,
                $"Donor {responseType}",
                $"{donorName} has {responseType} your blood request at {request.HospitalName}.",
                notifType,
                match.BloodRequestId);
        }

        return match;
    }

    private bool IsCompatible(BloodGroup donorGroup, BloodGroup requestedGroup)
    {
        if (!BloodCompatibility.TryGetValue(requestedGroup, out var compatibleGroups))
            return false;

        return compatibleGroups.Contains(donorGroup);
    }

    private int CalculateScore(DonorProfile profile, BloodRequest request)
    {
        int score = 0;

        if (profile.BloodGroup == request.BloodGroup)
            score += _weights.ExactBloodGroup;
        else if (IsCompatible(profile.BloodGroup, request.BloodGroup))
            score += _weights.CompatibleBloodGroup;

        score += profile.AvailabilityStatus switch
        {
            AvailabilityStatus.Available => _weights.Available,
            AvailabilityStatus.Unknown => _weights.Unknown,
            _ => 0
        };

        score += profile.VerificationStatus switch
        {
            VerificationStatus.Verified => _weights.Verified,
            VerificationStatus.Pending => _weights.Pending,
            VerificationStatus.Unverified => _weights.Unverified,
            VerificationStatus.Rejected => 0,
            _ => 0
        };

        if (profile.LastDonationDate.HasValue)
        {
            var daysSinceLastDonation = (DateTime.UtcNow - profile.LastDonationDate.Value).Days;
            if (daysSinceLastDonation <= 90)
                score += _weights.ProfileFreshness;
        }
        else
        {
            score += _weights.ProfileFreshness;
        }

        var distance = CalculateDistance(profile, request);
        if (distance.HasValue)
        {
            score += distance.Value switch
            {
                <= 3 => _weights.Distance0to3km,
                <= 10 => _weights.Distance3to10km,
                <= 25 => _weights.Distance10to25km,
                _ => _weights.DistanceOver25km
            };
        }

        return score;
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
