using CCMS.NEOPE.Domain.Core.Models;
using CCMS.NEOPE.Domain.Enums;

namespace CCMS.NEOPE.Domain.Entities;

public class AssetProjectStatus : Entity<ulong>
{
    public virtual Step? Step { get; set; }
    public virtual Status Status { get; set; }
    public virtual DateTime? StartDate { get; set; }
    public virtual DateTime? DueDate { get; set; }
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
    public virtual ICollection<Accountable> Assignees { get; set; } = new List<Accountable>();
    public virtual Asset Asset { get; set; }
    public virtual Category? Category { get; set; }
    
}