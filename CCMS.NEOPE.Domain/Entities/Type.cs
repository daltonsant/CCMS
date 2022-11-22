using CCMS.NEOPE.Domain.Core.Models;

namespace CCMS.NEOPE.Domain.Entities;

public class Type : Entity<ulong>
{
    public virtual string Name { get; set; }

    public virtual ICollection<TaskItem> TaskItemsByType { get; set; } = new List<TaskItem>();
}