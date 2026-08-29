using BloodNetwork.Domain.Common;

namespace BloodNetwork.Domain.Entities;

/// <summary>
/// Single-row "About the developer" content shown in the app, editable by admins at
/// runtime instead of being hardcoded in the client.
/// </summary>
public class DeveloperInfo : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? GithubUrl { get; set; }
    public string? PhotoUrl { get; set; }
}
