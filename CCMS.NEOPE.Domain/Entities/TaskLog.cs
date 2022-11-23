using CCMS.NEOPE.Domain.Core.Models;
using CCMS.NEOPE.Domain.Interfaces;

namespace CCMS.NEOPE.Domain.Entities;

public class Log : Entity<ulong>
{
    public string Text { get; set; } = string.Empty;
    public virtual AssetProjectStatus? AssetStatus { get; set; }
}