using CCMS.NEOPE.Domain.Core.Models;
using CCMS.NEOPE.Domain.Interfaces;

namespace CCMS.NEOPE.Domain.Entities;

public class Comment : Entity<ulong>
{
    public string Content { get; set; } = string.Empty;
    public IUser? User { get; set; } = null;
    public AssetProjectStatus? AssetStatus { get; set; } = null;
}