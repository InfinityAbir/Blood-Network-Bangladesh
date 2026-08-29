using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodNetwork.Api.Controllers;

[ApiController]
[Route("api/ai")]
[Authorize]
public class AIController : ControllerBase
{
    private readonly IEligibilityService _eligibilityService;
    private readonly IDonorEngagementService _donorEngagementService;
    private readonly IMatchEnhancementService _matchEnhancementService;
    private readonly IMatchingService _matchingService;

    public AIController(
        IEligibilityService eligibilityService,
        IDonorEngagementService donorEngagementService,
        IMatchEnhancementService matchEnhancementService,
        IMatchingService matchingService)
    {
        _eligibilityService = eligibilityService;
        _donorEngagementService = donorEngagementService;
        _matchEnhancementService = matchEnhancementService;
        _matchingService = matchingService;
    }

    [HttpGet("eligibility/questions")]
    [AllowAnonymous]
    public async Task<IActionResult> GetEligibilityQuestions()
    {
        var questions = await _eligibilityService.GetQuestionsAsync();
        return Ok(questions);
    }

    [HttpPost("eligibility/check")]
    [AllowAnonymous]
    public async Task<IActionResult> CheckEligibility([FromBody] List<EligibilityAnswerDto> answers)
    {
        var result = await _eligibilityService.EvaluateAnswersAsync(answers);
        // Persist per-user so the same user sees saved answers+result after logout/login
        // (anonymous checks stay device-local; authenticated checks are stored server-side per userId).
        var userId = GetCurrentUserIdOrNull();
        if (userId.HasValue)
        {
            await _eligibilityService.SaveStateAsync(userId.Value, answers, result);
        }
        return Ok(result);
    }

    [HttpGet("eligibility/state")]
    [Authorize]
    public async Task<IActionResult> GetEligibilityState()
    {
        var userId = GetCurrentUserIdOrNull();
        if (!userId.HasValue) return Unauthorized();
        var state = await _eligibilityService.GetStateAsync(userId.Value);
        if (state == null) return NoContent();
        return Ok(state);
    }

    [HttpDelete("eligibility/state")]
    [Authorize]
    public async Task<IActionResult> ClearEligibilityState()
    {
        var userId = GetCurrentUserIdOrNull();
        if (!userId.HasValue) return Unauthorized();
        await _eligibilityService.ClearStateAsync(userId.Value);
        return NoContent();
    }

    private Guid? GetCurrentUserIdOrNull()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier) ?? User.FindFirst("sub");
        return claim != null && Guid.TryParse(claim.Value, out var id) ? id : null;
    }

    [HttpGet("donors/re-engagement")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetTopEngagedDonors(
        [FromQuery] BloodGroup? bloodGroup,
        [FromQuery][Range(1, 50)] int count = 10)
    {
        if (!bloodGroup.HasValue)
            return BadRequest("BloodGroup is required");
        var donors = await _donorEngagementService.GetTopEngagedDonorsAsync(bloodGroup.Value, count);
        return Ok(donors);
    }

    [HttpGet("donors/re-engagement/{donorId:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetDonorEngagement(Guid donorId)
    {
        var result = await _donorEngagementService.GetDonorEngagementAsync(donorId);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("matches/enhanced/{requestId:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetEnhancedMatches(Guid requestId)
    {
        var rawMatches = await _matchingService.GetMatchesForRequestAsync(requestId);
        if (rawMatches.Count == 0) return Ok(Array.Empty<EnhancedMatchDto>());

        var enhanced = await _matchEnhancementService.GetEnhancedMatchesAsync(requestId, rawMatches);
        return Ok(enhanced);
    }
}
