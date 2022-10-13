using CCMS.NEOPE.Domain.Core.Models;

namespace CCMS.NEOPE.Domain.Entities;

public class PendencyType : Entity<ulong>
{
    public virtual string Name { get; set; }
    public virtual ICollection<Pendency> PendenciesByType { get; set; } = new List<Pendency>();
}