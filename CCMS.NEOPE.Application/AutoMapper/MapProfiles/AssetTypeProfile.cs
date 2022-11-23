using AutoMapper;
using CCMS.NEOPE.Application.ViewModels.AssetTypes;
using CCMS.NEOPE.Domain.Entities;

namespace CCMS.NEOPE.Application.AutoMapper.MapProfiles;

public class AssetTypeProfile : Profile
{
    public AssetTypeProfile()
    {
        CreateMap<AssetType, ViewAssetTypeModel>().ReverseMap();
        CreateMap<AssetType, EditAssetTypeModel>()
            .ForMember(x => x.SelectedSteps, opt => opt.MapFrom(x => x.AllowedSteps.Select(x => x.Id)))
            .ReverseMap();
        CreateMap<AssetType, AddAssetTypeModel>()
            .ForMember(x => x.SelectedSteps, opt => opt.MapFrom(x => x.AllowedSteps.Select(x => x.Id)))
            .ReverseMap();
    }
}