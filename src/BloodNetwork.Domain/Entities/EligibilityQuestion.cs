using BloodNetwork.Domain.Common;

namespace BloodNetwork.Domain.Entities;

public class EligibilityQuestion : BaseEntity
{
    public string QuestionEn { get; set; } = string.Empty;
    public string QuestionBn { get; set; } = string.Empty;
    public string QuestionBanglish { get; set; } = string.Empty;

    /// <summary>"number" or "yesno".</summary>
    public string QuestionType { get; set; } = string.Empty;

    public string? Unit { get; set; }

    /// <summary>Number questions only — inclusive pass-range bounds (also used as the input's min/max hint). Null means unbounded on that side.</summary>
    public int? MinValue { get; set; }
    public int? MaxValue { get; set; }

    /// <summary>Yes/no questions only — whether answering "Yes" counts as passing (e.g. false for "are you sick?", true for "is your weight stable?").</summary>
    public bool? PassOnYes { get; set; }

    /// <summary>Whether failing this question alone makes the donor ineligible, vs. just lowering the score.</summary>
    public bool IsCritical { get; set; }

    /// <summary>Admin on/off switch, separate from IsDeleted — an inactive question is hidden
    /// from the public questionnaire but still visible (and re-activatable) in the admin list.
    /// IsDeleted is reserved for actually removing a mistakenly-created question.</summary>
    public bool IsActive { get; set; } = true;

    public int DisplayOrder { get; set; }

    public string PassMessageEn { get; set; } = string.Empty;
    public string PassMessageBn { get; set; } = string.Empty;
    public string FailMessageEn { get; set; } = string.Empty;
    public string FailMessageBn { get; set; } = string.Empty;
}
