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
        var totalUsers = await _userRepo.CountAsync();
        var totalDonors = await _userRepo.CountAsync(u => u.Role == UserRole.Donor);
        var totalRequesters = await _userRepo.CountAsync(u => u.Role == UserRole.Requester);
        var totalBloodRequests = await _requestRepo.CountAsync();
        var openBloodRequests = await _requestRepo.CountAsync(r => r.Status == RequestStatus.Open || r.Status == RequestStatus.PartiallyFulfilled);
        var fulfilledBloodRequests = await _requestRepo.CountAsync(r => r.Status == RequestStatus.Fulfilled);
        var totalMatches = await _matchRepo.CountAsync();
        var acceptedMatches = await _matchRepo.CountAsync(m => m.DonorResponse == DonorResponse.Accepted);
        var totalReports = await _reportRepo.CountAsync();
        var openReports = await _reportRepo.CountAsync(r => r.Status == ReportStatus.Open || r.Status == ReportStatus.UnderReview);
        var pendingVerifications = await _donorProfileRepo.CountAsync(d => d.VerificationStatus == VerificationStatus.Pending);

        return new AdminDashboardStatsDto
        {
            TotalUsers = totalUsers,
            TotalDonors = totalDonors,
            TotalRequesters = totalRequesters,
            TotalBloodRequests = totalBloodRequests,
            OpenBloodRequests = openBloodRequests,
            FulfilledBloodRequests = fulfilledBloodRequests,
            TotalMatches = totalMatches,
            AcceptedMatches = acceptedMatches,
            TotalReports = totalReports,
            OpenReports = openReports,
            PendingVerifications = pendingVerifications
        };
    }

    public async Task<IReadOnlyList<AdminUserDto>> GetUsersAsync(string? search, UserRole? role, int page = 1, int pageSize = 20)
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

        var sorted = query.OrderByDescending(u => u.CreatedAt).ToList();
        var pagedUsers = sorted.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        var pagedIds = pagedUsers.Select(u => u.Id).ToList();
        var profiles = await _donorProfileRepo.FindAsync(p => pagedIds.Contains(p.UserId));
        var profileLookup = profiles.ToDictionary(p => p.UserId);

        return pagedUsers
            .Select(u =>
            {
                profileLookup.TryGetValue(u.Id, out var profile);
                return MapToUserDto(u, profile);
            })
            .ToList();
    }

    public async Task<int> GetUserCountAsync(string? search, UserRole? role)
    {
        if (string.IsNullOrWhiteSpace(search))
        {
            return role.HasValue
                ? await _userRepo.CountAsync(u => u.Role == role.Value)
                : await _userRepo.CountAsync();
        }

        var allUsers = await _userRepo.GetAllAsync();
        var term = search.ToLower();
        return allUsers.Count(u =>
            (u.FirstName.ToLower().Contains(term) ||
             u.LastName.ToLower().Contains(term) ||
             u.PhoneNumber.Contains(term) ||
             (u.Email != null && u.Email.ToLower().Contains(term))) &&
            (!role.HasValue || u.Role == role.Value));
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

        var query = allReports.AsEnumerable();
        if (status.HasValue)
            query = query.Where(r => r.Status == status.Value);

        var sorted = query.OrderByDescending(r => r.CreatedAt).ToList();
        var pagedReports = sorted.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        var userIds = pagedReports
            .SelectMany(r => new[] { r.ReporterUserId, r.ReportedUserId, r.ReviewedBy ?? Guid.Empty })
            .Where(id => id != Guid.Empty)
            .Distinct()
            .ToList();
        var users = await _userRepo.FindAsync(u => userIds.Contains(u.Id));
        var userLookup = users.ToDictionary(u => u.Id);

        return pagedReports
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
        return status.HasValue
            ? await _reportRepo.CountAsync(r => r.Status == status.Value)
            : await _reportRepo.CountAsync();
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

        var query = allLogs.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(entityType))
            query = query.Where(l => l.EntityType == entityType);

        var sorted = query.OrderByDescending(l => l.CreatedAt).ToList();
        var pagedLogs = sorted.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        var userIds = pagedLogs
            .Select(l => l.UserId)
            .Where(id => id.HasValue)
            .Select(id => id!.Value)
            .Distinct()
            .ToList();
        var users = await _userRepo.FindAsync(u => userIds.Contains(u.Id));
        var userLookup = users.ToDictionary(u => u.Id);

        return pagedLogs
            .Select(l =>
            {
                userLookup.TryGetValue(l.UserId ?? Guid.Empty, out var user);
                return MapToAuditLogDto(l, user);
            })
            .ToList();
    }

    public async Task<int> GetAuditLogCountAsync(string? entityType)
    {
        return !string.IsNullOrWhiteSpace(entityType)
            ? await _auditLogRepo.CountAsync(l => l.EntityType == entityType)
            : await _auditLogRepo.CountAsync();
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
