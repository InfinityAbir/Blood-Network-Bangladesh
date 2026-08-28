using BloodNetwork.Domain.Common;
using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Domain.Entities;

public class DonorProfile : BaseEntity
{
    public Guid UserId { get; set; }
    public BloodGroup BloodGroup { get; set; }
    public string? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Guid DistrictId { get; set; }
    public Guid UpazilaId { get; set; }
    public string? Area { get; set; }
    public string? CustomAddress { get; set; }
    public DateTime? LastDonationDate { get; set; }
    public AvailabilityStatus AvailabilityStatus { get; set; } = AvailabilityStatus.Unknown;
    public VerificationStatus VerificationStatus { get; set; } = VerificationStatus.Unverified;
    public DateTime? LastProfileConfirmedAt { get; set; }
    public int TotalDonationCount { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public User User { get; set; } = null!;
    public District District { get; set; } = null!;
    public Upazila Upazila { get; set; } = null!;
    public ICollection<DonationRecord> DonationRecords { get; set; } = new List<DonationRecord>();
}
