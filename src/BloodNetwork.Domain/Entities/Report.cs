using BloodNetwork.Domain.Common;
using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Domain.Entities;

public class Report : BaseEntity
{
    public Guid ReporterUserId { get; set; }
    public Guid ReportedUserId { get; set; }
    public Guid? BloodRequestId { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ReportStatus Status { get; set; } = ReportStatus.Open;
    public Guid? ReviewedBy { get; set; }
    public string? Resolution { get; set; }
    public DateTime? ResolvedAt { get; set; }

    public User Reporter { get; set; } = null!;
    public User ReportedUser { get; set; } = null!;
    public BloodRequest? BloodRequest { get; set; }
}
