using CCMS.NEOPE.Domain.Entities;

namespace CCMS.NEOPE.Domain.Interfaces;

public interface IUser
{
    string Code { get; set; }
    string FullName { get; set; }
    string? Photo { get; set; }
    
    bool IsActive { get; set; }
    
    ICollection<TaskItem> ReportedTasks { get; set; }
    ICollection<TaskItem> AssignedTasks { get; set; }
    
    ICollection<Comment> Comments { get; set; }
    
    ICollection<TaskLog> Logs { get; set; }
}