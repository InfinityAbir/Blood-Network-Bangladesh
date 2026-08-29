using BloodNetwork.Domain.Common;
using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Domain.Entities;

public class Notification : BaseEntity
{
    public Guid UserId { get; set; }
    public NotificationType Type { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public Guid? RelatedEntityId { get; set; }
    public bool IsRead { get; set; }
    public DateTime? ReadAt { get; set; }
    /// <summary>Small JSON payload (e.g. bloodGroup/districtId/availabilityStatus) so the
    /// client can deep-link or render a status pill without an extra round-trip.</summary>
    public string? Metadata { get; set; }

    public User User { get; set; } = null!;
}
