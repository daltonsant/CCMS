using CCMS.NEOPE.Domain.Core.Models;
using CCMS.NEOPE.Domain.Enums;
using CCMS.NEOPE.Domain.Interfaces;
using TaskStatus = CCMS.NEOPE.Domain.Enums.Status;


namespace CCMS.NEOPE.Domain.Entities;

public class TaskItem : Entity<ulong>
{
    public virtual Project? Project { get; set; } = null;
    public virtual Asset? Asset { get; set; } = null;
    public string? Title { get; set; } = null;
    public Category Category { get; set; }
    public Priority? Priority { get; set; }
    public string? Description { get; set; } = string.Empty;
    public TaskType Type { get; set; }
    public TaskStatus Status { get; set; }
    public Step Step { get; set; } = null;
    public virtual ICollection<Pendency> Pendencies { get; set; } = new List<Pendency>();
    public virtual ICollection<LinkedTasks> LinkedObjectTasks { get; set; } = new List<LinkedTasks>();
    public virtual ICollection<LinkedTasks> LinkedSubjectTasks { get; set; } = new List<LinkedTasks>();
    public DateTime? StartDate { get; set; } = null;
    public DateTime? DueDate { get; set; } = null;
    public virtual ICollection<Accountable> Assignees { get; set; } = new List<Accountable>();
    public virtual Accountable? Reporter { get; set; } = null;
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    public virtual ICollection<TaskLog> Logs { get; set; } = new List<TaskLog>();
    public virtual ICollection<CheckListItem> CheckListItems { get; set; } = new List<CheckListItem>();
    public virtual int Order { get; set; }
}