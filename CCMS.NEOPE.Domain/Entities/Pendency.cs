using CCMS.NEOPE.Domain.Core.Models;
using CCMS.NEOPE.Domain.Enums;
using CCMS.NEOPE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.NEOPE.Domain.Entities;

public class Pendency : Entity<ulong>
{
    public virtual Project? Project { get; set; }
    public virtual TaskItem? Task { get; set; }
    public virtual Asset? Asset { get; set; }
    public string? Title { get; set; } = null;
    public string? SapNoteNumber { get; set; } = null;
    public virtual Category Category { get; set; }
    public Priority? Priority { get; set; }
    public string? Description { get; set; } = string.Empty;
    public PendencyType Type { get; set; }
    public Status Status { get; set; }
    public virtual Step Step { get; set; } = null;
    public DateTime? StartDate { get; set; } = null;
    public DateTime? DueDate { get; set; } = null;
    public virtual ICollection<Accountable> Assignees { get; set; } = new List<Accountable>();
    public virtual Accountable? Reporter { get; set; } = null;
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    public virtual ICollection<CheckListItem> CheckListItems { get; set; } = new List<CheckListItem>();
}
