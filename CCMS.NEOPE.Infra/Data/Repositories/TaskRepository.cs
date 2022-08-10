using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Data.Context;

namespace CCMS.NEOPE.Infra.Data.Repositories;

public class TaskRepository : Repository<TaskItem, ulong>, ITaskRepository
{
    public TaskRepository(ApplicationContext context) : base(context)
    {
    }
}