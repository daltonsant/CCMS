using CCMS.NEOPE.Domain.Core.Models;
using CCMS.NEOPE.Domain.Interfaces;

namespace CCMS.NEOPE.Domain.Entities;

public class TaskLog : Entity<ulong>
{
    public string Log { get; set; } = string.Empty;
    public virtual IUser? User { get; set; } = null;

    public virtual TaskItem? Task { get; set; } = null;
}