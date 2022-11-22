using CCMS.NEOPE.Domain.Core.Models;
using CCMS.NEOPE.Domain.Enums;
using CCMS.NEOPE.Domain.Interfaces;
using TaskStatus = CCMS.NEOPE.Domain.Enums.TaskStatus;


namespace CCMS.NEOPE.Domain.Entities;

public class TaskItem : Entity<ulong>
{
    public Project? Project { get; set; } = null;
    public string? Title { get; set; } = null;

    public string? SapNoteNumber { get; set; } = null;
    
    public Category Category { get; set; }
    
    public TaskPriority? Priority { get; set; }
    public string? Description { get; set; } = string.Empty;
    public Type Type { get; set; }
    public TaskStatus Status { get; set; }
    public Step Step { get; set; } = null;
    public TaskItem? ParentTask { get; set; } = null;
    public virtual ICollection<TaskItem> ChildTasks { get; set; } = new List<TaskItem>();
    public virtual ICollection<LinkedTasks> LinkedObjectTasks { get; set; } = new List<LinkedTasks>();
    public virtual ICollection<LinkedTasks> LinkedSubjectTasks { get; set; } = new List<LinkedTasks>();
    public DateTime? StartDate { get; set; } = null;
    public DateTime? DueDate { get; set; } = null;
    public virtual DateTime? PlannedDate { get; set; } = null;
    public virtual DateTime? CompletedDate { get; set; } = null;
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
    public virtual ICollection<Label> Labels { get; set; } = new List<Label>();
    public virtual ICollection<Accountable> Assignees { get; set; } = new List<Accountable>();
    public virtual Accountable? Reporter { get; set; } = null;
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    public virtual ICollection<TaskLog> Logs { get; set; } = new List<TaskLog>();
    public virtual ICollection<CheckListItem> CheckListItems { get; set; } = new List<CheckListItem>();
    public virtual int Order { get; set; }
}