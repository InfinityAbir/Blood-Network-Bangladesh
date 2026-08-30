using BloodNetwork.Domain.Common;
using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Domain.Entities;

public class DeviceToken : BaseEntity
{
    public Guid UserId { get; set; }
    public string Token { get; set; } = string.Empty;
    public DevicePlatform Platform { get; set; } = DevicePlatform.Android;
    public DateTime LastActiveAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; } = null!;
}