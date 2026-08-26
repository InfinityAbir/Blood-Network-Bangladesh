using System.Text.Json.Serialization;
using BloodNetwork.Domain.Common;
using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string? Email { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; } = string.Empty;

    public UserRole Role { get; set; } = UserRole.Requester;
    public bool IsActive { get; set; } = true;
    public bool IsPhoneVerified { get; set; }
    public bool MustChangePassword { get; set; }
    public DateTime? LastLoginAt { get; set; }

    public DonorProfile? DonorProfile { get; set; }
    public ICollection<BloodRequest> BloodRequests { get; set; } = new List<BloodRequest>();
    public ICollection<BloodRequestMatch> DonorMatches { get; set; } = new List<BloodRequestMatch>();
    public ICollection<DonationRecord> DonationRecords { get; set; } = new List<DonationRecord>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}
