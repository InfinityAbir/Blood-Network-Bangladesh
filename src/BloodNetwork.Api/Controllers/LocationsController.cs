using BloodNetwork.Application.DTOs;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BloodNetwork.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly IRepository<Division> _divisionRepository;
    private readonly IRepository<District> _districtRepository;
    private readonly IRepository<Upazila> _upazilaRepository;

    public LocationsController(
        IRepository<Division> divisionRepository,
        IRepository<District> districtRepository,
        IRepository<Upazila> upazilaRepository)
    {
        _divisionRepository = divisionRepository;
        _districtRepository = districtRepository;
        _upazilaRepository = upazilaRepository;
    }

    [HttpGet("divisions")]
    [ProducesResponseType(typeof(List<DivisionDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDivisions(CancellationToken cancellationToken)
    {
        var divisions = await _divisionRepository.GetAllAsync(cancellationToken);
        var dtos = divisions.Select(d => new DivisionDto(d.Id, d.Name, d.NameBn)).ToList();
        return Ok(dtos);
    }

    [HttpGet("districts")]
    [ProducesResponseType(typeof(List<DistrictDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDistricts([FromQuery] Guid? divisionId, CancellationToken cancellationToken)
    {
        IReadOnlyList<District> districts;
        if (divisionId.HasValue)
            districts = await _districtRepository.FindAsync(d => d.DivisionId == divisionId.Value, cancellationToken);
        else
            districts = await _districtRepository.GetAllAsync(cancellationToken);

        var dtos = districts.Select(d => new DistrictDto(d.Id, d.DivisionId, d.Name, d.NameBn)).ToList();
        return Ok(dtos);
    }

    [HttpGet("upazilas")]
    [ProducesResponseType(typeof(List<UpazilaDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUpazilas([FromQuery] Guid? districtId, CancellationToken cancellationToken)
    {
        IReadOnlyList<Upazila> upazilas;
        if (districtId.HasValue)
            upazilas = await _upazilaRepository.FindAsync(u => u.DistrictId == districtId.Value, cancellationToken);
        else
            upazilas = await _upazilaRepository.GetAllAsync(cancellationToken);

        var dtos = upazilas.Select(u => new UpazilaDto(u.Id, u.DistrictId, u.Name, u.NameBn)).ToList();
        return Ok(dtos);
    }
}

public record DivisionDto(Guid Id, string Name, string NameBn);
public record DistrictDto(Guid Id, Guid DivisionId, string Name, string NameBn);
public record UpazilaDto(Guid Id, Guid DistrictId, string Name, string NameBn);
