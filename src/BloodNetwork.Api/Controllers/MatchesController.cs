using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BloodNetwork.Api.Controllers;

[ApiController]
[Route("api/matches")]
[Authorize]
public class MatchesController : ControllerBase
{
    private readonly IMatchingService _matchingService;
    private readonly IRepository<BloodRequest> _bloodRequestRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<DonorProfile> _donorProfileRepository;

    public MatchesController(
        IMatchingService matchingService,
        IRepository<BloodRequest> bloodRequestRepository,
        IRepository<User> userRepository,
        IRepository<DonorProfile> donorProfileRepository)
    {
        _matchingService = matchingService;
        _bloodRequestRepository = bloodRequestRepository;
        _userRepository = userRepository;
        _donorProfileRepository = donorProfileRepository;
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
        var dtos = await MapMatchesToDtosAsync(matches);
        return Ok(dtos);
    }

    [HttpGet("donor")]
    public async Task<IActionResult> GetMatchesForDonor()
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var matches = await _matchingService.GetMatchesForDonorAsync(userId.Value);
        var dtos = await MapMatchesToDtosAsync(matches);
        return Ok(dtos);
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

        var dtos = await MapMatchesToDtosAsync(new[] { match });
        return Ok(dtos.FirstOrDefault());
    }

    [HttpPost("{matchId}/respond")]
    public async Task<IActionResult> RespondToMatch(Guid matchId, [FromBody] RespondToMatchRequest request)
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var match = await _matchingService.RespondToMatchAsync(matchId, userId.Value, request.Response);
        if (match == null) return NotFound();

        var dtos = await MapMatchesToDtosAsync(new[] { match });
        return Ok(dtos.FirstOrDefault());
    }

    [HttpPost("request/{requestId}/trigger-match")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> TriggerMatching(Guid requestId)
    {
        var matches = await _matchingService.MatchRequestAsync(requestId);
        var dtos = await MapMatchesToDtosAsync(matches);
        return Ok(new { MatchCount = dtos.Count, Matches = dtos });
    }

    private Guid? GetUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier);
        return claim != null ? Guid.Parse(claim.Value) : null;
    }

    private async Task<List<BloodRequestMatchDto>> MapMatchesToDtosAsync(IReadOnlyList<BloodRequestMatch> matches)
    {
        if (matches.Count == 0) return new List<BloodRequestMatchDto>();

        var donorIds = matches.Select(m => m.DonorId).Distinct().ToList();

        var users = await _userRepository.Query()
            .Where(u => donorIds.Contains(u.Id))
            .Select(u => new { u.Id, u.FirstName, u.LastName, u.PhoneNumber })
            .ToListAsync();

        var profiles = await _donorProfileRepository.Query()
            .Where(p => donorIds.Contains(p.UserId))
            .Select(p => new { p.UserId, p.BloodGroup })
            .ToListAsync();

        var userLookup = users.ToDictionary(u => u.Id);
        var profileLookup = profiles.ToDictionary(p => p.UserId);

        return matches.Select(match =>
        {
            userLookup.TryGetValue(match.DonorId, out var user);
            profileLookup.TryGetValue(match.DonorId, out var profile);

            return new BloodRequestMatchDto
            {
                Id = match.Id,
                BloodRequestId = match.BloodRequestId,
                DonorId = match.DonorId,
                DonorName = user != null ? $"{user.FirstName} {user.LastName}" : "Unknown",
                DonorPhone = user?.PhoneNumber ?? string.Empty,
                DonorBloodGroup = profile?.BloodGroup.ToString() ?? "Unknown",
                MatchScore = match.MatchScore,
                DistanceKm = match.DistanceKm,
                DonorResponse = match.DonorResponse,
                ContactedAt = match.ContactedAt,
                RespondedAt = match.RespondedAt,
                AcceptedAt = match.AcceptedAt,
                DeclinedAt = match.DeclinedAt,
                CreatedAt = match.CreatedAt
            };
        }).ToList();
    }
}
