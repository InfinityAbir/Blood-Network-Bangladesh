namespace BloodNetwork.Application.Interfaces;

public interface IEligibilityService
{
    IReadOnlyList<EligibilityQuestionDto> GetQuestions();
    EligibilityResultDto EvaluateAnswers(IReadOnlyList<EligibilityAnswerDto> answers);
}

public class EligibilityQuestionDto
{
    public int Id { get; set; }
    public string QuestionBn { get; set; } = string.Empty;
    public string QuestionEn { get; set; } = string.Empty;
    public string QuestionBanglish { get; set; } = string.Empty;
    public string QuestionType { get; set; } = string.Empty;
    public string? Unit { get; set; }
    public int MinValue { get; set; }
    public int MaxValue { get; set; }
}

public class EligibilityAnswerDto
{
    public int QuestionId { get; set; }
    public string Answer { get; set; } = string.Empty;
}

public class EligibilityResultDto
{
    public bool IsEligible { get; set; }
    public int Score { get; set; }
    public List<EligibilityCheckDto> Checks { get; set; } = new();
    public string RecommendationBn { get; set; } = string.Empty;
    public string RecommendationEn { get; set; } = string.Empty;
}

public class EligibilityCheckDto
{
    public int QuestionId { get; set; }
    public bool Passed { get; set; }
    public string Message { get; set; } = string.Empty;
    public string MessageBn { get; set; } = string.Empty;
}
