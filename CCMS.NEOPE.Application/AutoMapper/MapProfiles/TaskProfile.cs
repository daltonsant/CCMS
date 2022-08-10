using AutoMapper;
using CCMS.NEOPE.Application.ViewModels.Tasks;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Enums;
using CCMS.NEOPE.Infra.Helpers;
using TaskStatus = CCMS.NEOPE.Domain.Enums.TaskStatus;

namespace CCMS.NEOPE.Application.AutoMapper.MapProfiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<TaskItem, TaskReadViewModel>()
            .ForMember(dest => dest.Id, 
                src => src.MapFrom(task => task.Id.ToString()))
            .ForMember(dest => dest.Key,
                opt => opt.MapFrom(src => src.Key.ToString()))
            .ForMember(dest => dest.ProjectName,
                opt => opt.MapFrom(src => src.Project!.Name))
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title ?? string.Empty))
            .ForMember(dest => dest.Priority,
                opt => opt.MapFrom(src => EnumHelper<TaskPriority>.GetDisplayValue(src.Priority)))
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => EnumHelper<TaskStatus>.GetDisplayValue(src.Status)))
            .ForMember(dest => dest.StartDate,
                opt => opt.MapFrom(src => src.StartDate.HasValue ? src.StartDate.Value.ToString("dd/MM/yyyy") : string.Empty))
            .ForMember(dest => dest.DueDate,
                opt => opt.MapFrom(src => src.DueDate.HasValue ? src.DueDate.Value.ToString("dd/MM/yyyy") : string.Empty))
            .ForMember(dest => dest.TaskType,
                opt => opt.MapFrom(src => src.Type.Name))
            ;
    }
}