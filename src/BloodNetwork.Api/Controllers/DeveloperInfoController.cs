using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodNetwork.Api.Controllers;

[ApiController]
[Route("api/developer-info")]
public class DeveloperInfoController : ControllerBase
{
    private readonly IDeveloperInfoService _service;

    public DeveloperInfoController(IDeveloperInfoService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Get()
    {
        var info = await _service.GetAsync();
        return Ok(info);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromBody] UpdateDeveloperInfoRequest request)
    {
        var updated = await _service.UpdateAsync(request);
        return Ok(updated);
    }
}
