using CCMS.NEOPE.Application.ViewModels.Assets;
using CCMS.NEOPE.Application.ViewModels.AssetTypes;
using CCMS.NEOPE.Domain.Core.Interfaces;

namespace CCMS.NEOPE.Application.Interfaces;

public interface IAssetService
{
    void Add(AddAssetModel model);
    IPagedList<ViewAssetModel> List(string? searchString, int skip, int pageSize);
    void Edit(EditAssetModel model);
    void Delete(ulong Id);
    EditAssetModel? Get(ulong id);
    AddAssetModel GetAddAssetModel();
    ActivityModel GetActivity(ulong assetId);
    Dictionary<string, string> SaveActivity(ActivityModel model);

    Dictionary<string, string> MoveActivity(ulong sourceStepId, ulong targetStepId, ulong assetId);
    Dictionary<string, ICollection<Dictionary<string, string>>> GetActivities();
}