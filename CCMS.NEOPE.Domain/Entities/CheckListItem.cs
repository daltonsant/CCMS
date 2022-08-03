using CCMS.NEOPE.Domain.Core.Models;

namespace CCMS.NEOPE.Domain.Entities;

public class CheckListItem : Entity<ulong>
{
    public string Name { get; set; }
    public bool Value { get; set; }
    public virtual TaskItem Task { get; set; }
}