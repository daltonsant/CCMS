using CCMS.NEOPE.Domain.Core.Models;

namespace CCMS.NEOPE.Domain.Entities;

public class TaskStep : Entity<int>
{
    public string Name { get; set; } = string.Empty;
}