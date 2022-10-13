using CCMS.NEOPE.Domain.Core.Models;
using CCMS.NEOPE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.NEOPE.Domain.Entities;
public class ScheduledTask : Entity<ulong>
{
    public int Order { get; set; }
    public virtual AssetType AssetType { get; set; }
    public virtual Category Category { get; set; }
    public virtual PendencyType TaskType { get; set; }
    public virtual Step TaskStep { get; set; }
    public virtual Priority Priority { get; set; }
    public virtual ICollection<ScheduledCheckListItem> ScheduledCheckListItems { get; set; } = new List<ScheduledCheckListItem>();
}
