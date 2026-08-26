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
        var dtos = new List<BloodRequestMatchDto>();
        foreach (var match in matches)
        {
            var dto = await MapToDto(match);
            if (dto != null) dtos.Add(dto);
        }
        return Ok(dtos);
    }

    [HttpGet("donor")]
    public async Task<IActionResult> GetMatchesForDonor()
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var matches = await _matchingService.GetMatchesForDonorAsync(userId.Value);
        var dtos = new List<BloodRequestMatchDto>();
        foreach (var match in matches)
        {
            var dto = await MapToDto(match);
            if (dto != null) dtos.Add(dto);
        }
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

        return Ok(await MapToDto(match));
    }

    [HttpPost("{matchId}/respond")]
    public async Task<IActionResult> RespondToMatch(Guid matchId, [FromBody] RespondToMatchRequest request)
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        var match = await _matchingService.RespondToMatchAsync(matchId, userId.Value, request.Response);
        if (match == null) return NotFound();

        return Ok(await MapToDto(match));
    }

    [HttpPost("request/{requestId}/trigger-match")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> TriggerMatching(Guid requestId)
    {
        var matches = await _matchingService.MatchRequestAsync(requestId);
        var dtos = new List<BloodRequestMatchDto>();
        foreach (var match in matches)
        {
            var dto = await MapToDto(match);
            if (dto != null) dtos.Add(dto);
        }
        return Ok(new { MatchCount = dtos.Count, Matches = dtos });
    }

    private Guid? GetUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier);
        return claim != null ? Guid.Parse(claim.Value) : null;
    }

    private async Task<BloodRequestMatchDto?> MapToDto(BloodRequestMatch match)
    {
        if (match == null) return null;

        var donor = await _userRepository.GetByIdAsync(match.DonorId);
        var donorProfile = (await _donorProfileRepository.GetAllAsync())
            .FirstOrDefault(d => d.UserId == match.DonorId);

        return new BloodRequestMatchDto
        {
            Id = match.Id,
            BloodRequestId = match.BloodRequestId,
            DonorId = match.DonorId,
            DonorName = donor != null ? $"{donor.FirstName} {donor.LastName}" : "Unknown",
            DonorPhone = donor?.PhoneNumber ?? string.Empty,
            DonorBloodGroup = donorProfile?.BloodGroup.ToString() ?? "Unknown",
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
