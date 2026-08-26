using BloodNetwork.Application.Common;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;

namespace BloodNetwork.Application.Services;

public class BloodRequestService
{
    private readonly IRepository<BloodRequest> _requestRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<District> _districtRepository;
    private readonly IRepository<Upazila> _upazilaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMatchingService _matchingService;

    public BloodRequestService(
        IRepository<BloodRequest> requestRepository,
        IRepository<User> userRepository,
        IRepository<District> districtRepository,
        IRepository<Upazila> upazilaRepository,
        IUnitOfWork unitOfWork,
        IMatchingService matchingService)
    {
        _requestRepository = requestRepository;
        _userRepository = userRepository;
        _districtRepository = districtRepository;
        _upazilaRepository = upazilaRepository;
        _unitOfWork = unitOfWork;
        _matchingService = matchingService;
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

        _ = _matchingService.MatchRequestAsync(bloodRequest.Id);

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
        var allRequests = await _requestRepository.FindAsync(r => r.RequesterId == requesterId, cancellationToken);
        var query = allRequests.AsEnumerable();

        if (status.HasValue)
            query = query.Where(r => r.Status == status.Value);

        var sorted = query.OrderByDescending(r => r.CreatedAt).ToList();
        var totalCount = sorted.Count;

        var items = sorted
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var dtos = new List<BloodRequestDto>();
        foreach (var item in items)
        {
            var user = await _userRepository.GetByIdAsync(item.RequesterId, cancellationToken);
            var district = await _districtRepository.GetByIdAsync(item.DistrictId, cancellationToken);
            var upazila = await _upazilaRepository.GetByIdAsync(item.UpazilaId, cancellationToken);
            dtos.Add(MapToDto(item, user, district, upazila));
        }

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
            return Result<BloodRequestDto>.Failure("Blood request not found");

        if (request.RequesterId != requesterId)
            return Result<BloodRequestDto>.Failure("You can only cancel your own requests");

        if (request.Status != RequestStatus.Open && request.Status != RequestStatus.PartiallyFulfilled)
            return Result<BloodRequestDto>.Failure("Only open or partially fulfilled requests can be cancelled");

        request.Status = RequestStatus.Cancelled;
        request.CancelledAt = DateTime.UtcNow;
        request.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var user = await _userRepository.GetByIdAsync(request.RequesterId, cancellationToken);
        var district = await _districtRepository.GetByIdAsync(request.DistrictId, cancellationToken);
        var upazila = await _upazilaRepository.GetByIdAsync(request.UpazilaId, cancellationToken);

        return Result<BloodRequestDto>.Success(MapToDto(request, user, district, upazila));
    }

    public async Task<Result<BloodRequestDto>> UpdateFulfilledUnitsAsync(Guid requestId, Guid requesterId, int unitsFulfilled, CancellationToken cancellationToken = default)
    {
        var request = await _requestRepository.GetByIdAsync(requestId, cancellationToken);
        if (request is null)
            return Result<BloodRequestDto>.Failure("Blood request not found");

        if (request.RequesterId != requesterId)
            return Result<BloodRequestDto>.Failure("You can only update your own requests");

        if (request.Status != RequestStatus.Open && request.Status != RequestStatus.PartiallyFulfilled)
            return Result<BloodRequestDto>.Failure("Request is not in a fulfillable state");

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

        var user = await _userRepository.GetByIdAsync(request.RequesterId, cancellationToken);
        var district = await _districtRepository.GetByIdAsync(request.DistrictId, cancellationToken);
        var upazila = await _upazilaRepository.GetByIdAsync(request.UpazilaId, cancellationToken);

        return Result<BloodRequestDto>.Success(MapToDto(request, user, district, upazila));
    }

    public async Task<Result<PagedResult<BloodRequestDto>>> SearchOpenRequestsAsync(BloodRequestSearchRequest request, CancellationToken cancellationToken = default)
    {
        var allRequests = await _requestRepository.GetAllAsync(cancellationToken);
        var query = allRequests.Where(r => r.Status == RequestStatus.Open || r.Status == RequestStatus.PartiallyFulfilled);

        if (request.BloodGroup.HasValue)
            query = query.Where(r => r.BloodGroup == request.BloodGroup.Value);

        if (request.DistrictId.HasValue)
            query = query.Where(r => r.DistrictId == request.DistrictId.Value);

        if (request.Urgency.HasValue)
            query = query.Where(r => r.Urgency == request.Urgency.Value);

        var totalCount = query.Count();
        var sorted = query.OrderByDescending(r => r.CreatedAt).ToList();

        var items = sorted
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        var dtos = new List<BloodRequestDto>();
        foreach (var item in items)
        {
            var user = await _userRepository.GetByIdAsync(item.RequesterId, cancellationToken);
            var district = await _districtRepository.GetByIdAsync(item.DistrictId, cancellationToken);
            var upazila = await _upazilaRepository.GetByIdAsync(item.UpazilaId, cancellationToken);
            dtos.Add(MapToDto(item, user, district, upazila));
        }

        return Result<PagedResult<BloodRequestDto>>.Success(new PagedResult<BloodRequestDto>
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
}
