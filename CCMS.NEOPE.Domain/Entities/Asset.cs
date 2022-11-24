using CCMS.NEOPE.Domain.Core.Models;

namespace CCMS.NEOPE.Domain.Entities;

public class Asset : Entity<ulong>
{
    public string Description { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    
    public AssetType Type { get; set; }

    public AssetProjectStatus Status { get; set; }
    public virtual Project Project { get; set; }
}