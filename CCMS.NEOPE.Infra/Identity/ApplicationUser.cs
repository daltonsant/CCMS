using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CCMS.NEOPE.Infra.Identity;

public class ApplicationUser : IdentityUser<string>,  IUser
{
    public string Code { get; set; } = string.Empty;
    
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Photo { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public bool IsFirstAccess { get; set; }
    
    public virtual ulong AccountableId { get; set; }
    public virtual Accountable Accountable { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public ICollection<TaskLog> Logs { get; set; } = new List<TaskLog>();

    public ApplicationUser()
    {
        
    }
}