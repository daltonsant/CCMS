using CCMS.NEOPE.Domain.Core.Models;

namespace CCMS.NEOPE.Domain.Entities;

public class Project : Entity<ulong>
{
    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
    public virtual ICollection<Pendency> Pendencies { get; set; } = new List<Pendency>();

    public virtual ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
}
