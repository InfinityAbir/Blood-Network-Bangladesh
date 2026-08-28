using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.DTOs;

public record CreateDonorProfileRequest(
    BloodGroup BloodGroup,
    string? Gender,
    DateTime? DateOfBirth,
    Guid DistrictId,
    Guid UpazilaId,
    string? Area,
    string? CustomAddress,
    double? Latitude,
    double? Longitude,
    DateTime? LastDonationDate = null
);

public record UpdateDonorProfileRequest(
    BloodGroup BloodGroup,
    string? Gender,
    DateTime? DateOfBirth,
    Guid DistrictId,
    Guid UpazilaId,
    string? Area,
    string? CustomAddress,
    double? Latitude,
    double? Longitude,
    DateTime? LastDonationDate = null
);

public record DonorProfileDto(
    Guid Id,
    Guid UserId,
    BloodGroup BloodGroup,
    string? Gender,
    DateTime? DateOfBirth,
    Guid DistrictId,
    string? DistrictName,
    Guid UpazilaId,
    string? UpazilaName,
    string? Area,
    string? CustomAddress,
    DateTime? LastDonationDate,
    AvailabilityStatus AvailabilityStatus,
    VerificationStatus VerificationStatus,
    int TotalDonationCount,
    double? Latitude,
    double? Longitude,
    DateTime CreatedAt
);

public record PublicDonorDto(
    Guid Id,
    string FirstName,
    BloodGroup BloodGroup,
    string DistrictName,
    string UpazilaName,
    string? Area,
    AvailabilityStatus AvailabilityStatus,
    VerificationStatus VerificationStatus,
    double? DistanceKm
);

public record DonorSearchRequest(
    BloodGroup? BloodGroup,
    Guid? DistrictId,
    Guid? UpazilaId,
    AvailabilityStatus? AvailabilityStatus,
    double? Latitude,
    double? Longitude,
    int Page = 1,
    int PageSize = 20
);

public record ToggleAvailabilityRequest(
    AvailabilityStatus AvailabilityStatus
);
