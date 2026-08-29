using BloodNetwork.Domain.Entities;

namespace BloodNetwork.Infrastructure.Data.Seeds;

/// <summary>Initial question set, reproducing the behavior that used to be hardcoded in EligibilityService.</summary>
public static class EligibilityQuestionSeed
{
    public static List<EligibilityQuestion> GetQuestions()
    {
        return new List<EligibilityQuestion>
        {
            new()
            {
                Id = new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c01"),
                QuestionEn = "What is your age?",
                QuestionBn = "আপনার বয়স কত?",
                QuestionBanglish = "Apnar boyosh koto?",
                QuestionType = "number",
                MinValue = 18,
                MaxValue = 65,
                IsCritical = true,
                DisplayOrder = 1,
                PassMessageEn = "Age is within eligible range (18-65).",
                PassMessageBn = "বয়স যোগ্য পরিসীমার মধ্যে (১৮-৬৫)।",
                FailMessageEn = "Age {value} is outside eligible range (18-65).",
                FailMessageBn = "বয়স {value} যোগ্য পরিসীমার বাইরে (১৮-৬৫)।",
            },
            new()
            {
                Id = new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c02"),
                QuestionEn = "What is your weight in kg?",
                QuestionBn = "আপনার ওজন কত কেজি?",
                QuestionBanglish = "Apnar ojonoto koto kg?",
                QuestionType = "number",
                Unit = "kg",
                MinValue = 50,
                MaxValue = null,
                IsCritical = true,
                DisplayOrder = 2,
                PassMessageEn = "Weight meets minimum requirement (≥50 kg).",
                PassMessageBn = "ওজন ন্যূনতম চাহিদা পূরণ করে (≥৫০ কেজি)।",
                FailMessageEn = "Weight {value} kg is below minimum (50 kg).",
                FailMessageBn = "ওজন {value} কেজি ন্যূনতমের কম (৫০ কেজি)।",
            },
            new()
            {
                Id = new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c03"),
                QuestionEn = "Did you donate blood in the last 3 months?",
                QuestionBn = "আপনি গত ৩ মাসে রক্তদান করেছেন?",
                QuestionBanglish = "Apni goto 3 mase rokto dan korechen?",
                QuestionType = "yesno",
                PassOnYes = false,
                IsCritical = true,
                DisplayOrder = 3,
                PassMessageEn = "No recent donation within 3 months.",
                PassMessageBn = "গত ৩ মাসে কোনো রক্তদান হয়নি।",
                FailMessageEn = "Donated blood within the last 3 months. Must wait.",
                FailMessageBn = "গত ৩ মাসের মধ্যে রক্তদান করেছেন। অপেক্ষা করুন।",
            },
            new()
            {
                Id = new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c04"),
                QuestionEn = "Are you currently taking any medication?",
                QuestionBn = "আপনি কি কোনো রোগের ওষুধ সেবন করছেন?",
                QuestionBanglish = "Apni ki kono rog er osudh sebon korchen?",
                QuestionType = "yesno",
                PassOnYes = false,
                IsCritical = false,
                DisplayOrder = 4,
                PassMessageEn = "Not currently taking medication.",
                PassMessageBn = "বর্তমানে কোনো ওষুধ সেবন করছেন না।",
                FailMessageEn = "Currently taking medication. Please consult a doctor.",
                FailMessageBn = "বর্তমানে ওষুধ সেবন করছেন। দয়া করে চিকিৎসকের পরামর্শ নিন।",
            },
            new()
            {
                Id = new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c05"),
                QuestionEn = "Are you pregnant or breastfeeding?",
                QuestionBn = "আপনি গর্ভবতী বা স্তন্যদানকারী মা?",
                QuestionBanglish = "Apni garhobati ba stanyodankari ma?",
                QuestionType = "yesno",
                PassOnYes = false,
                IsCritical = true,
                DisplayOrder = 5,
                PassMessageEn = "Not pregnant or breastfeeding.",
                PassMessageBn = "গর্ভবতী বা স্তন্যদানকারী মা নন।",
                FailMessageEn = "Pregnant or breastfeeding donors are not eligible.",
                FailMessageBn = "গর্ভবতী বা স্তন্যদানকারী মাদের যোগ্য নন।",
            },
            new()
            {
                Id = new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c06"),
                QuestionEn = "Have you had surgery in the last year?",
                QuestionBn = "আপনার গত ১ বছরে অস্ত্রপচার হয়েছে?",
                QuestionBanglish = "Apnar goto 1 bochore ostropochar hoyeche?",
                QuestionType = "yesno",
                PassOnYes = false,
                IsCritical = true,
                DisplayOrder = 6,
                PassMessageEn = "No surgery in the last year.",
                PassMessageBn = "গত ১ বছরে কোনো অস্ত্রপচার হয়নি।",
                FailMessageEn = "Had surgery in the last year. Must wait at least 1 year.",
                FailMessageBn = "গত ১ বছরে অস্ত্রপচার হয়েছে। কমপক্ষে ১ বছর অপেক্ষা করুন।",
            },
            new()
            {
                Id = new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c07"),
                QuestionEn = "Are you currently sick or have a fever?",
                QuestionBn = "আপনি কি এখন অসুস্থ বা জ্বর আছে?",
                QuestionBanglish = "Apni ki ekhon osustho ba jhor ache?",
                QuestionType = "yesno",
                PassOnYes = false,
                IsCritical = true,
                DisplayOrder = 7,
                PassMessageEn = "Not currently sick or feverish.",
                PassMessageBn = "এখন অসুস্থ বা জ্বর নেই।",
                FailMessageEn = "Currently sick or have a fever. Wait until recovered.",
                FailMessageBn = "এখন অসুস্থ বা জ্বর আছে। সুস্থ না হওয়া পর্যন্ত অপেক্ষা করুন।",
            },
            new()
            {
                Id = new Guid("f1a2b3c4-d5e6-4a7b-8c9d-0e1f2a3b4c08"),
                QuestionEn = "Is your weight stable recently?",
                QuestionBn = "আপনার সাম্প্রতিক ওজন কি স্থিতিশীল?",
                QuestionBanglish = "Apnar samprotik ojon ki sthitishil?",
                QuestionType = "yesno",
                PassOnYes = true,
                IsCritical = false,
                DisplayOrder = 8,
                PassMessageEn = "Weight is stable recently.",
                PassMessageBn = "সাম্প্রতিক ওজন স্থিতিশীল।",
                FailMessageEn = "Weight is not stable. Must have stable weight to donate.",
                FailMessageBn = "ওজন স্থিতিশীল নয়। রক্তদানের জন্য স্থিতিশীল ওজন প্রয়োজন।",
            },
        };
    }
}
