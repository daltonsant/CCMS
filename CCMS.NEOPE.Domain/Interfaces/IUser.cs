using CCMS.NEOPE.Domain.Entities;

namespace CCMS.NEOPE.Domain.Interfaces;

public interface IUser
{
    string Code { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string? Photo { get; set; }
    
    bool IsActive { get; set; }

    ulong AccountableId { get; set; }
    Accountable Accountable { get; set; }

}