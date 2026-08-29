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
    private readonly IRepository<District> _districtRepo;
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationService _notificationService;

    public AdminService(
        IRepository<User> userRepo,
        IRepository<DonorProfile> donorProfileRepo,
        IRepository<BloodRequest> requestRepo,
        IRepository<BloodRequestMatch> matchRepo,
        IRepository<Report> reportRepo,
        IRepository<AuditLog> auditLogRepo,
        IRepository<District> districtRepo,
        IUnitOfWork unitOfWork,
        INotificationService notificationService)
    {
        _userRepo = userRepo;
        _donorProfileRepo = donorProfileRepo;
        _requestRepo = requestRepo;
        _matchRepo = matchRepo;
        _reportRepo = reportRepo;
        _auditLogRepo = auditLogRepo;
        _districtRepo = districtRepo;
        _unitOfWork = unitOfWork;
        _notificationService = notificationService;
    }

    public async Task<AdminDashboardStatsDto> GetDashboardStatsAsync()
    {
        var usersQ = _userRepo.Query();
        var requestsQ = _requestRepo.Query();
        var matchesQ = _matchRepo.Query();
        var reportsQ = _reportRepo.Query();
        var donorProfilesQ = _donorProfileRepo.Query();

        var totalUsers = await _userRepo.CountAsync(usersQ);
        var totalDonors = await _userRepo.CountAsync(usersQ.Where(u => u.Role == UserRole.Donor));
        var totalRequesters = await _userRepo.CountAsync(usersQ.Where(u => u.Role == UserRole.Requester));
        var totalBloodRequests = await _requestRepo.CountAsync(requestsQ);
        var openBloodRequests = await _requestRepo.CountAsync(requestsQ.Where(r => r.Status == RequestStatus.Open || r.Status == RequestStatus.PartiallyFulfilled));
        var fulfilledBloodRequests = await _requestRepo.CountAsync(requestsQ.Where(r => r.Status == RequestStatus.Fulfilled));
        var totalMatches = await _matchRepo.CountAsync(matchesQ);
        var acceptedMatches = await _matchRepo.CountAsync(matchesQ.Where(m => m.DonorResponse == DonorResponse.Accepted));
        var totalReports = await _reportRepo.CountAsync(reportsQ);
        var openReports = await _reportRepo.CountAsync(reportsQ.Where(r => r.Status == ReportStatus.Open || r.Status == ReportStatus.UnderReview));
        var pendingVerifications = await _donorProfileRepo.CountAsync(donorProfilesQ.Where(d => d.VerificationStatus == VerificationStatus.Pending));

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

    public async Task<AdminAnalyticsDto> GetAnalyticsAsync()
    {
        // Aggregated in-memory (rather than via provider-translated GroupBy) so the
        // Application layer stays free of an EF Core package reference — this dataset
        // is small enough (users/requests/matches, not raw event logs) for that to be fine.
        var since = DateTime.UtcNow.Date.AddDays(-29);

        var donorProfiles = await _donorProfileRepo.ToListAsync(_donorProfileRepo.Query());
        var requests = await _requestRepo.ToListAsync(_requestRepo.Query());
        var matches = await _matchRepo.ToListAsync(_matchRepo.Query());

        var bloodTypeDistribution = donorProfiles
            .GroupBy(d => d.BloodGroup)
            .Select(g => new BloodTypeCountDto { BloodGroup = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .ToList();

        var requestStatusBreakdown = requests
            .GroupBy(r => r.Status)
            .Select(g => new StatusCountDto { Status = g.Key.ToString(), Count = g.Count() })
            .ToList();

        var urgencyBreakdown = requests
            .GroupBy(r => r.Urgency)
            .Select(g => new StatusCountDto { Status = g.Key.ToString(), Count = g.Count() })
            .ToList();

        var donorVerificationBreakdown = donorProfiles
            .GroupBy(d => d.VerificationStatus)
            .Select(g => new StatusCountDto { Status = g.Key.ToString(), Count = g.Count() })
            .ToList();

        var requestsByDistrictRaw = requests
            .GroupBy(r => r.DistrictId)
            .Select(g => new { DistrictId = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(10)
            .ToList();

        var donorsByDistrictRaw = donorProfiles
            .GroupBy(d => d.DistrictId)
            .Select(g => new { DistrictId = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(10)
            .ToList();

        var districtIds = requestsByDistrictRaw.Select(x => x.DistrictId)
            .Concat(donorsByDistrictRaw.Select(x => x.DistrictId))
            .Distinct()
            .ToList();
        var districts = await _districtRepo.ToListAsync(_districtRepo.Query().Where(d => districtIds.Contains(d.Id)));
        var districtNames = districts.ToDictionary(d => d.Id, d => d.Name);

        var requestsByDistrict = requestsByDistrictRaw
            .Select(x => new DistrictCountDto { DistrictName = districtNames.GetValueOrDefault(x.DistrictId, "Unknown"), Count = x.Count })
            .ToList();
        var donorsByDistrict = donorsByDistrictRaw
            .Select(x => new DistrictCountDto { DistrictName = districtNames.GetValueOrDefault(x.DistrictId, "Unknown"), Count = x.Count })
            .ToList();

        var requestsOverTime = FillDateSeries(
            requests.Where(r => r.CreatedAt >= since)
                .GroupBy(r => r.CreatedAt.Date)
                .Select(g => (g.Key, g.Count())),
            since);

        var newDonorsOverTime = FillDateSeries(
            donorProfiles.Where(d => d.CreatedAt >= since)
                .GroupBy(d => d.CreatedAt.Date)
                .Select(g => (g.Key, g.Count())),
            since);

        var totalRequests = requests.Count;
        var fulfilledRequests = requests.Count(r => r.Status == RequestStatus.Fulfilled);
        var fulfillmentRate = totalRequests == 0 ? 0 : Math.Round(fulfilledRequests * 100.0 / totalRequests, 1);

        var respondedMatches = matches.Where(m => m.ContactedAt != null && m.RespondedAt != null).ToList();
        double? avgResponseHours = respondedMatches.Count == 0
            ? null
            : Math.Round(respondedMatches.Average(m => (m.RespondedAt!.Value - m.ContactedAt!.Value).TotalHours), 1);

        return new AdminAnalyticsDto
        {
            BloodTypeDistribution = bloodTypeDistribution,
            RequestStatusBreakdown = requestStatusBreakdown,
            UrgencyBreakdown = urgencyBreakdown,
            DonorVerificationBreakdown = donorVerificationBreakdown,
            RequestsByDistrict = requestsByDistrict,
            DonorsByDistrict = donorsByDistrict,
            RequestsOverTime = requestsOverTime,
            NewDonorsOverTime = newDonorsOverTime,
            FulfillmentRatePercent = fulfillmentRate,
            AverageDonorResponseHours = avgResponseHours,
        };
    }

    private static List<TimeSeriesPointDto> FillDateSeries(IEnumerable<(DateTime Date, int Count)> raw, DateTime since)
    {
        var lookup = raw.ToDictionary(x => x.Date.Date, x => x.Count);
        var result = new List<TimeSeriesPointDto>();
        for (var day = since.Date; day <= DateTime.UtcNow.Date; day = day.AddDays(1))
        {
            result.Add(new TimeSeriesPointDto { Date = day, Count = lookup.GetValueOrDefault(day, 0) });
        }
        return result;
    }

    public async Task<IReadOnlyList<AdminUserDto>> GetUsersAsync(string? search, UserRole? role, int page = 1, int pageSize = 20)
    {
        var query = _userRepo.Query();

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

        var pagedUsers = await _userRepo.ToListAsync(
            query.OrderByDescending(u => u.CreatedAt).Skip((page - 1) * pageSize).Take(pageSize));

        var pagedIds = pagedUsers.Select(u => u.Id).ToList();
        var profiles = await _donorProfileRepo.ToListAsync(
            _donorProfileRepo.Query().Where(p => pagedIds.Contains(p.UserId)));
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
        var query = _userRepo.Query();

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

        return await _userRepo.CountAsync(query);
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

        var notifTitle = status == VerificationStatus.Verified ? "Donor Verified!" : "Verification Update";
        var notifMessage = status == VerificationStatus.Verified
            ? "Congratulations! Your donor profile has been verified. You are now visible to blood requesters and can start receiving match requests."
            : $"Your donor verification status has been updated to: {status}. Please check your profile for details.";

        await _notificationService.SendNotificationAsync(
            userId,
            notifTitle,
            notifMessage,
            NotificationType.System,
            null);

        var user = await _userRepo.GetByIdAsync(userId);
        return user != null ? MapToUserDto(user, profile) : null;
    }

    public async Task<IReadOnlyList<AdminReportDto>> GetReportsAsync(ReportStatus? status, int page = 1, int pageSize = 20)
    {
        var query = _reportRepo.Query();

        if (status.HasValue)
            query = query.Where(r => r.Status == status.Value);

        var pagedReports = await _reportRepo.ToListAsync(
            query.OrderByDescending(r => r.CreatedAt).Skip((page - 1) * pageSize).Take(pageSize));

        var userIds = pagedReports
            .SelectMany(r => new[] { r.ReporterUserId, r.ReportedUserId, r.ReviewedBy ?? Guid.Empty })
            .Where(id => id != Guid.Empty)
            .Distinct()
            .ToList();

        var users = await _userRepo.ToListAsync(_userRepo.Query().Where(u => userIds.Contains(u.Id)));
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
        var query = _reportRepo.Query();
        if (status.HasValue)
            query = query.Where(r => r.Status == status.Value);
        return await _reportRepo.CountAsync(query);
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
        var query = _auditLogRepo.Query();

        if (!string.IsNullOrWhiteSpace(entityType))
            query = query.Where(l => l.EntityType == entityType);

        var pagedLogs = await _auditLogRepo.ToListAsync(
            query.OrderByDescending(l => l.CreatedAt).Skip((page - 1) * pageSize).Take(pageSize));

        var userIds = pagedLogs
            .Select(l => l.UserId)
            .Where(id => id.HasValue)
            .Select(id => id!.Value)
            .Distinct()
            .ToList();

        var users = await _userRepo.ToListAsync(_userRepo.Query().Where(u => userIds.Contains(u.Id)));
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
        var query = _auditLogRepo.Query();
        if (!string.IsNullOrWhiteSpace(entityType))
            query = query.Where(l => l.EntityType == entityType);
        return await _auditLogRepo.CountAsync(query);
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
            DonorVerificationStatus = profile?.VerificationStatus.ToString(),
            PhotoUrl = user.PhotoUrl
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
