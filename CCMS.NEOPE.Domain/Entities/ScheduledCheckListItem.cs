using CCMS.NEOPE.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.NEOPE.Domain.Entities
{
    public class ScheduledCheckListItem : Entity<ulong>
    {
        public virtual string Name { get; set; }
        public virtual bool Value { get; set; }
        public virtual ScheduledTask ScheduledTask { get; set; }
    }
}
