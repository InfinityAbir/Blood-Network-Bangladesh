using BloodNetwork.Application.Interfaces;
using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Interfaces;

namespace BloodNetwork.Application.Services;

public class EligibilityService : IEligibilityService
{
    private readonly IRepository<EligibilityQuestion> _questionRepo;

    public EligibilityService(IRepository<EligibilityQuestion> questionRepo)
    {
        _questionRepo = questionRepo;
    }

    public async Task<IReadOnlyList<EligibilityQuestionDto>> GetQuestionsAsync()
    {
        var questions = await _questionRepo.ToListAsync(
            _questionRepo.Query().Where(q => q.IsActive).OrderBy(q => q.DisplayOrder));
        return questions.Select(MapToDto).ToList();
    }

    public async Task<EligibilityResultDto> EvaluateAnswersAsync(IReadOnlyList<EligibilityAnswerDto> answers)
    {
        // Active-only: an answer to a question an admin just deactivated shouldn't gate eligibility.
        var questions = await _questionRepo.ToListAsync(
            _questionRepo.Query().Where(q => q.IsActive).OrderBy(q => q.DisplayOrder));
        var answerDict = answers.ToDictionary(a => a.QuestionId);
        var checks = new List<EligibilityCheckDto>();
        var criticalQuestions = questions.Where(q => q.IsCritical).ToList();
        int passedCritical = 0;

        foreach (var question in questions)
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

            if (question.IsCritical && passed)
            {
                passedCritical++;
            }
        }

        int passedTotal = checks.Count(c => c.Passed);
        int score = questions.Count > 0 ? (int)Math.Round((double)passedTotal / questions.Count * 100) : 0;

        bool isEligible = passedCritical == criticalQuestions.Count;

        string recommendationEn;
        string recommendationBn;

        if (isEligible)
        {
            recommendationEn = "You appear to be eligible to donate blood. Please visit your nearest blood donation center for final verification.";
            recommendationBn = "আপনি রক্তদানের জন্য যোগ্য বলে মনে হচ্ছে। চূড়ান্ত যাচাইয়ের জন্য দয়া করে আপনার নিকটতম রক্তদান কেন্দ্রে যান।";
        }
        else
        {
            var criticalIds = criticalQuestions.Select(q => q.Id).ToHashSet();
            var failedChecks = checks.Where(c => !c.Passed && criticalIds.Contains(c.QuestionId)).ToList();
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

    /// <summary>
    /// Generic pass/fail rule, driven entirely by data on the question (no per-question code):
    /// number questions pass when the answer falls within [MinValue, MaxValue] (either bound
    /// may be null/unbounded); yes/no questions pass based on PassOnYes.
    /// </summary>
    private static (bool passed, string message, string messageBn) EvaluateQuestion(EligibilityQuestion question, string answer)
    {
        if (question.QuestionType == "number")
        {
            if (!int.TryParse(answer, out var value))
            {
                return (false, "Invalid value provided.", "অবৈধ মান প্রদান করা হয়েছে।");
            }

            bool passed = (question.MinValue == null || value >= question.MinValue)
                && (question.MaxValue == null || value <= question.MaxValue);

            var template = passed ? question.PassMessageEn : question.FailMessageEn;
            var templateBn = passed ? question.PassMessageBn : question.FailMessageBn;
            return (passed, template.Replace("{value}", value.ToString()), templateBn.Replace("{value}", value.ToString()));
        }

        // yesno
        var isYes = IsYesAnswer(answer);
        bool yesPasses = question.PassOnYes ?? false;
        bool result = isYes == yesPasses;
        return (result, result ? question.PassMessageEn : question.FailMessageEn, result ? question.PassMessageBn : question.FailMessageBn);
    }

    private static bool IsYesAnswer(string answer)
    {
        var normalized = answer.Trim().ToLowerInvariant();
        return normalized is "yes" or "হ্যাঁ" or "ha" or "haa" or "h" or "true" or "1";
    }

    private static EligibilityQuestionDto MapToDto(EligibilityQuestion q) => new()
    {
        Id = q.Id,
        QuestionBn = q.QuestionBn,
        QuestionEn = q.QuestionEn,
        QuestionBanglish = q.QuestionBanglish,
        QuestionType = q.QuestionType,
        Unit = q.Unit,
        MinValue = q.MinValue,
        MaxValue = q.MaxValue,
    };
}
