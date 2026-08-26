using BloodNetwork.Domain.Common;
using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Domain.Entities;

public class BloodRequest : BaseEntity
{
    public Guid RequesterId { get; set; }
    public BloodGroup BloodGroup { get; set; }
    public int UnitsRequired { get; set; }
    public int UnitsFulfilled { get; set; }
    public string HospitalName { get; set; } = string.Empty;
    public string HospitalAddress { get; set; } = string.Empty;
    public Guid DistrictId { get; set; }
    public Guid UpazilaId { get; set; }
    public string? Area { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public DateTime RequiredBy { get; set; }
    public Urgency Urgency { get; set; } = Urgency.Normal;
    public string? PatientName { get; set; }
    public string? PatientRelation { get; set; }
    public string ContactPhone { get; set; } = string.Empty;
    public string? AdditionalInformation { get; set; }
    public RequestStatus Status { get; set; } = RequestStatus.Open;
    public DateTime? CompletedAt { get; set; }
    public DateTime? CancelledAt { get; set; }

    public User Requester { get; set; } = null!;
    public District District { get; set; } = null!;
    public Upazila Upazila { get; set; } = null!;
    public ICollection<BloodRequestMatch> Matches { get; set; } = new List<BloodRequestMatch>();
}
