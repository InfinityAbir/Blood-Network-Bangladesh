using BloodNetwork.Domain.Common;

namespace BloodNetwork.Domain.Entities;

/// <summary>
/// Single-row admin-editable system configuration. Replaces hardcoded appsettings.json values
/// for match scoring and business rules so admins can tune without redeploy.
/// </summary>
public class SystemSettings : BaseEntity
{
    public int MinimumDonationIntervalDays { get; set; } = 90;
    public int DonorProfileConfirmationDays { get; set; } = 90;
    public int MaxActiveRequestsPerUser { get; set; } = 3;
    public int ContactCooldownHours { get; set; } = 24;

    // Match score weights
    public int ExactBloodGroupWeight { get; set; } = 30;
    public int CompatibleBloodGroupWeight { get; set; } = 0;
    public int AvailableWeight { get; set; } = 30;
    public int UnknownWeight { get; set; } = 0;
    public int VerifiedWeight { get; set; } = 15;
    public int UnverifiedWeight { get; set; } = 0;
    public int ProfileFreshnessWeight { get; set; } = 10;
    public int Distance0to3kmWeight { get; set; } = 15;
    public int Distance3to10kmWeight { get; set; } = 10;
    public int Distance10to25kmWeight { get; set; } = 5;
    public int DistanceOver25kmWeight { get; set; } = 0;
}
