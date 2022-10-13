using CCMS.NEOPE.Domain.Core.Models;

namespace CCMS.NEOPE.Domain.Entities;

public class Category : Entity<int>
{
    public virtual string Name { get; set; }

    public virtual ICollection<TaskItem> TaskItemsByCategory { get; set; } = new List<TaskItem>();
    public virtual ICollection<Pendency> PendenciesByCategory { get; set; } = new List<Pendency>();
}