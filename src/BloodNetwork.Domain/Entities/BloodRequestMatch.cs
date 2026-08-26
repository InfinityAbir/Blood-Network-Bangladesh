using BloodNetwork.Domain.Common;
using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Domain.Entities;

public class BloodRequestMatch : BaseEntity
{
    public Guid BloodRequestId { get; set; }
    public Guid DonorId { get; set; }
    public int MatchScore { get; set; }
    public double? DistanceKm { get; set; }
    public DonorResponse DonorResponse { get; set; } = DonorResponse.Pending;
    public DateTime? ContactedAt { get; set; }
    public DateTime? RespondedAt { get; set; }
    public DateTime? AcceptedAt { get; set; }
    public DateTime? DeclinedAt { get; set; }

    public BloodRequest BloodRequest { get; set; } = null!;
    public User Donor { get; set; } = null!;
}
