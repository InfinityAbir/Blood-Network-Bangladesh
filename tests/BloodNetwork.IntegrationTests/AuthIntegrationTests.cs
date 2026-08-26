using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using BloodNetwork.Application.DTOs;
using BloodNetwork.Domain.Enums;

namespace BloodNetwork.IntegrationTests;

public class AuthIntegrationTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public AuthIntegrationTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Register_ValidRequester_ReturnsCreated()
    {
        var request = new RegisterRequest("Test", "Donor", "01712345678", "Password1", Role: UserRole.Requester);

        var response = await _client.PostAsJsonAsync("/api/auth/register", request);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<AuthResponse>(_jsonOptions);
        Assert.NotNull(body);
        Assert.False(string.IsNullOrEmpty(body.AccessToken));
        Assert.Equal("Test", body.User.FirstName);
        Assert.Equal(UserRole.Requester, body.User.Role);
    }

    [Fact]
    public async Task Register_ValidDonor_ReturnsCreated()
    {
        var request = new RegisterRequest("Test", "Donor", "01712345679", "Password1", Role: UserRole.Donor);

        var response = await _client.PostAsJsonAsync("/api/auth/register", request);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Register_AdminRole_ReturnsBadRequest()
    {
        var request = new RegisterRequest("Admin", "User", "01712345680", "Password1", Role: UserRole.Admin);

        var response = await _client.PostAsJsonAsync("/api/auth/register", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Register_DuplicatePhone_ReturnsBadRequest()
    {
        var request1 = new RegisterRequest("First", "User", "01712349999", "Password1", Role: UserRole.Requester);
        var request2 = new RegisterRequest("Second", "User", "01712349999", "Password1", Role: UserRole.Donor);

        await _client.PostAsJsonAsync("/api/auth/register", request1);
        var response = await _client.PostAsJsonAsync("/api/auth/register", request2);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Register_WeakPassword_ReturnsBadRequest()
    {
        var request = new RegisterRequest("Test", "User", "01712345681", "weak", Role: UserRole.Requester);

        var response = await _client.PostAsJsonAsync("/api/auth/register", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Login_ValidCredentials_ReturnsOk()
    {
        var registerRequest = new RegisterRequest("Test", "User", "01712345682", "Password1", Role: UserRole.Requester);
        await _client.PostAsJsonAsync("/api/auth/register", registerRequest);

        var loginRequest = new LoginRequest("01712345682", "Password1");
        var response = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<AuthResponse>(_jsonOptions);
        Assert.NotNull(body);
        Assert.False(string.IsNullOrEmpty(body.AccessToken));
    }

    [Fact]
    public async Task Login_WrongPassword_ReturnsUnauthorized()
    {
        var registerRequest = new RegisterRequest("Test", "User", "01712345683", "Password1", Role: UserRole.Requester);
        await _client.PostAsJsonAsync("/api/auth/register", registerRequest);

        var loginRequest = new LoginRequest("01712345683", "WrongPassword1");
        var response = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Login_NonExistentUser_ReturnsUnauthorized()
    {
        var loginRequest = new LoginRequest("01799999999", "Password1");
        var response = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Me_Authenticated_ReturnsOk()
    {
        var registerRequest = new RegisterRequest("Test", "User", "01712345684", "Password1", Role: UserRole.Requester);
        var regResponse = await _client.PostAsJsonAsync("/api/auth/register", registerRequest);
        var regBody = await regResponse.Content.ReadFromJsonAsync<AuthResponse>(_jsonOptions);

        _client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", regBody!.AccessToken);

        var response = await _client.GetAsync("/api/auth/me");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<UserDto>(_jsonOptions);
        Assert.NotNull(body);
        Assert.Equal("Test", body.FirstName);
    }

    [Fact]
    public async Task Me_Unauthenticated_ReturnsUnauthorized()
    {
        var response = await _client.GetAsync("/api/auth/me");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    [Fact]
    public async Task Me_InvalidToken_ReturnsUnauthorized()
    {
        _client.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "invalid.token.here");

        var response = await _client.GetAsync("/api/auth/me");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}
