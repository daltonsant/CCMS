using CCMS.NEOPE.Application.ViewModels.AssetTypes;
using CCMS.NEOPE.Application.ViewModels.Project;
using CCMS.NEOPE.Domain.Core.Interfaces;

namespace CCMS.NEOPE.Application.Interfaces;

public interface IAssetTypeService
{
    void Add(AddAssetTypeModel model);
    IPagedList<ViewAssetTypeModel> List(string? searchString, int skip, int pageSize);
    void Edit(EditAssetTypeModel model);
    void Delete(ulong Id);
    EditAssetTypeModel? Get(ulong id);
}