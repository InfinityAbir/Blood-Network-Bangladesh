namespace BloodNetwork.Domain.Enums;

public enum BloodGroup
{
    APositive,
    ANegative,
    BPositive,
    BNegative,
    ABPositive,
    ABNegative,
    OPositive,
    ONegative
}

public static class BloodGroupExtensions
{
    /// <summary>Human-readable label ("O+", "AB-", ...) for user-facing text — the enum's own
    /// ToString() prints "OPositive", which leaked verbatim into notification messages.</summary>
    public static string ToLabel(this BloodGroup group) => group switch
    {
        BloodGroup.APositive => "A+",
        BloodGroup.ANegative => "A-",
        BloodGroup.BPositive => "B+",
        BloodGroup.BNegative => "B-",
        BloodGroup.ABPositive => "AB+",
        BloodGroup.ABNegative => "AB-",
        BloodGroup.OPositive => "O+",
        BloodGroup.ONegative => "O-",
        _ => group.ToString()
    };
}
