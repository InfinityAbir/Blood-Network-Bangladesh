using System.Security.Claims;
using BloodNetwork.Application.Common;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace BloodNetwork.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DonorsController : ControllerBase
{
    private readonly DonorService _donorService;

    public DonorsController(DonorService donorService)
    {
        _donorService = donorService;
    }

    private Guid GetCurrentUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier) ?? User.FindFirst("sub");
        return claim is not null && Guid.TryParse(claim.Value, out var userId) ? userId : Guid.Empty;
    }

    [HttpPost("me/profile")]
    [Authorize]
    [ProducesResponseType(typeof(DonorProfileDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProfile([FromBody] CreateDonorProfileRequest request, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        if (userId == Guid.Empty)
            return Unauthorized(new { success = false, message = "Invalid token" });

        var result = await _donorService.CreateProfileAsync(userId, request, cancellationToken);

        if (result.IsSuccess)
            return CreatedAtAction(nameof(GetMyProfile), new { }, result.Value);

        return BadRequest(new { success = false, message = result.Error });
    }

    [HttpPut("me/profile")]
    [Authorize]
    [ProducesResponseType(typeof(DonorProfileDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateDonorProfileRequest request, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        if (userId == Guid.Empty)
            return Unauthorized(new { success = false, message = "Invalid token" });

        var result = await _donorService.UpdateProfileAsync(userId, request, cancellationToken);

        if (result.IsSuccess)
            return Ok(result.Value);

        return NotFound(new { success = false, message = result.Error });
    }

    [HttpGet("me/profile")]
    [Authorize]
    [ProducesResponseType(typeof(DonorProfileDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMyProfile(CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        if (userId == Guid.Empty)
            return Unauthorized(new { success = false, message = "Invalid token" });

        var result = await _donorService.GetMyProfileAsync(userId, cancellationToken);

        if (result.IsSuccess)
            return Ok(result.Value);

        return NotFound(new { success = false, message = result.Error });
    }

    [HttpPatch("me/availability")]
    [Authorize]
    [ProducesResponseType(typeof(DonorProfileDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ToggleAvailability([FromBody] ToggleAvailabilityRequest request, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        if (userId == Guid.Empty)
            return Unauthorized(new { success = false, message = "Invalid token" });

        var result = await _donorService.ToggleAvailabilityAsync(userId, request, cancellationToken);

        if (result.IsSuccess)
            return Ok(result.Value);

        return BadRequest(new { success = false, message = result.Error });
    }

    [HttpGet("search")]
    [EnableRateLimiting("search")]
    [ProducesResponseType(typeof(PagedResult<PublicDonorDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchDonors([FromQuery] DonorSearchRequest request, CancellationToken cancellationToken)
    {
        var result = await _donorService.SearchDonorsAsync(request, cancellationToken);

        if (result.IsSuccess)
            return Ok(result.Value);

        return BadRequest(new { success = false, message = result.Error });
    }
}
