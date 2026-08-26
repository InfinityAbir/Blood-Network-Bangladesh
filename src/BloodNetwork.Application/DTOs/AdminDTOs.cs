using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.DTOs;

public class AdminDashboardStatsDto
{
    public int TotalUsers { get; set; }
    public int TotalDonors { get; set; }
    public int TotalRequesters { get; set; }
    public int TotalBloodRequests { get; set; }
    public int OpenBloodRequests { get; set; }
    public int FulfilledBloodRequests { get; set; }
    public int TotalMatches { get; set; }
    public int AcceptedMatches { get; set; }
    public int TotalReports { get; set; }
    public int OpenReports { get; set; }
    public int PendingVerifications { get; set; }
}

public class AdminUserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Email { get; set; }
    public UserRole Role { get; set; }
    public bool IsActive { get; set; }
    public bool IsPhoneVerified { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? DonorVerificationStatus { get; set; }
}

public class AdminReportDto
{
    public Guid Id { get; set; }
    public string ReporterName { get; set; } = string.Empty;
    public string ReportedUserName { get; set; } = string.Empty;
    public Guid? BloodRequestId { get; set; }
    public string Reason { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ReportStatus Status { get; set; }
    public string? ReviewedByName { get; set; }
    public string? Resolution { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class AdminAuditLogDto
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string Action { get; set; } = string.Empty;
    public string EntityType { get; set; } = string.Empty;
    public Guid? EntityId { get; set; }
    public string? IpAddress { get; set; }
    public string? Metadata { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class ToggleUserActiveRequest
{
    public bool IsActive { get; set; }
}

public class VerifyDonorRequest
{
    public VerificationStatus Status { get; set; }
}

public class ResolveReportRequest
{
    public ReportStatus Status { get; set; }
    public string? Resolution { get; set; }
}
