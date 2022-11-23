using CCMS.NEOPE.Domain.Core.Models;

namespace CCMS.NEOPE.Domain.Entities;

public class Attachment : Entity<ulong>
{
    public int Size { get; set; }
    public string Path { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    
    public virtual AssetProjectStatus? AssetStatus { get; set; } = null;
}