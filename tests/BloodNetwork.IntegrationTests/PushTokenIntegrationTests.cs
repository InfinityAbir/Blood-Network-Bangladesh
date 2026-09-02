using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;
using BloodNetwork.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BloodNetwork.IntegrationTests;

public class PushTokenIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
    };

    public PushTokenIntegrationTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
        _client = factory.CreateClient();
    }

    private async Task<string> RegisterAsync(string phone)
    {
        var request = new RegisterRequest("Fcm", "User", phone, "Password1", Role: UserRole.Donor);
        var response = await _client.PostAsJsonAsync("/api/auth/register", request);
        var body = await response.Content.ReadFromJsonAsync<AuthResponse>(_jsonOptions);
        return body!.AccessToken;
    }

    private void AssumeAll(string accessToken)
        => _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

    [Fact]
    public async Task RegisterToken_Authenticated_StoresToken()
    {
        AssumeAll(await RegisterAsync("01790000001"));
        const string fcmToken = "fcm-dka-abcdef1234567890abcdef";

        var response = await _client.PostAsJsonAsync("/api/push/tokens", new RegisterPushTokenRequest(fcmToken));

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BloodNetworkDbContext>();
        var row = await db.Set<DeviceToken>().FirstOrDefaultAsync(t => t.Token == fcmToken);
        Assert.NotNull(row);
        Assert.Equal(DevicePlatform.Android, row!.Platform);
    }

    [Fact]
    public async Task RegisterToken_RepeatedUpsert_KeepsSingleRow()
    {
        AssumeAll(await RegisterAsync("01790000002"));
        const string fcmToken = "fcm-upsert-abcdef1234567890abcdef";

        await _client.PostAsJsonAsync("/api/push/tokens", new RegisterPushTokenRequest(fcmToken));
        await _client.PostAsJsonAsync("/api/push/tokens", new RegisterPushTokenRequest(fcmToken));

        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BloodNetworkDbContext>();
        var count = await db.Set<DeviceToken>().CountAsync(t => t.Token == fcmToken);
        Assert.Equal(1, count);
    }

    [Fact]
    public async Task RemoveToken_OwnedToken_ReturnsNoContent()
    {
        AssumeAll(await RegisterAsync("01790000003"));
        const string fcmToken = "fcm-del-abcdef1234567890abcdef";

        await _client.PostAsJsonAsync("/api/push/tokens", new RegisterPushTokenRequest(fcmToken));
        var response = await _client.DeleteAsync($"/api/push/tokens/{fcmToken}");

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BloodNetworkDbContext>();
        Assert.Equal(0, await db.Set<DeviceToken>().CountAsync(t => t.Token == fcmToken));
    }

    [Fact]
    public async Task RegisterToken_AfterLogoutCleanup_CanRegisterTheSameFcmTokenAgain()
    {
        AssumeAll(await RegisterAsync("01790000006"));
        const string fcmToken = "fcm-relogin-abcdef1234567890abcdef";

        Assert.Equal(HttpStatusCode.OK, (await _client.PostAsJsonAsync("/api/push/tokens", new RegisterPushTokenRequest(fcmToken))).StatusCode);
        Assert.Equal(HttpStatusCode.NoContent, (await _client.DeleteAsync($"/api/push/tokens/{fcmToken}")).StatusCode);
        Assert.Equal(HttpStatusCode.OK, (await _client.PostAsJsonAsync("/api/push/tokens", new RegisterPushTokenRequest(fcmToken))).StatusCode);

        using var scope = _factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<BloodNetworkDbContext>();
        Assert.Equal(1, await db.Set<DeviceToken>().CountAsync(t => t.Token == fcmToken));
    }

    [Fact]
    public async Task RemoveToken_OtherUsersToken_ReturnsNotFound()
    {
        AssumeAll(await RegisterAsync("01790000004"));
        const string fcmToken = "fcm-other-abcdef1234567890abcdef";
        await _client.PostAsJsonAsync("/api/push/tokens", new RegisterPushTokenRequest(fcmToken));

        AssumeAll(await RegisterAsync("01790000005"));

        var response = await _client.DeleteAsync($"/api/push/tokens/{fcmToken}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task RegisterToken_Unauthenticated_ReturnsUnauthorized()
    {
        _client.DefaultRequestHeaders.Authorization = null;
        var response = await _client.PostAsJsonAsync("/api/push/tokens", new RegisterPushTokenRequest("fcm-unauth-abcdef"));
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}
