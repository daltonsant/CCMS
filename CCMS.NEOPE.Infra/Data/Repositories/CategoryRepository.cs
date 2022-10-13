using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Data.Context;

namespace CCMS.NEOPE.Infra.Data.Repositories;

public class CategoryRepository : Repository<Category, int>, ICategoryRepository
{
    public CategoryRepository(ApplicationContext context) : base(context)
    {
    }
}