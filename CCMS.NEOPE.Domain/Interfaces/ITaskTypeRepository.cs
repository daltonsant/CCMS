using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Domain.Entities;

namespace CCMS.NEOPE.Domain.Interfaces;

public interface ITaskTypeRepository : IGenericRepository<Entities.PendencyType, ulong>
{
    
}