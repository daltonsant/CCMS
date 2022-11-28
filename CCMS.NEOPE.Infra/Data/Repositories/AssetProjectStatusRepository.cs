using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Data.Context;

namespace CCMS.NEOPE.Infra.Data.Repositories;

public class AssetProjectStatusRepository : Repository<AssetProjectStatus, ulong>, IAssetProjectStatusRepository
{
    public AssetProjectStatusRepository(ApplicationContext context) : base(context)
    {
    }
}