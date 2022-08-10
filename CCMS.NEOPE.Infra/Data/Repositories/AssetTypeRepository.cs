using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Data.Context;

namespace CCMS.NEOPE.Infra.Data.Repositories;

public class AssetTypeRepository : Repository<AssetType, ulong>, IAssetTypeRepository
{
    public AssetTypeRepository(ApplicationContext context) : base(context)
    {
    }
}