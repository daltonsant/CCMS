using CCMS.NEOPE.Domain.Core.Models;

namespace CCMS.NEOPE.Domain.Entities;

public class Step : Entity<int>
{
    public string Name { get; set; } = string.Empty;
    public ICollection<AssetType> AssetTypes { get; set;}
}