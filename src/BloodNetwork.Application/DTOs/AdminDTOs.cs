using System.ComponentModel.DataAnnotations;
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
    public string? PhotoUrl { get; set; }
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

public class AdminAnalyticsDto
{
    public List<BloodTypeCountDto> BloodTypeDistribution { get; set; } = new();
    public List<StatusCountDto> RequestStatusBreakdown { get; set; } = new();
    public List<StatusCountDto> UrgencyBreakdown { get; set; } = new();
    public List<StatusCountDto> DonorVerificationBreakdown { get; set; } = new();
    public List<DistrictCountDto> RequestsByDistrict { get; set; } = new();
    public List<DistrictCountDto> DonorsByDistrict { get; set; } = new();
    public List<TimeSeriesPointDto> RequestsOverTime { get; set; } = new();
    public List<TimeSeriesPointDto> NewDonorsOverTime { get; set; } = new();
    public double FulfillmentRatePercent { get; set; }
    public double? AverageDonorResponseHours { get; set; }
}

public class BloodTypeCountDto
{
    public BloodGroup BloodGroup { get; set; }
    public int Count { get; set; }
}

public class StatusCountDto
{
    public string Status { get; set; } = string.Empty;
    public int Count { get; set; }
}

public class DistrictCountDto
{
    public string DistrictName { get; set; } = string.Empty;
    public int Count { get; set; }
}

public class TimeSeriesPointDto
{
    public DateTime Date { get; set; }
    public int Count { get; set; }
}

public class DeveloperInfoDto
{
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? GithubUrl { get; set; }
    public string? PhotoUrl { get; set; }
}

public class UpdateDeveloperInfoRequest
{
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? GithubUrl { get; set; }
    public string? PhotoUrl { get; set; }
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

public class AdminEligibilityQuestionDto
{
    public Guid Id { get; set; }
    public string QuestionEn { get; set; } = string.Empty;
    public string QuestionBn { get; set; } = string.Empty;
    public string QuestionBanglish { get; set; } = string.Empty;
    public string QuestionType { get; set; } = string.Empty;
    public string? Unit { get; set; }
    public int? MinValue { get; set; }
    public int? MaxValue { get; set; }
    public bool? PassOnYes { get; set; }
    public bool IsCritical { get; set; }
    public bool IsActive { get; set; }
    public int DisplayOrder { get; set; }
    public string PassMessageEn { get; set; } = string.Empty;
    public string PassMessageBn { get; set; } = string.Empty;
    public string FailMessageEn { get; set; } = string.Empty;
    public string FailMessageBn { get; set; } = string.Empty;
}

public class ToggleEligibilityQuestionActiveRequest
{
    public bool IsActive { get; set; }
}

public class SaveEligibilityQuestionRequest
{
    [Required] public string QuestionEn { get; set; } = string.Empty;
    [Required] public string QuestionBn { get; set; } = string.Empty;
    [Required] public string QuestionBanglish { get; set; } = string.Empty;
    /// <summary>"number" or "yesno".</summary>
    [Required] public string QuestionType { get; set; } = string.Empty;
    public string? Unit { get; set; }
    public int? MinValue { get; set; }
    public int? MaxValue { get; set; }
    public bool? PassOnYes { get; set; }
    public bool IsCritical { get; set; }
    public int DisplayOrder { get; set; }
    [Required] public string PassMessageEn { get; set; } = string.Empty;
    [Required] public string PassMessageBn { get; set; } = string.Empty;
    [Required] public string FailMessageEn { get; set; } = string.Empty;
    [Required] public string FailMessageBn { get; set; } = string.Empty;
}
