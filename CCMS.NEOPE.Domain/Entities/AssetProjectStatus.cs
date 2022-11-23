using CCMS.NEOPE.Domain.Core.Models;

namespace CCMS.NEOPE.Domain.Entities;

public class AssetProjectStatus : Entity<ulong>
{
    public virtual Step Step { get; set; }
    public virtual TaskStatus Status { get; set; }
    public virtual DateTime? StartDate { get; set; }
    public virtual DateTime? DueDate { get; set; }
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();
    public virtual Asset Asset { get; set; }
}