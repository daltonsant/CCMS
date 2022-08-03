using CCMS.NEOPE.Domain.Core.Models;
using CCMS.NEOPE.Domain.Enums;
using CCMS.NEOPE.Domain.Interfaces;

namespace CCMS.NEOPE.Domain.Entities;

public class TaskItem : Entity<ulong>
{
    public ulong Key { get; protected set; }
    public Project? Project { get; set; } = null;
    public string? Title { get; set; } = null;
    
    public TaskPriority Priority { get; set; }
    public string Description { get; set; } = string.Empty;
    public TaskStep? Step { get; set; } = null;
    public TaskItem? ParentTask { get; set; } = null;
    public virtual ICollection<TaskItem> ChildTasks { get; set; } = new List<TaskItem>();
    public virtual ICollection<LinkedTasks> LinkedTasks { get; set; } = new List<LinkedTasks>();
    public DateTime? StartDate { get; set; } = null;
    public DateTime? DueDate { get; set; } = null;
    public virtual DateTime? PlannedDate { get; set; } = null;
    public virtual DateTime? CompletedDate { get; set; } = null;
    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
    public virtual ICollection<Label> Labels { get; set; } = new List<Label>();
    public virtual ICollection<IUser> Assignees { get; set; } = new List<IUser>();
    public virtual IUser? Reporter { get; set; } = null;
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    public virtual ICollection<TaskLog> Logs { get; set; } = new List<TaskLog>();
    public virtual ICollection<CheckListItem> CheckListItems { get; set; } = new List<CheckListItem>();
}