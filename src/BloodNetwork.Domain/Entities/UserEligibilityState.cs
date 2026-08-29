using BloodNetwork.Domain.Common;

namespace BloodNetwork.Domain.Entities;

/// <summary>
/// Per-user persisted eligibility answers + result, so a user logging out and back in
/// (same device or different device via website) still sees their last check.
/// Keyed by UserId (unique) — one row per user, never shared across users.
/// </summary>
public class UserEligibilityState : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    /// <summary>JSON array of EligibilityAnswerDto (QuestionId + Answer)</summary>
    public string AnswersJson { get; set; } = "[]";

    /// <summary>JSON object of EligibilityResultDto</summary>
    public string ResultJson { get; set; } = "{}";
}
