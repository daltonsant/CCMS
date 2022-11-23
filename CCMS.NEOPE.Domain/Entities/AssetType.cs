using CCMS.NEOPE.Domain.Core.Models;

namespace CCMS.NEOPE.Domain.Entities;

public class AssetType: Entity<ulong>
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public ICollection<Asset> AssetsByType { get; set; }
    public ICollection<Step> AllowedSteps { get; set; }
}