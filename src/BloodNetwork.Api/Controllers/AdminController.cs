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

    [HttpGet("analytics")]
    public async Task<IActionResult> GetAnalytics()
    {
        var analytics = await _adminService.GetAnalyticsAsync();
        return Ok(analytics);
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsers([FromQuery] string? search, [FromQuery] UserRole? role, [FromQuery] bool? isActive, [FromQuery] int page = 1, [FromQuery][Range(1, 100)] int pageSize = 10)
    {
        var users = await _adminService.GetUsersAsync(search, role, isActive, page, pageSize);
        var total = await _adminService.GetUserCountAsync(search, role, isActive);
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
        var currentId = GetUserId();
        if (currentId.HasValue && currentId.Value == userId && !request.IsActive)
            return BadRequest(new { success = false, message = "You cannot deactivate your own account." });

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
    public async Task<IActionResult> GetReports([FromQuery] ReportStatus? status, [FromQuery] int page = 1, [FromQuery][Range(1, 100)] int pageSize = 10)
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

    [HttpGet("blood-requests")]
    public async Task<IActionResult> GetBloodRequests([FromQuery] RequestStatus? status, [FromQuery] BloodGroup? bloodGroup, [FromQuery] int page = 1, [FromQuery][Range(1, 100)] int pageSize = 10)
    {
        var requests = await _adminService.GetBloodRequestsAsync(status, bloodGroup, page, pageSize);
        var total = await _adminService.GetBloodRequestCountAsync(status, bloodGroup);
        return Ok(new PagedResult<BloodRequestDto>
        {
            Items = requests,
            TotalCount = total,
            Page = page,
            PageSize = pageSize
        });
    }

    [HttpGet("matches")]
    public async Task<IActionResult> GetMatches([FromQuery] DonorResponse? response, [FromQuery] int page = 1, [FromQuery][Range(1, 100)] int pageSize = 10)
    {
        var matches = await _adminService.GetMatchesAsync(response, page, pageSize);
        var total = await _adminService.GetMatchCountAsync(response);
        return Ok(new PagedResult<BloodRequestMatchDto>
        {
            Items = matches,
            TotalCount = total,
            Page = page,
            PageSize = pageSize
        });
    }

    [HttpGet("audit-logs")]
    public async Task<IActionResult> GetAuditLogs([FromQuery] string? entityType, [FromQuery] int page = 1, [FromQuery][Range(1, 100)] int pageSize = 10)
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

    [HttpGet("eligibility-questions")]
    public async Task<IActionResult> GetEligibilityQuestions()
    {
        var questions = await _adminService.GetEligibilityQuestionsAsync();
        return Ok(questions);
    }

    [HttpPost("eligibility-questions")]
    public async Task<IActionResult> CreateEligibilityQuestion([FromBody] SaveEligibilityQuestionRequest request)
    {
        if (request.QuestionType != "number" && request.QuestionType != "yesno")
            return BadRequest("questionType must be 'number' or 'yesno'");

        var result = await _adminService.CreateEligibilityQuestionAsync(request);

        await _adminService.LogActionAsync(
            GetUserId(), "CreateEligibilityQuestion", "EligibilityQuestion", result.Id,
            HttpContext.Connection.RemoteIpAddress?.ToString(), $"Created question: {result.QuestionEn}");

        return Ok(result);
    }

    [HttpPut("eligibility-questions/{questionId}")]
    public async Task<IActionResult> UpdateEligibilityQuestion(Guid questionId, [FromBody] SaveEligibilityQuestionRequest request)
    {
        if (request.QuestionType != "number" && request.QuestionType != "yesno")
            return BadRequest("questionType must be 'number' or 'yesno'");

        var result = await _adminService.UpdateEligibilityQuestionAsync(questionId, request);
        if (result == null) return NotFound();

        await _adminService.LogActionAsync(
            GetUserId(), "UpdateEligibilityQuestion", "EligibilityQuestion", questionId,
            HttpContext.Connection.RemoteIpAddress?.ToString(), $"Updated question: {result.QuestionEn}");

        return Ok(result);
    }

    [HttpPost("eligibility-questions/{questionId}/toggle-active")]
    public async Task<IActionResult> ToggleEligibilityQuestionActive(Guid questionId, [FromBody] ToggleEligibilityQuestionActiveRequest request)
    {
        var result = await _adminService.ToggleEligibilityQuestionActiveAsync(questionId, request.IsActive);
        if (result == null) return NotFound();

        await _adminService.LogActionAsync(
            GetUserId(), "ToggleEligibilityQuestionActive", "EligibilityQuestion", questionId,
            HttpContext.Connection.RemoteIpAddress?.ToString(), $"Set active={request.IsActive} for question {questionId}");

        return Ok(result);
    }

    [HttpDelete("eligibility-questions/{questionId}")]
    public async Task<IActionResult> DeleteEligibilityQuestion(Guid questionId)
    {
        var deleted = await _adminService.DeleteEligibilityQuestionAsync(questionId);
        if (!deleted) return NotFound();

        await _adminService.LogActionAsync(
            GetUserId(), "DeleteEligibilityQuestion", "EligibilityQuestion", questionId,
            HttpContext.Connection.RemoteIpAddress?.ToString(), $"Deleted question {questionId}");

        return NoContent();
    }

    private Guid? GetUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier) ?? User.FindFirst("sub") ?? User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub);
        if (claim == null || !Guid.TryParse(claim.Value, out var id)) return null;
        return id;
    }
}
