using AutoMapper;
using CCMS.NEOPE.Application.ViewModels.AssetTypes;
using CCMS.NEOPE.Domain.Entities;

namespace CCMS.NEOPE.Application.AutoMapper.MapProfiles;

public class AssetTypeProfile : Profile
{
    public AssetTypeProfile()
    {
        CreateMap<AssetType, ViewAssetTypeModel>().ReverseMap();
        CreateMap<AssetType, EditAssetTypeModel>().ReverseMap();
        CreateMap<AssetType, AddAssetTypeModel>().ReverseMap();
    }
}