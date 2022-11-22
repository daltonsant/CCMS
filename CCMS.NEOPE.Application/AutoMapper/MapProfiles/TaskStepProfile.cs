using AutoMapper;
using CCMS.NEOPE.Application.ViewModels.TaskStep;
using CCMS.NEOPE.Domain.Entities;

namespace CCMS.NEOPE.Application.AutoMapper.MapProfiles;

public class TaskStepProfile : Profile
{
    public TaskStepProfile()
    {
        CreateMap<Step, ViewTaskStepModel>().ReverseMap();
        CreateMap<Step, EditTaskStepModel>().ReverseMap();
        CreateMap<Step, AddTaskStepModel>().ReverseMap();
    }
}