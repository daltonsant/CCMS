using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Data.Context;

namespace CCMS.NEOPE.Infra.Data.Repositories;

public class LinkedTaskRepository : Repository<LinkedTasks, ulong>, ILinkedTasksRepository
{
    public LinkedTaskRepository(ApplicationContext context) : base(context)
    {
    }
}