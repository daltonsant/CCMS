using CCMS.NEOPE.Domain.Core.Models;

namespace CCMS.NEOPE.Domain.Entities;

public class Attachment : Entity<ulong>
{
    public int Size { get; set; }
    public string Name { get; set; } = string.Empty;
    public byte[] Data { get; set; } = new byte[0];
    public virtual TaskItem? Task { get; set; } = null;
    public virtual Pendency? Pendency { get; set; } = null;
}