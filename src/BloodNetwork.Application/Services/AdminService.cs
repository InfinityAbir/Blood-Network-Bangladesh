using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Domain.Interfaces;

namespace BloodNetwork.Application.Services;

public class AdminService : IAdminService
{
    private readonly IRepository<User> _userRepo;
    private readonly IRepository<DonorProfile> _donorProfileRepo;
    private readonly IRepository<BloodRequest> _requestRepo;
    private readonly IRepository<BloodRequestMatch> _matchRepo;
    private readonly IRepository<Report> _reportRepo;
    private readonly IRepository<AuditLog> _auditLogRepo;
    private readonly IUnitOfWork _unitOfWork;

    public AdminService(
        IRepository<User> userRepo,
        IRepository<DonorProfile> donorProfileRepo,
        IRepository<BloodRequest> requestRepo,
        IRepository<BloodRequestMatch> matchRepo,
        IRepository<Report> reportRepo,
        IRepository<AuditLog> auditLogRepo,
        IUnitOfWork unitOfWork)
    {
        _userRepo = userRepo;
        _donorProfileRepo = donorProfileRepo;
        _requestRepo = requestRepo;
        _matchRepo = matchRepo;
        _reportRepo = reportRepo;
        _auditLogRepo = auditLogRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task<AdminDashboardStatsDto> GetDashboardStatsAsync()
    {
        var users = await _userRepo.GetAllAsync();
        var donorProfiles = await _donorProfileRepo.GetAllAsync();
        var requests = await _requestRepo.GetAllAsync();
        var matches = await _matchRepo.GetAllAsync();
        var reports = await _reportRepo.GetAllAsync();

        return new AdminDashboardStatsDto
        {
            TotalUsers = users.Count,
            TotalDonors = users.Count(u => u.Role == UserRole.Donor || u.Role == UserRole.Requester),
            TotalRequesters = users.Count(u => u.Role == UserRole.Requester),
            TotalBloodRequests = requests.Count,
            OpenBloodRequests = requests.Count(r => r.Status == RequestStatus.Open || r.Status == RequestStatus.PartiallyFulfilled),
            FulfilledBloodRequests = requests.Count(r => r.Status == RequestStatus.Fulfilled),
            TotalMatches = matches.Count,
            AcceptedMatches = matches.Count(m => m.DonorResponse == DonorResponse.Accepted),
            TotalReports = reports.Count,
            OpenReports = reports.Count(r => r.Status == ReportStatus.Open || r.Status == ReportStatus.UnderReview),
            PendingVerifications = donorProfiles.Count(d => d.VerificationStatus == VerificationStatus.Pending)
        };
    }

    public async Task<IReadOnlyList<AdminUserDto>> GetUsersAsync(string? search, UserRole? role, int page = 1, int pageSize = 20)
    {
        var allUsers = await _userRepo.GetAllAsync();
        var allProfiles = await _donorProfileRepo.GetAllAsync();
        var profileLookup = allProfiles.ToDictionary(p => p.UserId);

        var query = allUsers.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.ToLower();
            query = query.Where(u =>
                u.FirstName.ToLower().Contains(term) ||
                u.LastName.ToLower().Contains(term) ||
                u.PhoneNumber.Contains(term) ||
                (u.Email != null && u.Email.ToLower().Contains(term)));
        }

        if (role.HasValue)
            query = query.Where(u => u.Role == role.Value);

        var sorted = query.OrderByDescending(u => u.CreatedAt).ToList();

        return sorted
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(u =>
            {
                profileLookup.TryGetValue(u.Id, out var profile);
                return MapToUserDto(u, profile);
            })
            .ToList();
    }

    public async Task<int> GetUserCountAsync(string? search, UserRole? role)
    {
        var allUsers = await _userRepo.GetAllAsync();
        var query = allUsers.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.ToLower();
            query = query.Where(u =>
                u.FirstName.ToLower().Contains(term) ||
                u.LastName.ToLower().Contains(term) ||
                u.PhoneNumber.Contains(term) ||
                (u.Email != null && u.Email.ToLower().Contains(term)));
        }

        if (role.HasValue)
            query = query.Where(u => u.Role == role.Value);

        return query.Count();
    }

    public async Task<AdminUserDto?> ToggleUserActiveAsync(Guid userId, bool isActive)
    {
        var user = await _userRepo.GetByIdAsync(userId);
        if (user == null) return null;

        user.IsActive = isActive;
        user.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync();

        var profile = await _donorProfileRepo.FirstOrDefaultAsync(p => p.UserId == userId);
        return MapToUserDto(user, profile);
    }

    public async Task<AdminUserDto?> VerifyDonorAsync(Guid userId, VerificationStatus status)
    {
        var profile = await _donorProfileRepo.FirstOrDefaultAsync(p => p.UserId == userId);
        if (profile == null) return null;

        profile.VerificationStatus = status;
        profile.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync();

        var user = await _userRepo.GetByIdAsync(userId);
        return user != null ? MapToUserDto(user, profile) : null;
    }

    public async Task<IReadOnlyList<AdminReportDto>> GetReportsAsync(ReportStatus? status, int page = 1, int pageSize = 20)
    {
        var allReports = await _reportRepo.GetAllAsync();
        var allUsers = await _userRepo.GetAllAsync();
        var userLookup = allUsers.ToDictionary(u => u.Id);

        var query = allReports.AsEnumerable();
        if (status.HasValue)
            query = query.Where(r => r.Status == status.Value);

        var sorted = query.OrderByDescending(r => r.CreatedAt).ToList();

        return sorted
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(r =>
            {
                userLookup.TryGetValue(r.ReporterUserId, out var reporter);
                userLookup.TryGetValue(r.ReportedUserId, out var reported);
                userLookup.TryGetValue(r.ReviewedBy ?? Guid.Empty, out var reviewer);
                return MapToReportDto(r, reporter, reported, reviewer);
            })
            .ToList();
    }

    public async Task<int> GetReportCountAsync(ReportStatus? status)
    {
        var allReports = await _reportRepo.GetAllAsync();
        var query = allReports.AsEnumerable();
        if (status.HasValue)
            query = query.Where(r => r.Status == status.Value);
        return query.Count();
    }

    public async Task<AdminReportDto?> ResolveReportAsync(Guid reportId, Guid adminId, ReportStatus status, string? resolution)
    {
        var report = await _reportRepo.GetByIdAsync(reportId);
        if (report == null) return null;

        report.Status = status;
        report.ReviewedBy = adminId;
        report.Resolution = resolution;
        report.ResolvedAt = DateTime.UtcNow;
        report.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.SaveChangesAsync();

        var reporter = await _userRepo.GetByIdAsync(report.ReporterUserId);
        var reported = await _userRepo.GetByIdAsync(report.ReportedUserId);
        var reviewer = await _userRepo.GetByIdAsync(adminId);

        return MapToReportDto(report, reporter, reported, reviewer);
    }

    public async Task<IReadOnlyList<AdminAuditLogDto>> GetAuditLogsAsync(string? entityType, int page = 1, int pageSize = 20)
    {
        var allLogs = await _auditLogRepo.GetAllAsync();
        var allUsers = await _userRepo.GetAllAsync();
        var userLookup = allUsers.ToDictionary(u => u.Id);

        var query = allLogs.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(entityType))
            query = query.Where(l => l.EntityType == entityType);

        var sorted = query.OrderByDescending(l => l.CreatedAt).ToList();

        return sorted
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(l =>
            {
                userLookup.TryGetValue(l.UserId ?? Guid.Empty, out var user);
                return MapToAuditLogDto(l, user);
            })
            .ToList();
    }

    public async Task<int> GetAuditLogCountAsync(string? entityType)
    {
        var allLogs = await _auditLogRepo.GetAllAsync();
        var query = allLogs.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(entityType))
            query = query.Where(l => l.EntityType == entityType);
        return query.Count();
    }

    public async Task LogActionAsync(Guid? userId, string action, string entityType, Guid? entityId, string? ipAddress, string? metadata)
    {
        var log = new AuditLog
        {
            UserId = userId,
            Action = action,
            EntityType = entityType,
            EntityId = entityId,
            IpAddress = ipAddress,
            Metadata = metadata
        };

        await _auditLogRepo.AddAsync(log);
        await _unitOfWork.SaveChangesAsync();
    }

    private static AdminUserDto MapToUserDto(User user, DonorProfile? profile)
    {
        return new AdminUserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            Role = user.Role,
            IsActive = user.IsActive,
            IsPhoneVerified = user.IsPhoneVerified,
            LastLoginAt = user.LastLoginAt,
            CreatedAt = user.CreatedAt,
            DonorVerificationStatus = profile?.VerificationStatus.ToString()
        };
    }

    private static AdminReportDto MapToReportDto(Report report, User? reporter, User? reported, User? reviewer)
    {
        return new AdminReportDto
        {
            Id = report.Id,
            ReporterName = reporter != null ? $"{reporter.FirstName} {reporter.LastName}" : "Unknown",
            ReportedUserName = reported != null ? $"{reported.FirstName} {reported.LastName}" : "Unknown",
            BloodRequestId = report.BloodRequestId,
            Reason = report.Reason,
            Description = report.Description,
            Status = report.Status,
            ReviewedByName = reviewer != null ? $"{reviewer.FirstName} {reviewer.LastName}" : null,
            Resolution = report.Resolution,
            ResolvedAt = report.ResolvedAt,
            CreatedAt = report.CreatedAt
        };
    }

    private static AdminAuditLogDto MapToAuditLogDto(AuditLog log, User? user)
    {
        return new AdminAuditLogDto
        {
            Id = log.Id,
            UserName = user != null ? $"{user.FirstName} {user.LastName}" : null,
            Action = log.Action,
            EntityType = log.EntityType,
            EntityId = log.EntityId,
            IpAddress = log.IpAddress,
            Metadata = log.Metadata,
            CreatedAt = log.CreatedAt
        };
    }
}
