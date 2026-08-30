using System.ComponentModel.DataAnnotations;

namespace BloodNetwork.Application.Configuration;

public class AppSettings
{
    public const string SectionName = "AppSettings";
    [Range(0, 365)] public int MinimumDonationIntervalDays { get; set; } = 90;
    [Range(0, 365)] public int DonorProfileConfirmationDays { get; set; } = 90;
    [Range(1, 100)] public int MaxActiveRequestsPerUser { get; set; } = 3;
    [Range(0, 168)] public int ContactCooldownHours { get; set; } = 24;
}
