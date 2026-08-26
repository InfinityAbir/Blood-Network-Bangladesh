using BloodNetwork.Application.Interfaces;

namespace BloodNetwork.Application.Services;

public class EligibilityService : IEligibilityService
{
    private static readonly List<EligibilityQuestionDto> Questions = new()
    {
        new EligibilityQuestionDto
        {
            Id = 1,
            QuestionBn = "আপনার বয়স কত?",
            QuestionEn = "What is your age?",
            QuestionBanglish = "Apnar boyosh koto?",
            QuestionType = "number",
            MinValue = 1,
            MaxValue = 120
        },
        new EligibilityQuestionDto
        {
            Id = 2,
            QuestionBn = "আপনার ওজন কত কেজি?",
            QuestionEn = "What is your weight in kg?",
            QuestionBanglish = "Apnar ojonoto koto kg?",
            QuestionType = "number",
            Unit = "kg",
            MinValue = 20,
            MaxValue = 200
        },
        new EligibilityQuestionDto
        {
            Id = 3,
            QuestionBn = "আপনি গত ৩ মাসে রক্তদান করেছেন?",
            QuestionEn = "Did you donate blood in the last 3 months?",
            QuestionBanglish = "Apni goto 3 mase rokto dan korechen?",
            QuestionType = "yesno"
        },
        new EligibilityQuestionDto
        {
            Id = 4,
            QuestionBn = "আপনি কি কোনো রোগের ওষুধ সেবন করছেন?",
            QuestionEn = "Are you currently taking any medication?",
            QuestionBanglish = "Apni ki kono rog er osudh sebon korchen?",
            QuestionType = "yesno"
        },
        new EligibilityQuestionDto
        {
            Id = 5,
            QuestionBn = "আপনি গর্ভবতী বা স্তন্যদানকারী মা?",
            QuestionEn = "Are you pregnant or breastfeeding?",
            QuestionBanglish = "Apni garhobati ba stanyodankari ma?",
            QuestionType = "yesno"
        },
        new EligibilityQuestionDto
        {
            Id = 6,
            QuestionBn = "আপনার গত ১ বছরে অস্ত্রপচার হয়েছে?",
            QuestionEn = "Have you had surgery in the last year?",
            QuestionBanglish = "Apnar goto 1 bochore ostropochar hoyeche?",
            QuestionType = "yesno"
        },
        new EligibilityQuestionDto
        {
            Id = 7,
            QuestionBn = "আপনি কি এখন অসুস্থ বা জ্বর আছে?",
            QuestionEn = "Are you currently sick or have a fever?",
            QuestionBanglish = "Apni ki ekhon osustho ba jhor ache?",
            QuestionType = "yesno"
        },
        new EligibilityQuestionDto
        {
            Id = 8,
            QuestionBn = "আপনার সাম্প্রতিক ওজন কি স্থিতিশীল?",
            QuestionEn = "Is your weight stable recently?",
            QuestionBanglish = "Apnar samprotik ojon ki sthitishil?",
            QuestionType = "yesno"
        }
    };

    private static readonly HashSet<int> CriticalQuestionIds = new() { 1, 2, 3, 6, 7 };

    public IReadOnlyList<EligibilityQuestionDto> GetQuestions()
    {
        return Questions.AsReadOnly();
    }

    public EligibilityResultDto EvaluateAnswers(IReadOnlyList<EligibilityAnswerDto> answers)
    {
        var answerDict = answers.ToDictionary(a => a.QuestionId);
        var checks = new List<EligibilityCheckDto>();
        int passedCritical = 0;
        int totalCritical = CriticalQuestionIds.Count;

        foreach (var question in Questions)
        {
            if (!answerDict.TryGetValue(question.Id, out var answer))
            {
                checks.Add(new EligibilityCheckDto
                {
                    QuestionId = question.Id,
                    Passed = false,
                    Message = "No answer provided",
                    MessageBn = "উত্তর প্রদান করা হয়নি"
                });
                continue;
            }

            var (passed, message, messageBn) = EvaluateQuestion(question, answer.Answer);

            checks.Add(new EligibilityCheckDto
            {
                QuestionId = question.Id,
                Passed = passed,
                Message = message,
                MessageBn = messageBn
            });

            if (CriticalQuestionIds.Contains(question.Id) && passed)
            {
                passedCritical++;
            }
        }

        int passedTotal = checks.Count(c => c.Passed);
        int score = Questions.Count > 0 ? (int)Math.Round((double)passedTotal / Questions.Count * 100) : 0;

        bool isEligible = passedCritical == totalCritical;

        string recommendationEn;
        string recommendationBn;

        if (isEligible)
        {
            recommendationEn = "You appear to be eligible to donate blood. Please visit your nearest blood donation center for final verification.";
            recommendationBn = "আপনি রক্তদানের জন্য যোগ্য বলে মনে হচ্ছে। চূড়ান্ত যাচাইয়ের জন্য দয়া করে আপনার নিকটতম রক্তদান কেন্দ্রে যান।";
        }
        else
        {
            var failedChecks = checks.Where(c => !c.Passed && CriticalQuestionIds.Contains(c.QuestionId)).ToList();
            recommendationEn = "You may not be eligible to donate blood at this time. " + string.Join(" ", failedChecks.Select(c => c.Message));
            recommendationBn = "আপনি এই মুহূর্তে রক্তদানের জন্য যোগ্য নাও হতে পারেন। " + string.Join(" ", failedChecks.Select(c => c.MessageBn));
        }

        return new EligibilityResultDto
        {
            IsEligible = isEligible,
            Score = score,
            Checks = checks,
            RecommendationBn = recommendationBn,
            RecommendationEn = recommendationEn
        };
    }

    private static (bool passed, string message, string messageBn) EvaluateQuestion(EligibilityQuestionDto question, string answer)
    {
        return question.Id switch
        {
            1 => EvaluateAge(answer),
            2 => EvaluateWeight(answer),
            3 => EvaluateRecentDonation(answer),
            4 => EvaluateMedication(answer),
            5 => EvaluatePregnancy(answer),
            6 => EvaluateSurgery(answer),
            7 => EvaluateIllness(answer),
            8 => EvaluateWeightStability(answer),
            _ => (false, "Unknown question", "অজানা প্রশ্ন")
        };
    }

    private static (bool passed, string message, string messageBn) EvaluateAge(string answer)
    {
        if (int.TryParse(answer, out var age))
        {
            if (age >= 18 && age <= 65)
                return (true, "Age is within eligible range (18-65).", "বয়স যোগ্য পরিসীমার মধ্যে (১৮-৬৫)।");
            return (false, $"Age {age} is outside eligible range (18-65).", $"বয়স {age} যোগ্য পরিসীমার বাইরে (১৮-৬৫)।");
        }
        return (false, "Invalid age provided.", "অবৈধ বয়স প্রদান করা হয়েছে।");
    }

    private static (bool passed, string message, string messageBn) EvaluateWeight(string answer)
    {
        if (int.TryParse(answer, out var weight))
        {
            if (weight >= 50)
                return (true, "Weight meets minimum requirement (≥50 kg).", "ওজন ন্যূনতম চাহিদা পূরণ করে (≥৫০ কেজি)।");
            return (false, $"Weight {weight} kg is below minimum (50 kg).", $"ওজন {weight} কেজি ন্যূনতমের কম (৫০ কেজি)।");
        }
        return (false, "Invalid weight provided.", "অবৈধ ওজন প্রদান করা হয়েছে।");
    }

    private static (bool passed, string message, string messageBn) EvaluateRecentDonation(string answer)
    {
        var isYes = IsYesAnswer(answer);
        if (!isYes)
            return (true, "No recent donation within 3 months.", "গত ৩ মাসে কোনো রক্তদান হয়নি।");
        return (false, "Donated blood within the last 3 months. Must wait.", "গত ৩ মাসের মধ্যে রক্তদান করেছেন। অপেক্ষা করুন।");
    }

    private static (bool passed, string message, string messageBn) EvaluateMedication(string answer)
    {
        var isYes = IsYesAnswer(answer);
        if (!isYes)
            return (true, "Not currently taking medication.", "বর্তমানে কোনো ওষুধ সেবন করছেন না।");
        return (false, "Currently taking medication. Please consult a doctor.", "বর্তমানে ওষুধ সেবন করছেন। দয়া করে চিকিৎসকের পরামর্শ নিন।");
    }

    private static (bool passed, string message, string messageBn) EvaluatePregnancy(string answer)
    {
        var isYes = IsYesAnswer(answer);
        if (!isYes)
            return (true, "Not pregnant or breastfeeding.", "গর্ভবতী বা স্তন্যদানকারী মা নন।");
        return (false, "Pregnant or breastfeeding donors are not eligible.", "গর্ভবতী বা স্তন্যদানকারী মাদের যোগ্য নন।");
    }

    private static (bool passed, string message, string messageBn) EvaluateSurgery(string answer)
    {
        var isYes = IsYesAnswer(answer);
        if (!isYes)
            return (true, "No surgery in the last year.", "গত ১ বছরে কোনো অস্ত্রপচার হয়নি।");
        return (false, "Had surgery in the last year. Must wait at least 1 year.", "গত ১ বছরে অস্ত্রপচার হয়েছে। কমপক্ষে ১ বছর অপেক্ষা করুন।");
    }

    private static (bool passed, string message, string messageBn) EvaluateIllness(string answer)
    {
        var isYes = IsYesAnswer(answer);
        if (!isYes)
            return (true, "Not currently sick or feverish.", "এখন অসুস্থ বা জ্বর নেই।");
        return (false, "Currently sick or have a fever. Wait until recovered.", "এখন অসুস্থ বা জ্বর আছে। সুস্থ না হওয়া পর্যন্ত অপেক্ষা করুন।");
    }

    private static (bool passed, string message, string messageBn) EvaluateWeightStability(string answer)
    {
        var isYes = IsYesAnswer(answer);
        if (isYes)
            return (true, "Weight is stable recently.", "সাম্প্রতিক ওজন স্থিতিশীল।");
        return (false, "Weight is not stable. Must have stable weight to donate.", "ওজন স্থিতিশীল নয়। রক্তদানের জন্য স্থিতিশীল ওজন প্রয়োজন।");
    }

    private static bool IsYesAnswer(string answer)
    {
        var normalized = answer.Trim().ToLowerInvariant();
        return normalized is "yes" or "হ্যাঁ" or "ha" or "haa" or "h" or "true" or "1";
    }
}
