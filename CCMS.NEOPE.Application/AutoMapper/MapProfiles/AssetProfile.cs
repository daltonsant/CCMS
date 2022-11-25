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
        CreateMap<AssetProjectStatus, ActivityModel>()
            .ForMember(x => x.AssetId, opt => opt.MapFrom(y => y.Asset.Id))
            .ForMember(x => x.SelectedCategory, opt => opt.MapFrom(y => y.Category.Id))
            .ForMember(x => x.StepId, opt => opt.MapFrom(src => src.Step.Id))
            .ForMember(dest => dest.SelectedStatus, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Asset.Project.Name))
            .ForMember(dest => dest.AssigneeIds, opt => opt.MapFrom(src => src.Assignees.Select(x => x.Id)))
            .ForMember(dest => dest.Assignees, opt => opt.Ignore())
            .ForMember(dest => dest.Categories, opt => opt.Ignore())
            .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.Status, opt => opt.Ignore())
            .ForMember(dest => dest.Steps, opt => opt.Ignore())
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Asset.Code))
            ;

    }
}