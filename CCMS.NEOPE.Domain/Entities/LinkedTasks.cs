using CCMS.NEOPE.Domain.Core.Models;
using CCMS.NEOPE.Domain.Enums;

namespace CCMS.NEOPE.Domain.Entities;

public class LinkedTasks : Entity<ulong>
{
    public TaskItem? LinkSubject
    {
        get { return Tasks.FirstOrDefault(); }
    }

    public LinkType Type { get; set; }
    public TaskItem? LinkObject {
        get
        {
            var tasks = Tasks.ToList();
            return tasks.Count == 2 ? tasks[1] : null;
        } 
    }

    public virtual ICollection<TaskItem> Tasks { get; set; }
}