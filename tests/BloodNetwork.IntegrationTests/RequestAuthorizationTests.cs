using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Domain.Enums;

namespace BloodNetwork.IntegrationTests;

public class RequestAuthorizationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
    };

    private static readonly Guid DhakaDistrict = TestDataSeeder.DhakaDistrict;
    private static readonly Guid GulshanUpazila = TestDataSeeder.GulshanUpazila;

    private readonly IServiceProvider _services;

    public RequestAuthorizationTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
        _services = factory.Services;
    }

    private void AssumeAll(string accessToken)
        => _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

    private async Task<string> RegisterAsync(string phone, UserRole role = UserRole.Requester)
    {
        var request = new RegisterRequest("Auth", "User", phone, "Password1", Role: role);
        var response = await _client.PostAsJsonAsync("/api/auth/register", request);
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

    private async Task<Guid> CreateRequestAsAsync(string token)
    {
        TestDataSeeder.EnsureDhakaLocations(_services);
        AssumeAll(token);
        var response = await _client.PostAsJsonAsync("/api/blood-requests", NewRequest("01720000000"));
        var body = await response.Content.ReadFromJsonAsync<BloodRequestDto>(_jsonOptions);
        return body!.Id;
    }

    [Fact]
    public async Task FulfillRequest_AsNonOwner_ReturnsNotFound()
    {
        var ownerToken = await RegisterAsync("01790000010");
        var requestId = await CreateRequestAsAsync(ownerToken);

        AssumeAll(await RegisterAsync("01790000011"));
        var response = await _client.PatchAsJsonAsync(
            $"/api/blood-requests/{requestId}/fulfill",
            new FulfillBloodRequestRequest(1, null));

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CancelRequest_AsNonOwner_ReturnsNotFound()
    {
        var ownerToken = await RegisterAsync("01790000012");
        var requestId = await CreateRequestAsAsync(ownerToken);

        AssumeAll(await RegisterAsync("01790000013"));
        var response = await _client.PatchAsJsonAsync($"/api/blood-requests/{requestId}/cancel", new { });

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task MatchesForRequest_AsNonOwner_ReturnsForbidden()
    {
        var ownerToken = await RegisterAsync("01790000014");
        var requestId = await CreateRequestAsAsync(ownerToken);

        AssumeAll(await RegisterAsync("01790000015"));
        var response = await _client.GetAsync($"/api/matches/request/{requestId}");

        Assert.Equal(HttpStatusCode.Forbidden, response.StatusCode);
    }

    [Fact]
    public async Task FulfillRequest_Unauthenticated_ReturnsUnauthorized()
    {
        _client.DefaultRequestHeaders.Authorization = null;
        var response = await _client.PatchAsJsonAsync(
            $"/api/blood-requests/{Guid.NewGuid()}/fulfill",
            new FulfillBloodRequestRequest(1, null));

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task FulfillRequest_AsOwner_MarksRequestFulfilled()
    {
        var ownerToken = await RegisterAsync("01790000016");
        var requestId = await CreateRequestAsAsync(ownerToken);

        AssumeAll(ownerToken);
        var response = await _client.PatchAsJsonAsync(
            $"/api/blood-requests/{requestId}/fulfill",
            new FulfillBloodRequestRequest(2, "Done"));

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var body = await response.Content.ReadFromJsonAsync<BloodRequestDto>(_jsonOptions);
        Assert.NotNull(body);
        Assert.Equal(RequestStatus.Fulfilled, body!.Status);
        Assert.Equal(2, body.UnitsFulfilled);
    }

    [Fact]
    public async Task CancelRequest_AsOwner_Succeeds()
    {
        var ownerToken = await RegisterAsync("01790000017");
        var requestId = await CreateRequestAsAsync(ownerToken);

        AssumeAll(ownerToken);
        var response = await _client.PatchAsJsonAsync($"/api/blood-requests/{requestId}/cancel", new { });

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var body = await response.Content.ReadFromJsonAsync<BloodRequestDto>(_jsonOptions);
        Assert.NotNull(body);
        Assert.Equal(RequestStatus.Cancelled, body!.Status);
    }
}