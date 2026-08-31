namespace BloodNetwork.Domain.Enums;

public enum VerificationStatus
{
    Unverified = 0,
    [Obsolete("Pending status removed - was dead state (never set). Use Unverified for awaiting verification.")]
    Pending = 1,
    Verified = 2,
    Rejected = 3
}
