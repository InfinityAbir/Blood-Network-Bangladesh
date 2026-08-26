using BloodNetwork.Application.DTOs;
using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.Interfaces;

public interface IAdminService
{
    Task<AdminDashboardStatsDto> GetDashboardStatsAsync();
    Task<IReadOnlyList<AdminUserDto>> GetUsersAsync(string? search, UserRole? role, int page = 1, int pageSize = 20);
    Task<int> GetUserCountAsync(string? search, UserRole? role);
    Task<AdminUserDto?> ToggleUserActiveAsync(Guid userId, bool isActive);
    Task<AdminUserDto?> VerifyDonorAsync(Guid userId, VerificationStatus status);
    Task<IReadOnlyList<AdminReportDto>> GetReportsAsync(ReportStatus? status, int page = 1, int pageSize = 20);
    Task<int> GetReportCountAsync(ReportStatus? status);
    Task<AdminReportDto?> ResolveReportAsync(Guid reportId, Guid adminId, ReportStatus status, string? resolution);
    Task<IReadOnlyList<AdminAuditLogDto>> GetAuditLogsAsync(string? entityType, int page = 1, int pageSize = 20);
    Task<int> GetAuditLogCountAsync(string? entityType);
    Task LogActionAsync(Guid? userId, string action, string entityType, Guid? entityId, string? ipAddress, string? metadata);
}
