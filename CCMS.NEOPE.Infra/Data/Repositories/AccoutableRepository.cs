using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Data.Context;

namespace CCMS.NEOPE.Infra.Data.Repositories;

public class AccountableRepository : Repository<Accountable,ulong>, IAccountableRepository
{
    public AccountableRepository(ApplicationContext context) : base(context)
    {
    }
}