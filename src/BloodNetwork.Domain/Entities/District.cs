using BloodNetwork.Domain.Common;

namespace BloodNetwork.Domain.Entities;

public class District : BaseEntity
{
    public Guid DivisionId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;

    public Division Division { get; set; } = null!;
    public ICollection<Upazila> Upazilas { get; set; } = new List<Upazila>();
}
