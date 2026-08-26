using BloodNetwork.Domain.Common;
using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Domain.Entities;

public class VerificationRecord : BaseEntity
{
    public Guid UserId { get; set; }
    public VerificationType Type { get; set; }
    public VerificationStatus Status { get; set; } = VerificationStatus.Pending;
    public Guid? VerifiedBy { get; set; }
    public string? Notes { get; set; }

    public User User { get; set; } = null!;
}
