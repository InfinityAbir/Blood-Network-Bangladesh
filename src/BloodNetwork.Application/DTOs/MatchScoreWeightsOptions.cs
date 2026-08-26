namespace BloodNetwork.Application.DTOs;

public class MatchScoreWeightsOptions
{
    public int ExactBloodGroup { get; set; } = 30;
    public int CompatibleBloodGroup { get; set; } = 0;
    public int Available { get; set; } = 30;
    public int Unknown { get; set; } = 0;
    public int Verified { get; set; } = 15;
    public int Pending { get; set; } = 5;
    public int Unverified { get; set; } = 0;
    public int ProfileFreshness { get; set; } = 10;
    public int Distance0to3km { get; set; } = 15;
    public int Distance3to10km { get; set; } = 10;
    public int Distance10to25km { get; set; } = 5;
    public int DistanceOver25km { get; set; } = 0;
}
