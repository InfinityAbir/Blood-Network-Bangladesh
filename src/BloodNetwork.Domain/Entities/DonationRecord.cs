using BloodNetwork.Domain.Common;

namespace BloodNetwork.Domain.Entities;

public class DonationRecord : BaseEntity
{
    public Guid DonorId { get; set; }
    public Guid? BloodRequestId { get; set; }
    public DateTime DonationDate { get; set; }
    public string? DonationLocation { get; set; }
    public int? Units { get; set; }
    public string? Notes { get; set; }
    public Guid CreatedBy { get; set; }

    public User Donor { get; set; } = null!;
    public BloodRequest? BloodRequest { get; set; }
}
