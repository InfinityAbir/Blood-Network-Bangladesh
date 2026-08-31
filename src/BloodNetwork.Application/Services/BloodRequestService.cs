using BloodNetwork.Application.Common;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BloodNetwork.Application.Services;

public class BloodRequestService
{
    private readonly IRepository<BloodRequest> _requestRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<District> _districtRepository;
    private readonly IRepository<Upazila> _upazilaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMatchingService _matchingService;
    private readonly INotificationService _notificationService;
    private readonly IRepository<BloodRequestMatch> _matchRepository;
    private readonly IRepository<DonorProfile> _donorProfileRepository;
    private readonly IRepository<DonationRecord> _donationRecordRepository;
    private readonly ILogger<BloodRequestService> _logger;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ISystemSettingsService _systemSettingsService;

    public BloodRequestService(
        IRepository<BloodRequest> requestRepository,
        IRepository<User> userRepository,
        IRepository<District> districtRepository,
        IRepository<Upazila> upazilaRepository,
        IUnitOfWork unitOfWork,
        IMatchingService matchingService,
        INotificationService notificationService,
        IRepository<BloodRequestMatch> matchRepository,
        IRepository<DonorProfile> donorProfileRepository,
        IRepository<DonationRecord> donationRecordRepository,
        ILogger<BloodRequestService> logger,
        IServiceScopeFactory scopeFactory,
        ISystemSettingsService systemSettingsService)
    {
        _requestRepository = requestRepository;
        _userRepository = userRepository;
        _districtRepository = districtRepository;
        _upazilaRepository = upazilaRepository;
        _unitOfWork = unitOfWork;
        _matchingService = matchingService;
        _notificationService = notificationService;
        _matchRepository = matchRepository;
        _donorProfileRepository = donorProfileRepository;
        _donationRecordRepository = donationRecordRepository;
        _logger = logger;
        _scopeFactory = scopeFactory;
        _systemSettingsService = systemSettingsService;
    }

    public async Task<Result<BloodRequestDto>> CreateRequestAsync(Guid requesterId, CreateBloodRequestRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(requesterId, cancellationToken);
        if (user is null)
            return Result<BloodRequestDto>.Failure("User not found");

        var district = await _districtRepository.GetByIdAsync(request.DistrictId, cancellationToken);
        if (district is null)
            return Result<BloodRequestDto>.Failure("Invalid district");

        var upazila = await _upazilaRepository.GetByIdAsync(request.UpazilaId, cancellationToken);
        if (upazila is null)
            return Result<BloodRequestDto>.Failure("Invalid upazila");

        if (upazila.DistrictId != request.DistrictId)
            return Result<BloodRequestDto>.Failure("Upazila does not belong to district");

        // G6: enforce MaxActiveRequestsPerUser (dynamic)
        var appSettings = await _systemSettingsService.GetAppSettingsAsync();
        var activeCount = await _requestRepository.CountAsync(
            _requestRepository.Query().Where(r => r.RequesterId == requesterId && (r.Status == RequestStatus.Open || r.Status == RequestStatus.PartiallyFulfilled)),
            cancellationToken);
        if (activeCount >= appSettings.MaxActiveRequestsPerUser)
            return Result<BloodRequestDto>.Failure($"You have {activeCount} active requests. Maximum allowed is {appSettings.MaxActiveRequestsPerUser}.");

        // G6: enforce ContactCooldownHours (throttle request creation) - dynamic
        if (appSettings.ContactCooldownHours > 0)
        {
            var cooldownCutoff = DateTime.UtcNow.AddHours(-appSettings.ContactCooldownHours);
            var hasRecentRequest = await _requestRepository.AnyAsync(r => r.RequesterId == requesterId && r.CreatedAt >= cooldownCutoff, cancellationToken);
            if (hasRecentRequest)
                return Result<BloodRequestDto>.Failure($"Please wait {appSettings.ContactCooldownHours} hours between requests.");
        }

        var bloodRequest = new BloodRequest
        {
            RequesterId = requesterId,
            BloodGroup = request.BloodGroup,
            UnitsRequired = request.UnitsRequired,
            UnitsFulfilled = 0,
            HospitalName = request.HospitalName,
            HospitalAddress = request.HospitalAddress,
            DistrictId = request.DistrictId,
            UpazilaId = request.UpazilaId,
            Area = request.Area,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            RequiredBy = request.RequiredBy,
            Urgency = request.Urgency,
            PatientName = request.PatientName,
            PatientRelation = request.PatientRelation,
            ContactPhone = request.ContactPhone,
            AdditionalInformation = request.AdditionalInformation,
            Status = RequestStatus.Open
        };

        await _requestRepository.AddAsync(bloodRequest, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var capturedId = bloodRequest.Id;
        _ = Task.Run(async () =>
        {
            using var scope = _scopeFactory.CreateScope();
            var matching = scope.ServiceProvider.GetRequiredService<IMatchingService>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<BloodRequestService>>();
            try
            {
                await matching.MatchRequestAsync(capturedId);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Background matching failed for request {RequestId}", capturedId);
            }
        });

        try
        {
            await _notificationService.SendNotificationAsync(
                requesterId,
                "Blood Request Created",
                $"Your blood request for {request.BloodGroup.ToLabel()} blood ({request.UnitsRequired} units) at {request.HospitalName} has been posted. We are finding matching donors for you.",
                NotificationType.RequestUpdate,
                bloodRequest.Id);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to send request-created notification for {RequestId}", bloodRequest.Id);
        }

        var admins = await _userRepository.ToListAsync(
            _userRepository.Query().Where(u => u.Role == UserRole.Admin), cancellationToken);
        if (admins.Count > 0)
        {
            try
            {
                await _notificationService.SendBulkNotificationAsync(
                    admins.Select(a => a.Id),
                    "New Blood Request",
                    $"{user.FirstName} {user.LastName} requested {request.UnitsRequired} unit(s) of {request.BloodGroup.ToLabel()} blood at {request.HospitalName}.",
                    NotificationType.NewRequestPendingReview,
                    bloodRequest.Id);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to send admin notification for new request {RequestId}", bloodRequest.Id);
            }
        }

        return Result<BloodRequestDto>.Success(MapToDto(bloodRequest, user, district, upazila));
    }

    public async Task<Result<BloodRequestDto>> GetRequestByIdAsync(Guid requestId, CancellationToken cancellationToken = default)
    {
        var request = await _requestRepository.GetByIdAsync(requestId, cancellationToken);
        if (request is null)
            return Result<BloodRequestDto>.Failure("Blood request not found");

        var user = await _userRepository.GetByIdAsync(request.RequesterId, cancellationToken);
        var district = await _districtRepository.GetByIdAsync(request.DistrictId, cancellationToken);
        var upazila = await _upazilaRepository.GetByIdAsync(request.UpazilaId, cancellationToken);

        return Result<BloodRequestDto>.Success(MapToDto(request, user, district, upazila));
    }

    public async Task<Result<PagedResult<BloodRequestDto>>> GetMyRequestsAsync(Guid requesterId, RequestStatus? status, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        var query = _requestRepository.Query()
            .Where(r => r.RequesterId == requesterId);

        if (status.HasValue)
            query = query.Where(r => r.Status == status.Value);

        var totalCount = await _requestRepository.CountAsync(query);

        var items = await _requestRepository.ToListAsync(
            query.OrderByDescending(r => r.CreatedAt).Skip((page - 1) * pageSize).Take(pageSize));

        var requesterIds = items.Select(r => r.RequesterId).Distinct().ToList();
        var districtIds = items.Select(r => r.DistrictId).Distinct().ToList();
        var upazilaIds = items.Select(r => r.UpazilaId).Distinct().ToList();

        var users = await _userRepository.ToListAsync(_userRepository.Query().Where(u => requesterIds.Contains(u.Id)));
        var userLookup = users.ToDictionary(u => u.Id);

        var districts = await _districtRepository.ToListAsync(_districtRepository.Query().Where(d => districtIds.Contains(d.Id)));
        var districtLookup = districts.ToDictionary(d => d.Id);

        var upazilas = await _upazilaRepository.ToListAsync(_upazilaRepository.Query().Where(u => upazilaIds.Contains(u.Id)));
        var upazilaLookup = upazilas.ToDictionary(u => u.Id);

        var dtos = items.Select(item =>
        {
            userLookup.TryGetValue(item.RequesterId, out var user);
            districtLookup.TryGetValue(item.DistrictId, out var district);
            upazilaLookup.TryGetValue(item.UpazilaId, out var upazila);
            return MapToDto(item, user, district, upazila);
        }).ToList();

        return Result<PagedResult<BloodRequestDto>>.Success(new PagedResult<BloodRequestDto>
        {
            Items = dtos,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        });
    }

    public async Task<Result<BloodRequestDto>> CancelRequestAsync(Guid requestId, Guid requesterId, CancellationToken cancellationToken = default)
    {
        var request = await _requestRepository.GetByIdAsync(requestId, cancellationToken);
        if (request is null)
            return Result<BloodRequestDto>.NotFound();

        // 404 for non-owners too: don't reveal that another user's request exists.
        if (request.RequesterId != requesterId)
            return Result<BloodRequestDto>.NotFound();

        if (request.Status != RequestStatus.Open && request.Status != RequestStatus.PartiallyFulfilled)
            return Result<BloodRequestDto>.Failure("Only open or partially fulfilled requests can be cancelled");

        request.Status = RequestStatus.Cancelled;
        request.CancelledAt = DateTime.UtcNow;
        request.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var donorMatches = await _matchRepository.FindAsync(m => m.BloodRequestId == requestId, cancellationToken);
        if (donorMatches.Count > 0)
        {
            var cancelledDonors = donorMatches.Where(m => m.DonorResponse != DonorResponse.Declined).ToList();
            foreach (var match in cancelledDonors)
            {
                try
                {
                    await _notificationService.SendNotificationAsync(
                        match.DonorId,
                        "Blood Request Cancelled",
                        $"The blood request at {request.HospitalName} for {request.BloodGroup.ToLabel()} blood has been cancelled by the requester.",
                        NotificationType.RequestUpdate,
                        requestId);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to send cancel notification to donor {DonorId}", match.DonorId);
                }
            }
        }

        var user = await _userRepository.GetByIdAsync(request.RequesterId, cancellationToken);
        var district = await _districtRepository.GetByIdAsync(request.DistrictId, cancellationToken);
        var upazila = await _upazilaRepository.GetByIdAsync(request.UpazilaId, cancellationToken);

        return Result<BloodRequestDto>.Success(MapToDto(request, user, district, upazila));
    }

    public async Task<Result<BloodRequestDto>> UpdateRequestAsync(Guid requestId, Guid requesterId, bool isAdmin, UpdateBloodRequestRequest request, CancellationToken cancellationToken = default)
    {
        var existing = await _requestRepository.GetByIdAsync(requestId, cancellationToken);
        if (existing is null)
            return Result<BloodRequestDto>.Failure("Blood request not found");

        if (!isAdmin && existing.RequesterId != requesterId)
            return Result<BloodRequestDto>.Failure("You can only edit your own requests");

        if (existing.Status != RequestStatus.Open && existing.Status != RequestStatus.PartiallyFulfilled)
            return Result<BloodRequestDto>.Failure("Only open or partially fulfilled requests can be edited");

        if (request.UnitsRequired < existing.UnitsFulfilled)
            return Result<BloodRequestDto>.Failure($"Units required cannot be less than the {existing.UnitsFulfilled} unit(s) already fulfilled");

        var district = await _districtRepository.GetByIdAsync(request.DistrictId, cancellationToken);
        if (district is null)
            return Result<BloodRequestDto>.Failure("Invalid district");

        var upazila = await _upazilaRepository.GetByIdAsync(request.UpazilaId, cancellationToken);
        if (upazila is null)
            return Result<BloodRequestDto>.Failure("Invalid upazila");

        if (upazila.DistrictId != request.DistrictId)
            return Result<BloodRequestDto>.Failure("Upazila does not belong to district");

        existing.BloodGroup = request.BloodGroup;
        existing.UnitsRequired = request.UnitsRequired;
        existing.HospitalName = request.HospitalName;
        existing.HospitalAddress = request.HospitalAddress;
        existing.DistrictId = request.DistrictId;
        existing.UpazilaId = request.UpazilaId;
        existing.Area = request.Area;
        existing.Latitude = request.Latitude;
        existing.Longitude = request.Longitude;
        existing.RequiredBy = request.RequiredBy;
        existing.Urgency = request.Urgency;
        existing.PatientName = request.PatientName;
        existing.PatientRelation = request.PatientRelation;
        existing.ContactPhone = request.ContactPhone;
        existing.AdditionalInformation = request.AdditionalInformation;
        existing.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        try
        {
            await _notificationService.SendNotificationAsync(
                existing.RequesterId,
                "Blood Request Updated",
                $"Your blood request at {existing.HospitalName} has been updated.",
                NotificationType.RequestUpdate,
                existing.Id);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to send request-updated notification for {RequestId}", requestId);
        }

        var user = await _userRepository.GetByIdAsync(existing.RequesterId, cancellationToken);

        return Result<BloodRequestDto>.Success(MapToDto(existing, user, district, upazila));
    }

    public async Task<Result<BloodRequestDto>> UpdateFulfilledUnitsAsync(Guid requestId, Guid requesterId, int unitsFulfilled, CancellationToken cancellationToken = default)
    {
        var request = await _requestRepository.GetByIdAsync(requestId, cancellationToken);
        if (request is null)
            return Result<BloodRequestDto>.NotFound();

        // 404 for non-owners too: don't reveal that another user's request exists.
        if (request.RequesterId != requesterId)
            return Result<BloodRequestDto>.NotFound();

        if (request.Status != RequestStatus.Open && request.Status != RequestStatus.PartiallyFulfilled)
            return Result<BloodRequestDto>.Failure("Request is not in a fulfillable state");

        if (unitsFulfilled <= 0)
            return Result<BloodRequestDto>.Failure("Units fulfilled must be at least 1");

        var remaining = request.UnitsRequired - request.UnitsFulfilled;
        if (unitsFulfilled > remaining)
            return Result<BloodRequestDto>.Failure($"Cannot fulfill more than {remaining} remaining units");

        request.UnitsFulfilled += unitsFulfilled;

        if (request.UnitsFulfilled >= request.UnitsRequired)
        {
            request.Status = RequestStatus.Fulfilled;
            request.CompletedAt = DateTime.UtcNow;
        }
        else
        {
            request.Status = RequestStatus.PartiallyFulfilled;
        }

        request.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        // G5: auto-update LastDonationDate / availability for donors with Accepted matches when request becomes Fulfilled
        if (request.Status == RequestStatus.Fulfilled)
        {
            try
            {
                var acceptedMatches = await _matchRepository.FindAsync(
                    m => m.BloodRequestId == requestId && m.DonorResponse == DonorResponse.Accepted, cancellationToken);
                foreach (var match in acceptedMatches)
                {
                    var profile = await _donorProfileRepository.FirstOrDefaultAsync(p => p.UserId == match.DonorId, cancellationToken);
                    if (profile == null) continue;
                    profile.LastDonationDate = DateTime.UtcNow;
                    profile.AvailabilityStatus = AvailabilityStatus.RecentlyDonated;
                    profile.TotalDonationCount += 1;
                    profile.UpdatedAt = DateTime.UtcNow;
                    var record = new DonationRecord
                    {
                        DonorId = match.DonorId,
                        BloodRequestId = requestId,
                        DonationDate = DateTime.UtcNow,
                        DonationLocation = request.HospitalName,
                        Units = 1,
                        Notes = $"Auto-created on fulfillment of request {requestId}",
                        CreatedBy = requesterId
                    };
                    await _donationRecordRepository.AddAsync(record, cancellationToken);
                }
                if (acceptedMatches.Count > 0)
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to auto-update donor profiles on fulfillment for request {RequestId}", requestId);
            }

            try
            {
                await _notificationService.SendNotificationAsync(
                    requesterId,
                    "Blood Request Fulfilled",
                    $"Great news! Your blood request at {request.HospitalName} has been fully fulfilled. Thank you for using Blood Network Bangladesh!",
                    NotificationType.RequestUpdate,
                    requestId);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to send fulfill notification for {RequestId}", requestId);
            }
        }
        else
        {
            try
            {
                await _notificationService.SendNotificationAsync(
                    requesterId,
                    "Blood Request Partially Fulfilled",
                    $"Your blood request at {request.HospitalName} has been partially fulfilled: {request.UnitsFulfilled}/{request.UnitsRequired} units. {request.UnitsRequired - request.UnitsFulfilled} more units needed.",
                    NotificationType.RequestUpdate,
                    requestId);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to send partial-fulfill notification for {RequestId}", requestId);
            }
        }

        var user = await _userRepository.GetByIdAsync(request.RequesterId, cancellationToken);
        var district = await _districtRepository.GetByIdAsync(request.DistrictId, cancellationToken);
        var upazila = await _upazilaRepository.GetByIdAsync(request.UpazilaId, cancellationToken);

        return Result<BloodRequestDto>.Success(MapToDto(request, user, district, upazila));
    }

    public async Task<Result<PagedResult<PublicBloodRequestDto>>> SearchOpenRequestsAsync(BloodRequestSearchRequest request, CancellationToken cancellationToken = default)
    {
        var query = _requestRepository.Query()
            .Where(r => r.Status == RequestStatus.Open || r.Status == RequestStatus.PartiallyFulfilled);

        if (request.BloodGroup.HasValue)
            query = query.Where(r => r.BloodGroup == request.BloodGroup.Value);

        if (request.DistrictId.HasValue)
            query = query.Where(r => r.DistrictId == request.DistrictId.Value);

        if (request.Urgency.HasValue)
            query = query.Where(r => r.Urgency == request.Urgency.Value);

        var totalCount = await _requestRepository.CountAsync(query);

        var items = await _requestRepository.ToListAsync(
            query.OrderByDescending(r => r.CreatedAt).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize));

        var districtIds = items.Select(r => r.DistrictId).Distinct().ToList();
        var upazilaIds = items.Select(r => r.UpazilaId).Distinct().ToList();

        var districts = await _districtRepository.ToListAsync(_districtRepository.Query().Where(d => districtIds.Contains(d.Id)));
        var districtLookup = districts.ToDictionary(d => d.Id);

        var upazilas = await _upazilaRepository.ToListAsync(_upazilaRepository.Query().Where(u => upazilaIds.Contains(u.Id)));
        var upazilaLookup = upazilas.ToDictionary(u => u.Id);

        var dtos = items.Select(item =>
        {
            districtLookup.TryGetValue(item.DistrictId, out var district);
            upazilaLookup.TryGetValue(item.UpazilaId, out var upazila);
            return MapToPublicDto(item, district, upazila);
        }).ToList();

        return Result<PagedResult<PublicBloodRequestDto>>.Success(new PagedResult<PublicBloodRequestDto>
        {
            Items = dtos,
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        });
    }

    private static BloodRequestDto MapToDto(BloodRequest request, User? user, District? district, Upazila? upazila)
    {
        return new BloodRequestDto(
            request.Id,
            request.RequesterId,
            user is not null ? $"{user.FirstName} {user.LastName}" : string.Empty,
            request.BloodGroup,
            request.UnitsRequired,
            request.UnitsFulfilled,
            request.HospitalName,
            request.HospitalAddress,
            request.DistrictId,
            district?.Name,
            request.UpazilaId,
            upazila?.Name,
            request.Area,
            request.RequiredBy,
            request.Urgency,
            request.PatientName,
            request.PatientRelation,
            request.ContactPhone,
            request.AdditionalInformation,
            request.Status,
            request.CompletedAt,
            request.CancelledAt,
            request.CreatedAt
        );
    }

    private static PublicBloodRequestDto MapToPublicDto(BloodRequest request, District? district, Upazila? upazila)
    {
        return new PublicBloodRequestDto(
            request.Id,
            request.BloodGroup,
            request.UnitsRequired,
            request.UnitsFulfilled,
            request.HospitalName,
            request.HospitalAddress,
            request.DistrictId,
            district?.Name,
            request.UpazilaId,
            upazila?.Name,
            request.Area,
            request.RequiredBy,
            request.Urgency,
            request.AdditionalInformation,
            request.Status,
            request.CreatedAt
        );
    }
}
