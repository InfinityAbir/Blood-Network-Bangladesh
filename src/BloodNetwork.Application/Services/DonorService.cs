using BloodNetwork.Application.Common;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;

namespace BloodNetwork.Application.Services;

public class DonorService
{
    private readonly IRepository<DonorProfile> _donorProfileRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<District> _districtRepository;
    private readonly IRepository<Upazila> _upazilaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapService _mapService;

    public DonorService(
        IRepository<DonorProfile> donorProfileRepository,
        IRepository<User> userRepository,
        IRepository<District> districtRepository,
        IRepository<Upazila> upazilaRepository,
        IUnitOfWork unitOfWork,
        IMapService mapService)
    {
        _donorProfileRepository = donorProfileRepository;
        _userRepository = userRepository;
        _districtRepository = districtRepository;
        _upazilaRepository = upazilaRepository;
        _unitOfWork = unitOfWork;
        _mapService = mapService;
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

        profile.BloodGroup = request.BloodGroup;
        profile.Gender = request.Gender;
        profile.DateOfBirth = request.DateOfBirth;
        profile.DistrictId = request.DistrictId;
        profile.UpazilaId = request.UpazilaId;
        profile.Area = request.Area;
        profile.Latitude = request.Latitude;
        profile.Longitude = request.Longitude;
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

        var district = await _districtRepository.GetByIdAsync(profile.DistrictId, cancellationToken);
        var upazila = await _upazilaRepository.GetByIdAsync(profile.UpazilaId, cancellationToken);

        return Result<DonorProfileDto>.Success(MapToDto(profile, district?.Name, upazila?.Name));
    }

    public async Task<Result<PagedResult<PublicDonorDto>>> SearchDonorsAsync(DonorSearchRequest request, CancellationToken cancellationToken = default)
    {
        var profiles = await _donorProfileRepository.FindAsync(
            p => p.VerificationStatus == VerificationStatus.Verified,
            cancellationToken);

        var filtered = profiles.AsEnumerable();

        if (request.BloodGroup.HasValue)
            filtered = filtered.Where(p => p.BloodGroup == request.BloodGroup.Value);
        if (request.DistrictId.HasValue)
            filtered = filtered.Where(p => p.DistrictId == request.DistrictId.Value);
        if (request.UpazilaId.HasValue)
            filtered = filtered.Where(p => p.UpazilaId == request.UpazilaId.Value);
        if (request.AvailabilityStatus.HasValue)
            filtered = filtered.Where(p => p.AvailabilityStatus == request.AvailabilityStatus.Value);

        var totalCount = filtered.Count();

        var items = filtered
            .OrderBy(p => p.CreatedAt)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        var userIds = items.Select(p => p.UserId).ToList();
        var districtIds = items.Select(p => p.DistrictId).Distinct().ToList();
        var upazilaIds = items.Select(p => p.UpazilaId).Distinct().ToList();

        var users = await _userRepository.FindAsync(u => userIds.Contains(u.Id), cancellationToken);
        var userLookup = users.ToDictionary(u => u.Id);

        var districts = await _districtRepository.FindAsync(d => districtIds.Contains(d.Id), cancellationToken);
        var districtLookup = districts.ToDictionary(d => d.Id);

        var upazilas = await _upazilaRepository.FindAsync(u => upazilaIds.Contains(u.Id), cancellationToken);
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
