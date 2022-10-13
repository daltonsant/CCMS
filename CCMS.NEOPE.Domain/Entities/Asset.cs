using CCMS.NEOPE.Domain.Core.Models;

namespace CCMS.NEOPE.Domain.Entities;

public class Asset : Entity<ulong>
{
    public string Description { get; set; } = string.Empty;
    public string PmCode { get; set; } = string.Empty;
    public string InstalationLoc { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public virtual AssetType Type { get; set; }
    public virtual ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    public virtual ICollection<Pendency> Pendencies { get; set; } = new List<Pendency>();
    public virtual Project Project { get; set; }
}
