using System.Collections.Concurrent;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Enums;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BloodNetwork.IntegrationTests;

public class PushHookIntegrationTests
{
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
    };

    private sealed class FakePushSender : IPushNotificationSender
    {
        public ConcurrentQueue<(Guid UserId, string Title, string Message)> Calls { get; } = new();

        public Task SendPushAsync(
            Guid userId,
            string title,
            string message,
            string type,
            Guid? relatedEntityId = null,
            string? metadata = null,
            CancellationToken cancellationToken = default)
        {
            Calls.Enqueue((userId, title, message));
            return Task.CompletedTask;
        }
    }

    private (HttpClient Client, FakePushSender Fake, IServiceProvider Services) CreateClientWithFake()
    {
        var fake = new FakePushSender();
        var factory = new CustomWebApplicationFactory();
        var client = factory
            .WithWebHostBuilder(builder => builder.ConfigureTestServices(services =>
            {
                services.RemoveAll<IPushNotificationSender>();
                services.AddSingleton<IPushNotificationSender>(fake);
            }))
            .CreateClient();
        return (client, fake, factory.Services);
    }

    private void AssumeAll(HttpClient client, string accessToken)
        => client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

    private async Task<(HttpClient Client, string Token, Guid UserId)> RegisterAsync(HttpClient client, string phone)
    {
        var request = new RegisterRequest("Push", "Hook", phone, "Password1", Role: UserRole.Donor);
        var response = await client.PostAsJsonAsync("/api/auth/register", request);
        var body = await response.Content.ReadFromJsonAsync<AuthResponse>(_jsonOptions);
        return (client, body!.AccessToken, body.User.Id);
    }

    [Fact]
    public async Task Welcome_AfterRegistration_FiresPush()
    {
        var (client, fake, _) = CreateClientWithFake();
        var (_, _, userId) = await RegisterAsync(client, "01790000020");

        Assert.Contains(fake.Calls, c => c.UserId == userId && c.Title == "Welcome to Blood Network Bangladesh!");
    }

    [Fact]
    public async Task RequestCreated_FiresPushToRequester()
    {
        var (client, fake, services) = CreateClientWithFake();
        TestDataSeeder.EnsureDhakaLocations(services);
        var (_, token, userId) = await RegisterAsync(client, "01790000021");

        AssumeAll(client, token);
        var request = new CreateBloodRequestRequest(
            BloodGroup.APositive,
            1,
            "Dhaka Medical College Hospital",
            "Dhaka, Bangladesh",
            new Guid("11111111-1111-4111-8111-111111111101"),
            new Guid("aa000001-0000-4000-8000-000000000012"),
            "Gulshan 1",
            DateTime.UtcNow.AddDays(3),
            Urgency.Urgent,
            "Patient Two",
            "Self",
            "01720000000",
            "",
            23.78,
            90.41);
        var createResponse = await client.PostAsJsonAsync("/api/blood-requests", request);
        if (!createResponse.IsSuccessStatusCode)
            throw new InvalidOperationException($"Create failed: {await createResponse.Content.ReadAsStringAsync()}");

        Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);
        var body = await createResponse.Content.ReadFromJsonAsync<BloodRequestDto>(_jsonOptions);
        Assert.Contains(fake.Calls, c => c.UserId == userId && c.Title == "Blood Request Created" && c.Message.Contains(body!.HospitalName));
    }

    [Fact]
    public async Task RequestFulfilled_FiresPushToRequester()
    {
        var (client, fake, services) = CreateClientWithFake();
        TestDataSeeder.EnsureDhakaLocations(services);
        var (_, token, userId) = await RegisterAsync(client, "01790000022");

        AssumeAll(client, token);
        var request = new CreateBloodRequestRequest(
            BloodGroup.APositive,
            1,
            "Dhaka Medical College Hospital",
            "Dhaka, Bangladesh",
            new Guid("11111111-1111-4111-8111-111111111101"),
            new Guid("aa000001-0000-4000-8000-000000000012"),
            "Gulshan 1",
            DateTime.UtcNow.AddDays(3),
            Urgency.Urgent,
            "Patient Three",
            "Self",
            "01720000000",
            "",
            23.78,
            90.41);
        var createResponse = await client.PostAsJsonAsync("/api/blood-requests", request);
        var created = await createResponse.Content.ReadFromJsonAsync<BloodRequestDto>(_jsonOptions);

        var fulfillResponse = await client.PatchAsJsonAsync(
            $"/api/blood-requests/{created!.Id}/fulfill",
            new FulfillBloodRequestRequest(1, "Done"));

        Assert.Equal(HttpStatusCode.OK, fulfillResponse.StatusCode);
        Assert.Contains(fake.Calls, c => c.UserId == userId && c.Title == "Blood Request Fulfilled");
    }
}