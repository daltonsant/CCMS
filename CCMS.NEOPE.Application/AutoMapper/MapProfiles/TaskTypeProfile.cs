using AutoMapper;
using CCMS.NEOPE.Application.ViewModels.TaskType;
using CCMS.NEOPE.Domain.Entities;

namespace CCMS.NEOPE.Application.AutoMapper.MapProfiles;

public class TaskTypeProfile : Profile
{
    public TaskTypeProfile()
    {
        CreateMap<TaskType, AddTaskTypeModel>().ReverseMap();
        CreateMap<TaskType, EditTaskTypeModel>().ReverseMap();
        CreateMap<TaskType, ViewTaskTypeModel>().ReverseMap();
        
    }
}