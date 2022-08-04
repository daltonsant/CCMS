using CCMS.NEOPE.Domain.Core.Models;
using CCMS.NEOPE.Domain.Enums;

namespace CCMS.NEOPE.Domain.Entities;

public class LinkedTasks : Entity<ulong>
{
    public ulong SubjectTaskId { get; set; } 
    public virtual TaskItem? SubjectTask { get; set; }

    public LinkType Type { get; set; }
    
    public virtual ulong ObjectTaskId { get; set; }
    public virtual TaskItem? ObjectTask { get; set; }
}