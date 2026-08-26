using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.Interfaces;

public interface IDonorEngagementService
{
    Task<IReadOnlyList<DonorEngagementDto>> GetTopEngagedDonorsAsync(BloodGroup bloodGroup, int count = 10);
    Task<DonorEngagementDto?> GetDonorEngagementAsync(Guid donorId);
    Task<int> GetReEngagementScoreAsync(Guid donorId);
}

public class DonorEngagementDto
{
    public Guid DonorId { get; set; }
    public string DonorName { get; set; } = string.Empty;
    public BloodGroup BloodGroup { get; set; }
    public int EngagementScore { get; set; }
    public int TotalDonations { get; set; }
    public DateTime? LastDonationDate { get; set; }
    public AvailabilityStatus Status { get; set; }
    public VerificationStatus Verification { get; set; }
    public string EngagementTier { get; set; } = string.Empty;
}
