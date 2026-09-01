namespace BloodNetwork.Application.Configuration;

public class FirebaseOptions
{
    public const string SectionName = "Firebase";

    /// <summary>Path to a Firebase service-account JSON file (local/dev; keep out of git).</summary>
    public string? ServiceAccountPath { get; set; }

    /// <summary>Inline Firebase service-account JSON (deploy-friendly; env var Firebase__ServiceAccountJson).</summary>
    public string? ServiceAccountJson { get; set; }
}