using CCMS.NEOPE.Domain.Core.Models;

namespace CCMS.NEOPE.Domain.Entities;

public class Label: Entity<int>
{
    public string Title { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    
    public ICollection<TaskItem> Tasks { get; set; }
}