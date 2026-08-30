using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using BloodNetwork.Application.Configuration;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BloodNetwork.IntegrationTests;

public class ConfigEnforcementTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
    };

    private static readonly Guid DhakaDistrict = TestDataSeeder.DhakaDistrict;
    private static readonly Guid GulshanUpazila = TestDataSeeder.GulshanUpazila;

    public ConfigEnforcementTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    private void AssumeAll(string accessToken)
        => _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

    private async Task<(string Token, Guid UserId)> RegisterAsync(string phone, UserRole role = UserRole.Requester)
    {
        var request = new RegisterRequest("Config", "Test", phone, "Password1", Role: role);
        var response = await _client.PostAsJsonAsync("/api/auth/register", request);
        var body = await response.Content.ReadFromJsonAsync<AuthResponse>(_jsonOptions);
        return (body!.AccessToken, body.User.Id);
    }

    private async Task<Guid> SeedAdminAsync(string phone)
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BloodNetworkDbContext>();
        var hasher = new BloodNetwork.Infrastructure.Authentication.PasswordHasher();

        var admin = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "Admin",
            LastName = "Test",
            PhoneNumber = phone,
            PasswordHash = hasher.HashPassword("Password1"),
            Role = UserRole.Admin,
            IsActive = true,
            IsPhoneVerified = true,
            MustChangePassword = false,
            CreatedAt = DateTime.UtcNow
        };

        db.Users.Add(admin);
        await db.SaveChangesAsync();
        return admin.Id;
    }

    private async Task<string> LoginAsync(string phone)
    {
        var request = new LoginRequest(phone, "Password1");
        var response = await _client.PostAsJsonAsync("/api/auth/login", request);
        var body = await response.Content.ReadFromJsonAsync<AuthResponse>(_jsonOptions);
        return body!.AccessToken;
    }

    private static CreateBloodRequestRequest NewRequest(string phone)
        => new(
            BloodGroup.APositive,
            2,
            "Dhaka Medical College Hospital",
            "Dhaka, Bangladesh",
            DhakaDistrict,
            GulshanUpazila,
            "Gulshan 1",
            DateTime.UtcNow.AddDays(3),
            Urgency.Urgent,
            "Patient One",
            "Self",
            phone,
            "",
            23.78,
            90.41);

    private async Task SeedActiveRequestsAsync(Guid userId, int count)
    {
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BloodNetworkDbContext>();
        for (int i = 0; i < count; i++)
        {
            db.BloodRequests.Add(new BloodRequest
            {
                Id = Guid.NewGuid(),
                RequesterId = userId,
                BloodGroup = BloodGroup.APositive,
                UnitsRequired = 1,
                UnitsFulfilled = 0,
                HospitalName = "Test Hospital",
                HospitalAddress = "Test Address",
                DistrictId = DhakaDistrict,
                UpazilaId = GulshanUpazila,
                RequiredBy = DateTime.UtcNow.AddDays(7),
                Urgency = Urgency.Normal,
                ContactPhone = "01720000000",
                Status = RequestStatus.Open,
                CreatedAt = DateTime.UtcNow
            });
        }
        await db.SaveChangesAsync();
    }

    [Fact]
    public async Task CreateRequest_ExceedsMaxActiveRequests_ReturnsBadRequest()
    {
        TestDataSeeder.EnsureDhakaLocations(_factory.Services);
        var (_, userId) = await RegisterAsync("01790100001");

        await SeedActiveRequestsAsync(userId, 3);

        AssumeAll(await LoginAsync("01790100001"));
        var response = await _client.PostAsJsonAsync("/api/blood-requests", NewRequest("01790100001"));

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains("active", body, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task CreateRequest_WithinCooldownPeriod_ReturnsBadRequest()
    {
        TestDataSeeder.EnsureDhakaLocations(_factory.Services);
        var (token, _) = await RegisterAsync("01790100002");
        AssumeAll(token);

        var firstResponse = await _client.PostAsJsonAsync("/api/blood-requests", NewRequest("01790100002"));
        Assert.Equal(HttpStatusCode.Created, firstResponse.StatusCode);

        var secondResponse = await _client.PostAsJsonAsync("/api/blood-requests", NewRequest("01790100002"));
        Assert.Equal(HttpStatusCode.BadRequest, secondResponse.StatusCode);
        var body = await secondResponse.Content.ReadAsStringAsync();
        Assert.Contains("wait", body, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task ResolveReport_NotifiesReporter()
    {
        var (reporterToken, reporterId) = await RegisterAsync("01790100003", UserRole.Requester);
        var (_, reportedId) = await RegisterAsync("01790100004", UserRole.Donor);

        AssumeAll(reporterToken);
        var reportRequest = new CreateReportRequest
        {
            ReportedUserId = reportedId,
            Reason = "Spam behavior",
            Description = "User is posting spam content"
        };
        var createReportResponse = await _client.PostAsJsonAsync("/api/reports", reportRequest);
        Assert.Equal(HttpStatusCode.OK, createReportResponse.StatusCode);

        Guid reportId;
        using (var scope = _factory.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<BloodNetworkDbContext>();
            var report = await db.Reports.FirstOrDefaultAsync(
                r => r.ReporterUserId == reporterId && r.ReportedUserId == reportedId);
            Assert.NotNull(report);
            reportId = report!.Id;
        }

        await SeedAdminAsync("01790100005");
        var adminToken = await LoginAsync("01790100005");
        AssumeAll(adminToken);

        var resolveResponse = await _client.PostAsJsonAsync(
            $"/api/admin/reports/{reportId}/resolve",
            new ResolveReportRequest { Status = ReportStatus.Resolved, Resolution = "Action taken" });
        Assert.Equal(HttpStatusCode.OK, resolveResponse.StatusCode);

        AssumeAll(reporterToken);
        var notificationsResponse = await _client.GetAsync("/api/notifications");
        Assert.Equal(HttpStatusCode.OK, notificationsResponse.StatusCode);
        var notifications = await notificationsResponse.Content.ReadFromJsonAsync<List<NotificationDto>>(_jsonOptions);
        Assert.NotNull(notifications);
        Assert.Contains(notifications!, n => n.Title.Contains("Report") && n.Type == NotificationType.System);
    }

    [Fact]
    public async Task FulfillRequest_UpdatesDonorLastDonationDateAndCount()
    {
        TestDataSeeder.EnsureDhakaLocations(_factory.Services);

        var (donorToken, donorId) = await RegisterAsync("01790100006", UserRole.Donor);
        AssumeAll(donorToken);
        var profileResponse = await _client.PostAsJsonAsync("/api/donors/me/profile",
            new CreateDonorProfileRequest(
                BloodGroup.APositive, "Male", new DateTime(1990, 1, 1),
                DhakaDistrict, GulshanUpazila, "Gulshan", null, 23.79, 90.41));
        Assert.Equal(HttpStatusCode.Created, profileResponse.StatusCode);

        var (requesterToken, _) = await RegisterAsync("01790100007", UserRole.Requester);
        AssumeAll(requesterToken);
        var requestResponse = await _client.PostAsJsonAsync("/api/blood-requests", NewRequest("01790100007"));
        Assert.Equal(HttpStatusCode.Created, requestResponse.StatusCode);
        var bloodRequest = await requestResponse.Content.ReadFromJsonAsync<BloodRequestDto>(_jsonOptions);

        await SeedAdminAsync("01790100008");
        var adminToken = await LoginAsync("01790100008");
        AssumeAll(adminToken);
        var matchResponse = await _client.PostAsJsonAsync(
            $"/api/matches/request/{bloodRequest!.Id}/trigger-match", new { });
        Assert.Equal(HttpStatusCode.OK, matchResponse.StatusCode);

        AssumeAll(await LoginAsync("01790100007"));
        var matchesResponse = await _client.GetAsync($"/api/matches/request/{bloodRequest.Id}");
        Assert.Equal(HttpStatusCode.OK, matchesResponse.StatusCode);
        var matches = await matchesResponse.Content.ReadFromJsonAsync<List<BloodRequestMatchDto>>(_jsonOptions);
        Assert.NotNull(matches);
        Assert.NotEmpty(matches!);

        var donorMatch = matches!.FirstOrDefault(m => m.DonorId == donorId);
        Assert.NotNull(donorMatch);

        AssumeAll(donorToken);
        var respondResponse = await _client.PostAsJsonAsync(
            $"/api/matches/{donorMatch!.Id}/respond",
            new RespondToMatchRequest { Response = DonorResponse.Accepted });
        Assert.Equal(HttpStatusCode.OK, respondResponse.StatusCode);

        AssumeAll(requesterToken);
        var fulfillResponse = await _client.PatchAsJsonAsync(
            $"/api/blood-requests/{bloodRequest.Id}/fulfill",
            new FulfillBloodRequestRequest(2, "Done"));
        Assert.Equal(HttpStatusCode.OK, fulfillResponse.StatusCode);

        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BloodNetworkDbContext>();
        var profile = await db.DonorProfiles.FirstOrDefaultAsync(p => p.UserId == donorId);
        Assert.NotNull(profile);
        Assert.NotNull(profile!.LastDonationDate);
        Assert.True(profile.TotalDonationCount >= 1);
    }

    [Fact]
    public void AppSettings_AllProperties_HaveRangeAttributes()
    {
        var properties = typeof(AppSettings).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        Assert.NotEmpty(properties);

        foreach (var prop in properties)
        {
            var rangeAttr = prop.GetCustomAttribute<RangeAttribute>();
            Assert.True(rangeAttr != null,
                $"Property '{prop.Name}' in AppSettings is missing [Range] attribute");
        }
    }
}
