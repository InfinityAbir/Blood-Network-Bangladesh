using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BloodNetwork.Api.Controllers;

[ApiController]
[Route("api/matches")]
[Authorize]
public class MatchesController : ControllerBase
{
    private readonly IMatchingService _matchingService;
    private readonly IRepository<BloodRequest> _bloodRequestRepository;

    public MatchesController(
        IMatchingService matchingService,
        IRepository<BloodRequest> bloodRequestRepository)
    {
        _matchingService = matchingService;
        _bloodRequestRepository = bloodRequestRepository;
    }

    [HttpGet("request/{requestId}")]
    public async Task<IActionResult> GetMatchesForRequest(Guid requestId)
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var bloodRequest = await _bloodRequestRepository.GetByIdAsync(requestId);
        if (bloodRequest == null) return NotFound();

        var isOwner = bloodRequest.RequesterId == userId.Value;
        var isAdmin = User.IsInRole("Admin");

        if (!isOwner && !isAdmin)
            return Forbid();

        var matches = await _matchingService.GetMatchesForRequestAsync(requestId);
        return Ok(matches.Select(MapToDto));
    }

    [HttpGet("donor")]
    public async Task<IActionResult> GetMatchesForDonor()
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var matches = await _matchingService.GetMatchesForDonorAsync(userId.Value);
        return Ok(matches.Select(MapToDto));
    }

    [HttpGet("{matchId}")]
    public async Task<IActionResult> GetMatch(Guid matchId)
    {
        var match = await _matchingService.GetMatchByIdAsync(matchId);
        if (match == null) return NotFound();

        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        if (match.DonorId != userId.Value && !User.IsInRole("Admin"))
        {
            var bloodRequest = await _bloodRequestRepository.GetByIdAsync(match.BloodRequestId);
            if (bloodRequest == null || bloodRequest.RequesterId != userId.Value)
                return Forbid();
        }

        return Ok(MapToDto(match));
    }

    [HttpPost("{matchId}/respond")]
    public async Task<IActionResult> RespondToMatch(Guid matchId, [FromBody] RespondToMatchRequest request)
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var match = await _matchingService.RespondToMatchAsync(matchId, userId.Value, request.Response);
        if (match == null) return NotFound();

        return Ok(MapToDto(match));
    }

    [HttpPost("request/{requestId}/trigger-match")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> TriggerMatching(Guid requestId)
    {
        var matches = await _matchingService.MatchRequestAsync(requestId);
        return Ok(new { MatchCount = matches.Count, Matches = matches.Select(MapToDto) });
    }

    private Guid? GetUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier);
        return claim != null ? Guid.Parse(claim.Value) : null;
    }

    private static BloodRequestMatchDto MapToDto(BloodRequestMatch match)
    {
        return new BloodRequestMatchDto
        {
            Id = match.Id,
            BloodRequestId = match.BloodRequestId,
            DonorId = match.DonorId,
            DonorName = match.Donor is not null ? $"{match.Donor.FirstName} {match.Donor.LastName}" : string.Empty,
            DonorPhone = match.Donor?.PhoneNumber ?? string.Empty,
            DonorBloodGroup = match.Donor?.DonorProfile?.BloodGroup.ToString() ?? string.Empty,
            MatchScore = match.MatchScore,
            DistanceKm = match.DistanceKm,
            DonorResponse = match.DonorResponse,
            ContactedAt = match.ContactedAt,
            RespondedAt = match.RespondedAt,
            AcceptedAt = match.AcceptedAt,
            DeclinedAt = match.DeclinedAt,
            CreatedAt = match.CreatedAt
        };
    }
}
