using BloodNetwork.Domain.Entities;

namespace BloodNetwork.Application.Interfaces;

public interface IMatchEnhancementService
{
    Task<IReadOnlyList<EnhancedMatchDto>> GetEnhancedMatchesAsync(
        Guid requestId, IReadOnlyList<BloodRequestMatch> rawMatches);
    Task<EnhancedMatchDto> EnhanceSingleMatchAsync(
        BloodRequestMatch match, double? requestLat, double? requestLon);
}

public class EnhancedMatchDto
{
    public Guid MatchId { get; set; }
    public Guid DonorId { get; set; }
    public string DonorName { get; set; } = string.Empty;
    public int OriginalScore { get; set; }
    public int AcceptanceProbability { get; set; }
    public int CombinedScore { get; set; }
    public string Priority { get; set; } = string.Empty;
}
