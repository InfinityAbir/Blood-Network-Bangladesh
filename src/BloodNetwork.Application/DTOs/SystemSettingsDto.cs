using System.ComponentModel.DataAnnotations;

namespace BloodNetwork.Application.DTOs;

public class SystemSettingsDto
{
    public int MinimumDonationIntervalDays { get; set; }
    public int DonorProfileConfirmationDays { get; set; }
    public int MaxActiveRequestsPerUser { get; set; }
    public int ContactCooldownHours { get; set; }

    public int ExactBloodGroupWeight { get; set; }
    public int CompatibleBloodGroupWeight { get; set; }
    public int AvailableWeight { get; set; }
    public int UnknownWeight { get; set; }
    public int VerifiedWeight { get; set; }
    public int UnverifiedWeight { get; set; }
    public int ProfileFreshnessWeight { get; set; }
    public int Distance0to3kmWeight { get; set; }
    public int Distance3to10kmWeight { get; set; }
    public int Distance10to25kmWeight { get; set; }
    public int DistanceOver25kmWeight { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class UpdateSystemSettingsRequest
{
    [Range(0, 365)] public int MinimumDonationIntervalDays { get; set; }
    [Range(0, 365)] public int DonorProfileConfirmationDays { get; set; }
    [Range(1, 100)] public int MaxActiveRequestsPerUser { get; set; }
    [Range(0, 720)] public int ContactCooldownHours { get; set; }

    [Range(0, 100)] public int ExactBloodGroupWeight { get; set; }
    [Range(0, 100)] public int CompatibleBloodGroupWeight { get; set; }
    [Range(0, 100)] public int AvailableWeight { get; set; }
    [Range(0, 100)] public int UnknownWeight { get; set; }
    [Range(0, 100)] public int VerifiedWeight { get; set; }
    [Range(0, 100)] public int UnverifiedWeight { get; set; }
    [Range(0, 100)] public int ProfileFreshnessWeight { get; set; }
    [Range(0, 100)] public int Distance0to3kmWeight { get; set; }
    [Range(0, 100)] public int Distance3to10kmWeight { get; set; }
    [Range(0, 100)] public int Distance10to25kmWeight { get; set; }
    [Range(0, 100)] public int DistanceOver25kmWeight { get; set; }
}
