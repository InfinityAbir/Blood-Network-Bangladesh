using BloodNetwork.Domain.Entities;
using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.Interfaces;

public interface IMatchingService
{
    Task<IReadOnlyList<BloodRequestMatch>> MatchRequestAsync(Guid requestId);
    Task<IReadOnlyList<BloodRequestMatch>> GetMatchesForRequestAsync(Guid requestId);
    Task<IReadOnlyList<BloodRequestMatch>> GetMatchesForDonorAsync(Guid donorId);
    Task<BloodRequestMatch?> GetMatchByIdAsync(Guid matchId);
    Task<BloodRequestMatch?> RespondToMatchAsync(Guid matchId, Guid userId, DonorResponse response);
}
