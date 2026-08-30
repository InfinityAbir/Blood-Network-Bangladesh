using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using BloodNetwork.Application.Common;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Services;
using BloodNetwork.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace BloodNetwork.Api.Controllers;

[ApiController]
[Route("api/blood-requests")]
public class BloodRequestsController : ControllerBase
{
    private readonly BloodRequestService _requestService;

    public BloodRequestsController(BloodRequestService requestService)
    {
        _requestService = requestService;
    }

    private Guid GetCurrentUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier) ?? User.FindFirst("sub");
        return claim is not null && Guid.TryParse(claim.Value, out var userId) ? userId : Guid.Empty;
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(typeof(BloodRequestDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateRequest([FromBody] CreateBloodRequestRequest request, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        if (userId == Guid.Empty)
            return Unauthorized(new { success = false, message = "Invalid token" });

        var result = await _requestService.CreateRequestAsync(userId, request, cancellationToken);

        if (result.IsSuccess)
            return CreatedAtAction(nameof(GetRequest), new { id = result.Value!.Id }, result.Value);

        return BadRequest(new { success = false, message = result.Error });
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    [ProducesResponseType(typeof(BloodRequestDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(PublicBloodRequestDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(object), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetRequest(Guid id, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        var isAdmin = User.IsInRole("Admin");

        var result = await _requestService.GetRequestByIdAsync(id, cancellationToken);

        if (!result.IsSuccess)
            return NotFound(new { success = false, message = result.Error });

        if (!isAdmin && result.Value!.RequesterId != userId)
        {
            var fullDto = result.Value!;
            var publicDto = new PublicBloodRequestDto(
                fullDto.Id,
                fullDto.BloodGroup,
                fullDto.UnitsRequired,
                fullDto.UnitsFulfilled,
                fullDto.HospitalName,
                fullDto.HospitalAddress,
                fullDto.DistrictId,
                fullDto.DistrictName,
                fullDto.UpazilaId,
                fullDto.UpazilaName,
                fullDto.Area,
                fullDto.RequiredBy,
                fullDto.Urgency,
                fullDto.AdditionalInformation,
                fullDto.Status,
                fullDto.CreatedAt
            );
            return Ok(publicDto);
        }

        return Ok(result.Value);
    }

    [HttpGet("my")]
    [Authorize]
    [ProducesResponseType(typeof(PagedResult<BloodRequestDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMyRequests(
        [FromQuery] RequestStatus? status,
        [FromQuery] int page = 1,
        [FromQuery][Range(1, 50)] int pageSize = 20,
        CancellationToken cancellationToken = default)
    {
        var userId = GetCurrentUserId();
        if (userId == Guid.Empty)
            return Unauthorized(new { success = false, message = "Invalid token" });

        var result = await _requestService.GetMyRequestsAsync(userId, status, page, pageSize, cancellationToken);

        if (result.IsSuccess)
            return Ok(result.Value);

        return BadRequest(new { success = false, message = result.Error });
    }

    [HttpGet("open")]
    [EnableRateLimiting("search")]
    [ProducesResponseType(typeof(PagedResult<PublicBloodRequestDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchOpenRequests([FromQuery] BloodRequestSearchRequest request, CancellationToken cancellationToken)
    {
        var result = await _requestService.SearchOpenRequestsAsync(request, cancellationToken);

        if (result.IsSuccess)
            return Ok(result.Value);

        return BadRequest(new { success = false, message = result.Error });
    }

    [HttpPatch("{id:guid}")]
    [Authorize]
    [ProducesResponseType(typeof(BloodRequestDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateRequest(Guid id, [FromBody] UpdateBloodRequestRequest request, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        if (userId == Guid.Empty)
            return Unauthorized(new { success = false, message = "Invalid token" });

        var isAdmin = User.IsInRole("Admin");
        var result = await _requestService.UpdateRequestAsync(id, userId, isAdmin, request, cancellationToken);

        if (result.IsSuccess)
            return Ok(result.Value);

        return BadRequest(new { success = false, message = result.Error });
    }

    [HttpPatch("{id:guid}/cancel")]
    [Authorize]
    [ProducesResponseType(typeof(BloodRequestDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CancelRequest(Guid id, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        if (userId == Guid.Empty)
            return Unauthorized(new { success = false, message = "Invalid token" });

        var result = await _requestService.CancelRequestAsync(id, userId, cancellationToken);

        if (result.IsSuccess)
            return Ok(result.Value);

        if (result.IsNotFound)
            return NotFound(new { success = false, message = "Blood request not found" });

        return BadRequest(new { success = false, message = result.Error });
    }

    [HttpPatch("{id:guid}/fulfill")]
    [Authorize]
    [ProducesResponseType(typeof(BloodRequestDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> FulfillRequest(Guid id, [FromBody] FulfillBloodRequestRequest request, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        if (userId == Guid.Empty)
            return Unauthorized(new { success = false, message = "Invalid token" });

        if (request.UnitsFulfilled <= 0)
            return BadRequest(new { success = false, message = "Units fulfilled must be at least 1" });

        if (request.UnitsFulfilled > 10)
            return BadRequest(new { success = false, message = "Cannot fulfill more than 10 units at once" });

        var result = await _requestService.UpdateFulfilledUnitsAsync(id, userId, request.UnitsFulfilled, cancellationToken);

        if (result.IsSuccess)
            return Ok(result.Value);

        if (result.IsNotFound)
            return NotFound(new { success = false, message = "Blood request not found" });

        return BadRequest(new { success = false, message = result.Error });
    }
}
