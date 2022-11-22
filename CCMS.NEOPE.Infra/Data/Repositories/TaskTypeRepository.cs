using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Data.Context;

namespace CCMS.NEOPE.Infra.Data.Repositories;

public class TaskTypeRepository : Repository<TaskType,ulong>, ITaskTypeRepository
{
    public TaskTypeRepository(ApplicationContext context) : base(context)
    {
    }
}