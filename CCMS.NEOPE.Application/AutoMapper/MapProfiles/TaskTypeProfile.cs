using AutoMapper;
using CCMS.NEOPE.Application.ViewModels.TaskType;
using CCMS.NEOPE.Domain.Entities;

namespace CCMS.NEOPE.Application.AutoMapper.MapProfiles;

public class TaskTypeProfile : Profile
{
    public TaskTypeProfile()
    {
        CreateMap<Domain.Entities.PendencyType, AddTaskTypeModel>().ReverseMap();
        CreateMap<Domain.Entities.PendencyType, EditTaskTypeModel>().ReverseMap();
        CreateMap<Domain.Entities.PendencyType, ViewTaskTypeModel>().ReverseMap();
        
    }
}