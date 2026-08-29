using System.ComponentModel.DataAnnotations;
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
        return Ok(result);
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
