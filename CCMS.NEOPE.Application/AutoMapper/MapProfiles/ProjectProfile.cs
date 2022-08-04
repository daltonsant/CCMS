using AutoMapper;
using CCMS.NEOPE.Application.ViewModels.Project;
using CCMS.NEOPE.Domain.Entities;

namespace CCMS.NEOPE.Application.AutoMapper.MapProfiles;

public class  ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, CreateProjectViewModel>().ReverseMap();
    }
}