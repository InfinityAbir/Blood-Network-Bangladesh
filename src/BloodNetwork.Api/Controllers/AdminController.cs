using System.ComponentModel.DataAnnotations;
using BloodNetwork.Application.Common;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BloodNetwork.Api.Controllers;

[ApiController]
[Route("api/admin")]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboardStats()
    {
        var stats = await _adminService.GetDashboardStatsAsync();
        return Ok(stats);
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsers([FromQuery] string? search, [FromQuery] UserRole? role, [FromQuery] int page = 1, [FromQuery][Range(1, 50)] int pageSize = 20)
    {
        var users = await _adminService.GetUsersAsync(search, role, page, pageSize);
        var total = await _adminService.GetUserCountAsync(search, role);
        return Ok(new PagedResult<AdminUserDto>
        {
            Items = users,
            TotalCount = total,
            Page = page,
            PageSize = pageSize
        });
    }

    [HttpPost("users/{userId}/toggle-active")]
    public async Task<IActionResult> ToggleUserActive(Guid userId, [FromBody] ToggleUserActiveRequest request)
    {
        var result = await _adminService.ToggleUserActiveAsync(userId, request.IsActive);
        if (result == null) return NotFound();

        await _adminService.LogActionAsync(
            GetUserId(),
            "ToggleUserActive",
            "User",
            userId,
            HttpContext.Connection.RemoteIpAddress?.ToString(),
            $"Toggled active status to {request.IsActive} for user {userId}");

        return Ok(result);
    }

    [HttpPost("users/{userId}/verify-donor")]
    public async Task<IActionResult> VerifyDonor(Guid userId, [FromBody] VerifyDonorRequest request)
    {
        var result = await _adminService.VerifyDonorAsync(userId, request.Status);
        if (result == null) return NotFound();

        await _adminService.LogActionAsync(
            GetUserId(),
            "VerifyDonor",
            "DonorProfile",
            userId,
            HttpContext.Connection.RemoteIpAddress?.ToString(),
            $"Set verification status to {request.Status} for user {userId}");

        return Ok(result);
    }

    [HttpGet("reports")]
    public async Task<IActionResult> GetReports([FromQuery] ReportStatus? status, [FromQuery] int page = 1, [FromQuery][Range(1, 50)] int pageSize = 20)
    {
        var reports = await _adminService.GetReportsAsync(status, page, pageSize);
        var total = await _adminService.GetReportCountAsync(status);
        return Ok(new PagedResult<AdminReportDto>
        {
            Items = reports,
            TotalCount = total,
            Page = page,
            PageSize = pageSize
        });
    }

    [HttpPost("reports/{reportId}/resolve")]
    public async Task<IActionResult> ResolveReport(Guid reportId, [FromBody] ResolveReportRequest request)
    {
        var adminId = GetUserId();
        if (adminId == null) return Unauthorized();

        var result = await _adminService.ResolveReportAsync(reportId, adminId.Value, request.Status, request.Resolution);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("audit-logs")]
    public async Task<IActionResult> GetAuditLogs([FromQuery] string? entityType, [FromQuery] int page = 1, [FromQuery][Range(1, 50)] int pageSize = 20)
    {
        var logs = await _adminService.GetAuditLogsAsync(entityType, page, pageSize);
        var total = await _adminService.GetAuditLogCountAsync(entityType);
        return Ok(new PagedResult<AdminAuditLogDto>
        {
            Items = logs,
            TotalCount = total,
            Page = page,
            PageSize = pageSize
        });
    }

    private Guid? GetUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier) ?? User.FindFirst("sub") ?? User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub);
        if (claim == null || !Guid.TryParse(claim.Value, out var id)) return null;
        return id;
    }
}
