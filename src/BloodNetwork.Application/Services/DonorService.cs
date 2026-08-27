using BloodNetwork.Application.Common;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BloodNetwork.Application.Services;

public class DonorService
{
    private readonly IRepository<DonorProfile> _donorProfileRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<District> _districtRepository;
    private readonly IRepository<Upazila> _upazilaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapService _mapService;
    private readonly INotificationService _notificationService;
    private readonly IRepository<BloodRequest> _bloodRequestRepository;
    private readonly IMatchingService _matchingService;
    private readonly ILogger<DonorService> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public DonorService(
        IRepository<DonorProfile> donorProfileRepository,
        IRepository<User> userRepository,
        IRepository<District> districtRepository,
        IRepository<Upazila> upazilaRepository,
        IUnitOfWork unitOfWork,
        IMapService mapService,
        INotificationService notificationService,
        IRepository<BloodRequest> bloodRequestRepository,
        IMatchingService matchingService,
        ILogger<DonorService> logger,
        IServiceScopeFactory scopeFactory)
    {
        _donorProfileRepository = donorProfileRepository;
        _userRepository = userRepository;
        _districtRepository = districtRepository;
        _upazilaRepository = upazilaRepository;
        _unitOfWork = unitOfWork;
        _mapService = mapService;
        _notificationService = notificationService;
        _bloodRequestRepository = bloodRequestRepository;
        _matchingService = matchingService;
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    public async Task<Result<DonorProfileDto>> CreateProfileAsync(Guid userId, CreateDonorProfileRequest request, CancellationToken cancellationToken = default)
    {
        var existingProfile = await _donorProfileRepository.FirstOrDefaultAsync(
            p => p.UserId == userId, cancellationToken);

        if (existingProfile is not null)
            return Result<DonorProfileDto>.Failure("Donor profile already exists");

        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user is null)
            return Result<DonorProfileDto>.Failure("User not found");

        var district = await _districtRepository.GetByIdAsync(request.DistrictId, cancellationToken);
        if (district is null)
            return Result<DonorProfileDto>.Failure("Invalid district");

        var upazila = await _upazilaRepository.GetByIdAsync(request.UpazilaId, cancellationToken);
        if (upazila is null)
            return Result<DonorProfileDto>.Failure("Invalid upazila");

        if (upazila.DistrictId != request.DistrictId)
            return Result<DonorProfileDto>.Failure("Upazila does not belong to district");

        var profile = new DonorProfile
        {
            UserId = userId,
            BloodGroup = request.BloodGroup,
            Gender = request.Gender,
            DateOfBirth = request.DateOfBirth,
            DistrictId = request.DistrictId,
            UpazilaId = request.UpazilaId,
            Area = request.Area,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            LastDonationDate = request.LastDonationDate,
            AvailabilityStatus = AvailabilityStatus.Available,
            VerificationStatus = VerificationStatus.Unverified
        };

        await _donorProfileRepository.AddAsync(profile, cancellationToken);

        if (user.Role == UserRole.Requester)
            user.Role = UserRole.Donor;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<DonorProfileDto>.Success(MapToDto(profile, district.Name, upazila.Name));
    }

    public async Task<Result<DonorProfileDto>> UpdateProfileAsync(Guid userId, UpdateDonorProfileRequest request, CancellationToken cancellationToken = default)
    {
        var profile = await _donorProfileRepository.FirstOrDefaultAsync(
            p => p.UserId == userId, cancellationToken);

        if (profile is null)
            return Result<DonorProfileDto>.Failure("Donor profile not found");

        var district = await _districtRepository.GetByIdAsync(request.DistrictId, cancellationToken);
        if (district is null)
            return Result<DonorProfileDto>.Failure("Invalid district");

        var upazila = await _upazilaRepository.GetByIdAsync(request.UpazilaId, cancellationToken);
        if (upazila is null)
            return Result<DonorProfileDto>.Failure("Invalid upazila");

        if (upazila.DistrictId != request.DistrictId)
            return Result<DonorProfileDto>.Failure("Upazila does not belong to district");

        profile.BloodGroup = request.BloodGroup;
        profile.Gender = request.Gender;
        profile.DateOfBirth = request.DateOfBirth;
        profile.DistrictId = request.DistrictId;
        profile.UpazilaId = request.UpazilaId;
        profile.Area = request.Area;
        profile.Latitude = request.Latitude;
        profile.Longitude = request.Longitude;
        profile.LastDonationDate = request.LastDonationDate;
        profile.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<DonorProfileDto>.Success(MapToDto(profile, district.Name, upazila.Name));
    }

    public async Task<Result<DonorProfileDto>> GetMyProfileAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var profile = await _donorProfileRepository.FirstOrDefaultAsync(
            p => p.UserId == userId, cancellationToken);

        if (profile is null)
            return Result<DonorProfileDto>.Failure("Donor profile not found");

        var district = await _districtRepository.GetByIdAsync(profile.DistrictId, cancellationToken);
        var upazila = await _upazilaRepository.GetByIdAsync(profile.UpazilaId, cancellationToken);

        return Result<DonorProfileDto>.Success(MapToDto(profile, district?.Name, upazila?.Name));
    }

    public async Task<Result<DonorProfileDto>> ToggleAvailabilityAsync(Guid userId, ToggleAvailabilityRequest request, CancellationToken cancellationToken = default)
    {
        var profile = await _donorProfileRepository.FirstOrDefaultAsync(
            p => p.UserId == userId, cancellationToken);

        if (profile is null)
            return Result<DonorProfileDto>.Failure("Donor profile not found");

        profile.AvailabilityStatus = request.AvailabilityStatus;
        profile.UpdatedAt = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        if (request.AvailabilityStatus == AvailabilityStatus.Available)
        {
            var openRequests = await _bloodRequestRepository.FindAsync(
                r => (r.Status == RequestStatus.Open || r.Status == RequestStatus.PartiallyFulfilled) &&
                     r.BloodGroup == profile.BloodGroup,
                cancellationToken);

            foreach (var openRequest in openRequests)
            {
                var capturedRequestId = openRequest.Id;
                _ = Task.Run(async () =>
                {
                    using var scope = _scopeFactory.CreateScope();
                    var matching = scope.ServiceProvider.GetRequiredService<IMatchingService>();
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<DonorService>>();
                    try
                    {
                        await matching.MatchRequestAsync(capturedRequestId);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Background matching failed for request {RequestId}", capturedRequestId);
                    }
                });
            }
        }

        var district = await _districtRepository.GetByIdAsync(profile.DistrictId, cancellationToken);
        var upazila = await _upazilaRepository.GetByIdAsync(profile.UpazilaId, cancellationToken);

        return Result<DonorProfileDto>.Success(MapToDto(profile, district?.Name, upazila?.Name));
    }

    public async Task<Result<PagedResult<PublicDonorDto>>> SearchDonorsAsync(DonorSearchRequest request, CancellationToken cancellationToken = default)
    {
        var query = _donorProfileRepository.Query()
            .Where(p => p.VerificationStatus == VerificationStatus.Verified)
            .Where(p => _userRepository.Query().Any(u => u.Id == p.UserId && u.IsActive));

        if (request.BloodGroup.HasValue)
            query = query.Where(p => p.BloodGroup == request.BloodGroup.Value);
        if (request.DistrictId.HasValue)
            query = query.Where(p => p.DistrictId == request.DistrictId.Value);
        if (request.UpazilaId.HasValue)
            query = query.Where(p => p.UpazilaId == request.UpazilaId.Value);
        if (request.AvailabilityStatus.HasValue)
            query = query.Where(p => p.AvailabilityStatus == request.AvailabilityStatus.Value);

        var totalCount = await _donorProfileRepository.CountAsync(query);

        var items = await _donorProfileRepository.ToListAsync(
            query.OrderBy(p => p.CreatedAt).Skip((request.Page - 1) * request.PageSize).Take(request.PageSize));

        var userIds = items.Select(p => p.UserId).ToList();
        var districtIds = items.Select(p => p.DistrictId).Distinct().ToList();
        var upazilaIds = items.Select(p => p.UpazilaId).Distinct().ToList();

        var users = await _userRepository.ToListAsync(_userRepository.Query().Where(u => userIds.Contains(u.Id)));
        var userLookup = users.ToDictionary(u => u.Id);

        var districts = await _districtRepository.ToListAsync(_districtRepository.Query().Where(d => districtIds.Contains(d.Id)));
        var districtLookup = districts.ToDictionary(d => d.Id);

        var upazilas = await _upazilaRepository.ToListAsync(_upazilaRepository.Query().Where(u => upazilaIds.Contains(u.Id)));
        var upazilaLookup = upazilas.ToDictionary(u => u.Id);

        var publicDonors = new List<PublicDonorDto>();
        foreach (var item in items)
        {
            userLookup.TryGetValue(item.UserId, out var user);
            districtLookup.TryGetValue(item.DistrictId, out var district);
            upazilaLookup.TryGetValue(item.UpazilaId, out var upazila);

            double? distance = null;
            if (request.Latitude.HasValue && request.Longitude.HasValue &&
                item.Latitude.HasValue && item.Longitude.HasValue)
            {
                distance = _mapService.CalculateDistanceKm(
                    request.Latitude.Value, request.Longitude.Value,
                    item.Latitude.Value, item.Longitude.Value);
            }

            publicDonors.Add(new PublicDonorDto(
                item.Id,
                user?.FirstName ?? string.Empty,
                item.BloodGroup,
                district?.Name ?? string.Empty,
                upazila?.Name ?? string.Empty,
                item.Area,
                item.AvailabilityStatus,
                item.VerificationStatus,
                distance
            ));
        }

        if (request.Latitude.HasValue && request.Longitude.HasValue)
        {
            publicDonors = publicDonors
                .OrderBy(d => d.DistanceKm ?? double.MaxValue)
                .ToList();
        }

        return Result<PagedResult<PublicDonorDto>>.Success(new PagedResult<PublicDonorDto>
        {
            Items = publicDonors,
            TotalCount = totalCount,
            Page = request.Page,
            PageSize = request.PageSize
        });
    }

    private static DonorProfileDto MapToDto(DonorProfile profile, string? districtName, string? upazilaName)
    {
        return new DonorProfileDto(
            profile.Id,
            profile.UserId,
            profile.BloodGroup,
            profile.Gender,
            profile.DateOfBirth,
            profile.DistrictId,
            districtName,
            profile.UpazilaId,
            upazilaName,
            profile.Area,
            profile.LastDonationDate,
            profile.AvailabilityStatus,
            profile.VerificationStatus,
            profile.TotalDonationCount,
            profile.Latitude,
            profile.Longitude,
            profile.CreatedAt
        );
    }
}
