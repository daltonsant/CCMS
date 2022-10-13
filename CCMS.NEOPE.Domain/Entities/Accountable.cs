using CCMS.NEOPE.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.NEOPE.Domain.Entities;
public class Accountable : Entity<ulong>
{
    public string DisplayName { get; set; }
}
