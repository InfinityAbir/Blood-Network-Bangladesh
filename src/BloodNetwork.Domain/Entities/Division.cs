using BloodNetwork.Domain.Common;

namespace BloodNetwork.Domain.Entities;

public class Division : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string NameBn { get; set; } = string.Empty;
    public ICollection<District> Districts { get; set; } = new List<District>();
}
