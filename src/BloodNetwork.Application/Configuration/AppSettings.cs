namespace BloodNetwork.Application.Configuration;

public class AppSettings
{
    public const string SectionName = "AppSettings";
    public int MinimumDonationIntervalDays { get; set; } = 90;
    public int DonorProfileConfirmationDays { get; set; } = 90;
    public int MaxActiveRequestsPerUser { get; set; } = 3;
    public int ContactCooldownHours { get; set; } = 24;
}
