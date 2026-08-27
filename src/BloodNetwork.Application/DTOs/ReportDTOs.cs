using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.DTOs;

public class CreateReportRequest
{
    public Guid ReportedUserId { get; set; }
    public Guid? BloodRequestId { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string? Description { get; set; }
}

public class ReportDto
{
    public Guid Id { get; set; }
    public string ReporterName { get; set; } = string.Empty;
    public string ReportedUserName { get; set; } = string.Empty;
    public string? BloodRequestHospital { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ReportStatus Status { get; set; }
    public string? Resolution { get; set; }
    public DateTime CreatedAt { get; set; }
}
