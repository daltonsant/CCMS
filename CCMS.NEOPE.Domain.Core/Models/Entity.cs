namespace CCMS.NEOPE.Domain.Core.Models;

public abstract class Entity<TKey>
{
    public virtual TKey Id { get; set; }
    public virtual DateTime CreateDate { get; set; }

    public virtual DateTime? UpdateDate { get; set; }
}