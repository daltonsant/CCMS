using AutoMapper;
using CCMS.NEOPE.Application.ViewModels.Project;
using CCMS.NEOPE.Domain.Entities;

namespace CCMS.NEOPE.Application.AutoMapper.MapProfiles;

public class  ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<AddProjectModel, Project>().ReverseMap();
        CreateMap<Project, ViewProjectModel>().ReverseMap();
        CreateMap<Project, EditProjectModel>().ReverseMap();
    }
}