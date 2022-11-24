using AutoMapper;
using CCMS.NEOPE.Application.ViewModels.Assets;
using CCMS.NEOPE.Domain.Entities;

namespace CCMS.NEOPE.Application.AutoMapper.MapProfiles;

public class AssetProfile : Profile
{
    public AssetProfile()
    {
        
        CreateMap<Asset, AddAssetModel>()
            .ForMember(model => model.SelectedProject,
                opt => opt.MapFrom(src => src.Project.Id))
            .ReverseMap()
            ;
        
        CreateMap<Asset,ViewAssetModel>()
            .ForMember(model => model.TypeName,
                opt => 
                    opt.MapFrom(source => source.Type.Name))
            .ReverseMap()
            ;

        CreateMap<Asset, EditAssetModel>()
            .ForMember(model => model.Projects,
                opt => opt.Ignore())
            .ForMember(model => model.SelectedProject,
                opt => opt.MapFrom(source =>
                    source.Project.Id))
            .ForMember(model => model.TypeId,
                source => source.MapFrom(source =>
                    source.Type.Id))
            .ReverseMap()
            .ForMember(asset => asset.Type,
                opt => opt.Ignore())
            ;

    }
}