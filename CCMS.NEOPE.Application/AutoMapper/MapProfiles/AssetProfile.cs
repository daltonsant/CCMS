using AutoMapper;
using CCMS.NEOPE.Application.ViewModels.Assets;
using CCMS.NEOPE.Domain.Entities;

namespace CCMS.NEOPE.Application.AutoMapper.MapProfiles;

public class AssetProfile : Profile
{
    public AssetProfile()
    {
        
        CreateMap<Asset, AddAssetModel>()
            .ForMember(model => model.Projects,
                opt => opt.Ignore())
            .ForMember(model => model.Tasks,
                opt => opt.Ignore())
            .ReverseMap()
            .ForMember(asset => asset.Projects,
                opt => opt.Ignore())
            .ForMember(asset => asset.Tasks,
                opt => opt.Ignore())
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
            .ForMember(model => model.Tasks,
                opt => opt.Ignore())
            .ForMember(model => model.ProjectIds,
                opt => opt.MapFrom(source =>
                    source.Projects.Select(p => p.Id)))
            .ForMember(model => model.TaskIds, 
                opt => opt.MapFrom(source =>
                    source.Tasks.Select(t => t.Id)))
            .ForMember(model => model.TypeId,
                source => source.MapFrom(source =>
                    source.Type.Id))
            .ReverseMap()
            .ForMember(asset => asset.Projects,
                opt => opt.Ignore())
            .ForMember(asset => asset.Tasks,
                opt => opt.Ignore())
            ;

    }
}