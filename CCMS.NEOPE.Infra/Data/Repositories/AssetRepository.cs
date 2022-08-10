using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Data.Context;

namespace CCMS.NEOPE.Infra.Data.Repositories;

public class AssetRepository : Repository<Asset,ulong>, IAssetRepository
{
    public AssetRepository(ApplicationContext context) : base(context)
    {
    }
}