using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.DTOs;

public record CreateBloodRequestRequest(
    BloodGroup BloodGroup,
    int UnitsRequired,
    string HospitalName,
    string HospitalAddress,
    Guid DistrictId,
    Guid UpazilaId,
    string? Area,
    DateTime RequiredBy,
    Urgency Urgency,
    string? PatientName,
    string? PatientRelation,
    string ContactPhone,
    string? AdditionalInformation,
    double? Latitude,
    double? Longitude
);

public record BloodRequestDto(
    Guid Id,
    Guid RequesterId,
    string RequesterName,
    BloodGroup BloodGroup,
    int UnitsRequired,
    int UnitsFulfilled,
    string HospitalName,
    string HospitalAddress,
    Guid DistrictId,
    string? DistrictName,
    Guid UpazilaId,
    string? UpazilaName,
    string? Area,
    DateTime RequiredBy,
    Urgency Urgency,
    string? PatientName,
    string? PatientRelation,
    string ContactPhone,
    string? AdditionalInformation,
    RequestStatus Status,
    DateTime? CompletedAt,
    DateTime? CancelledAt,
    DateTime CreatedAt
);

public record PublicBloodRequestDto(
    Guid Id,
    BloodGroup BloodGroup,
    int UnitsRequired,
    int UnitsFulfilled,
    string HospitalName,
    string HospitalAddress,
    Guid DistrictId,
    string? DistrictName,
    Guid UpazilaId,
    string? UpazilaName,
    string? Area,
    DateTime RequiredBy,
    Urgency Urgency,
    string? AdditionalInformation,
    RequestStatus Status,
    DateTime CreatedAt
);

public record BloodRequestSearchRequest(
    BloodGroup? BloodGroup,
    Guid? DistrictId,
    RequestStatus? Status,
    Urgency? Urgency,
    int Page = 1,
    int PageSize = 20
);

public record CancelBloodRequestRequest(
    string? Reason
);

public record FulfillBloodRequestRequest(
    int UnitsFulfilled,
    string? Notes
);
