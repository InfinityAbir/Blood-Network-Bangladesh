using System.Security.Claims;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodNetwork.Api.Controllers;

[ApiController]
[Route("api/push/tokens")]
[Authorize]
public class PushTokensController : ControllerBase
{
    private readonly DeviceTokenService _tokenService;

    public PushTokensController(DeviceTokenService tokenService)
    {
        _tokenService = tokenService;
    }

    private Guid GetCurrentUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier) ?? User.FindFirst("sub");
        return claim is not null && Guid.TryParse(claim.Value, out var userId) ? userId : Guid.Empty;
    }

    /// <summary>Upserts the caller's device token (e.g. FCM token) for push delivery.</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterPushTokenRequest request, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        if (userId == Guid.Empty)
            return Unauthorized(new { success = false, message = "Invalid token" });

        var result = await _tokenService.RegisterAsync(userId, request, cancellationToken);
        return result.IsSuccess
            ? Ok(new { success = true })
            : BadRequest(new { success = false, message = result.Error });
    }

    /// <summary>Removes a device token (logout / uninstall cleanup).</summary>
    [HttpDelete("{token}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Remove(string token, CancellationToken cancellationToken)
    {
        var userId = GetCurrentUserId();
        if (userId == Guid.Empty)
            return Unauthorized(new { success = false, message = "Invalid token" });

        var result = await _tokenService.RemoveAsync(userId, Uri.UnescapeDataString(token), cancellationToken);
        return result.IsSuccess
            ? NoContent()
            : NotFound(new { success = false, message = result.Error });
    }
}