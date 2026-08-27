using BloodNetwork.Application.DTOs;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BloodNetwork.Api.Controllers;

[ApiController]
[Route("api/reports")]
[Authorize]
public class ReportsController : ControllerBase
{
    private readonly IRepository<Report> _reportRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<BloodRequest> _bloodRequestRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReportsController(
        IRepository<Report> reportRepository,
        IRepository<User> userRepository,
        IRepository<BloodRequest> bloodRequestRepository,
        IUnitOfWork unitOfWork)
    {
        _reportRepository = reportRepository;
        _userRepository = userRepository;
        _bloodRequestRepository = bloodRequestRepository;
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> CreateReport([FromBody] CreateReportRequest request, CancellationToken cancellationToken)
    {
        var userId = GetUserId();
        if (userId == null) return Unauthorized();

        if (string.IsNullOrWhiteSpace(request.Reason))
            return BadRequest(new { message = "Reason is required." });

        var reportedUser = await _userRepository.GetByIdAsync(request.ReportedUserId, cancellationToken);
        if (reportedUser == null)
            return BadRequest(new { message = "Reported user not found." });

        if (request.ReportedUserId == userId.Value)
            return BadRequest(new { message = "You cannot report yourself." });

        if (request.BloodRequestId.HasValue)
        {
            var bloodRequest = await _bloodRequestRepository.GetByIdAsync(request.BloodRequestId.Value, cancellationToken);
            if (bloodRequest == null)
                return BadRequest(new { message = "Blood request not found." });
        }

        var report = new Report
        {
            ReporterUserId = userId.Value,
            ReportedUserId = request.ReportedUserId,
            BloodRequestId = request.BloodRequestId,
            Reason = request.Reason,
            Description = request.Description,
            Status = ReportStatus.Open
        };

        await _reportRepository.AddAsync(report, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Ok(new { message = "Report submitted successfully. Our team will review it." });
    }

    private Guid? GetUserId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier) ?? User.FindFirst("sub");
        if (claim == null || !Guid.TryParse(claim.Value, out var id)) return null;
        return id;
    }
}
