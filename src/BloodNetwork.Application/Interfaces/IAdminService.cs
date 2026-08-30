using BloodNetwork.Application.DTOs;
using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.Interfaces;

public interface IAdminService
{
    Task<AdminDashboardStatsDto> GetDashboardStatsAsync();
    Task<AdminAnalyticsDto> GetAnalyticsAsync();
    Task<IReadOnlyList<AdminUserDto>> GetUsersAsync(string? search, UserRole? role, bool? isActive, int page = 1, int pageSize = 10);
    Task<int> GetUserCountAsync(string? search, UserRole? role, bool? isActive);
    Task<AdminUserDto?> ToggleUserActiveAsync(Guid userId, bool isActive);
    Task<AdminUserDto?> VerifyDonorAsync(Guid userId, VerificationStatus status);
    Task<IReadOnlyList<AdminReportDto>> GetReportsAsync(ReportStatus? status, int page = 1, int pageSize = 10);
    Task<int> GetReportCountAsync(ReportStatus? status);
    Task<IReadOnlyList<BloodRequestMatchDto>> GetMatchesAsync(DonorResponse? response, int page = 1, int pageSize = 10);
    Task<int> GetMatchCountAsync(DonorResponse? response);
    Task<IReadOnlyList<BloodRequestDto>> GetBloodRequestsAsync(RequestStatus? status, BloodGroup? bloodGroup, int page = 1, int pageSize = 10);
    Task<int> GetBloodRequestCountAsync(RequestStatus? status, BloodGroup? bloodGroup);
    Task<AdminReportDto?> ResolveReportAsync(Guid reportId, Guid adminId, ReportStatus status, string? resolution);
    Task<IReadOnlyList<AdminAuditLogDto>> GetAuditLogsAsync(string? entityType, int page = 1, int pageSize = 10);
    Task<int> GetAuditLogCountAsync(string? entityType);
    Task LogActionAsync(Guid? userId, string action, string entityType, Guid? entityId, string? ipAddress, string? metadata);

    Task<IReadOnlyList<AdminEligibilityQuestionDto>> GetEligibilityQuestionsAsync();
    Task<AdminEligibilityQuestionDto> CreateEligibilityQuestionAsync(SaveEligibilityQuestionRequest request);
    Task<AdminEligibilityQuestionDto?> UpdateEligibilityQuestionAsync(Guid id, SaveEligibilityQuestionRequest request);
    Task<AdminEligibilityQuestionDto?> ToggleEligibilityQuestionActiveAsync(Guid id, bool isActive);
    Task<bool> DeleteEligibilityQuestionAsync(Guid id);
}
