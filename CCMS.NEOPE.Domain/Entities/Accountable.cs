using CCMS.NEOPE.Domain.Core.Models;
using CCMS.NEOPE.Domain.Interfaces;

namespace CCMS.NEOPE.Domain.Entities;

public class Accountable : Entity<ulong>
{
    public string Code { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Sector { get; set; }

    public virtual ICollection<TaskItem> ReportedTasks { get; set; } = new List<TaskItem>();
    public virtual ICollection<TaskItem> AssignedTasks { get; set; } = new List<TaskItem>();
    public virtual IUser? User { get; set; } 
}   
 