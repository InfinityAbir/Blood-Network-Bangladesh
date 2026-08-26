using BloodNetwork.Domain.Common;

namespace BloodNetwork.Domain.Entities;

public class Upazila : BaseEntity
{
    public Guid DistrictId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;

    public District District { get; set; } = null!;
}
