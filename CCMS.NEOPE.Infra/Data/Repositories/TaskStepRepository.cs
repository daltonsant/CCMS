using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Data.Context;

namespace CCMS.NEOPE.Infra.Data.Repositories;

public class TaskStepRepository : Repository<TaskStep, int>, ITaskStepRepository
{
    public TaskStepRepository(ApplicationContext context) : base(context)
    {
    }
}