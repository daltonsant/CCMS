using AutoMapper;
using CCMS.NEOPE.Application.ViewModels.TaskStep;
using CCMS.NEOPE.Domain.Entities;

namespace CCMS.NEOPE.Application.AutoMapper.MapProfiles;

public class TaskStepProfile : Profile
{
    public TaskStepProfile()
    {
        CreateMap<TaskStep, ViewTaskStepModel>().ReverseMap();
        CreateMap<TaskStep, EditTaskStepModel>().ReverseMap();
        CreateMap<TaskStep, AddTaskStepModel>().ReverseMap();
    }
}