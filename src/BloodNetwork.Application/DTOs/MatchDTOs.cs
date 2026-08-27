using BloodNetwork.Domain.Enums;

namespace BloodNetwork.Application.DTOs;

public class BloodRequestMatchDto
{
    public Guid Id { get; set; }
    public Guid BloodRequestId { get; set; }
    public Guid DonorId { get; set; }
    public string DonorName { get; set; } = string.Empty;
    public string DonorPhone { get; set; } = string.Empty;
    public string DonorBloodGroup { get; set; } = string.Empty;
    public string HospitalName { get; set; } = string.Empty;
    public Guid? RequesterId { get; set; }
    public string RequesterName { get; set; } = string.Empty;
    public string RequesterPhone { get; set; } = string.Empty;
    public int MatchScore { get; set; }
    public double? DistanceKm { get; set; }
    public DonorResponse DonorResponse { get; set; }
    public DateTime? ContactedAt { get; set; }
    public DateTime? RespondedAt { get; set; }
    public DateTime? AcceptedAt { get; set; }
    public DateTime? DeclinedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class PublicBloodRequestMatchDto
{
    public Guid Id { get; set; }
    public Guid BloodRequestId { get; set; }
    public string DonorName { get; set; } = string.Empty;
    public string DonorBloodGroup { get; set; } = string.Empty;
    public int MatchScore { get; set; }
    public double? DistanceKm { get; set; }
    public DonorResponse DonorResponse { get; set; }
    public DateTime? ContactedAt { get; set; }
    public DateTime? RespondedAt { get; set; }
    public DateTime? AcceptedAt { get; set; }
    public DateTime? DeclinedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class RespondToMatchRequest
{
    public DonorResponse Response { get; set; }
}

public class MatchSearchRequest
{
    public Guid? BloodRequestId { get; set; }
    public Guid? DonorId { get; set; }
    public DonorResponse? DonorResponse { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
