using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Data.Context;

namespace CCMS.NEOPE.Infra.Data.Repositories;

public class ProjectRepository : Repository<Project,ulong>, IProjectRepository
{
    public ProjectRepository(ApplicationContext context) : base(context)
    {
    }
    
    
}