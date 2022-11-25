using AutoMapper;
using CCMS.NEOPE.Application.ViewModels.Calendar;
using CCMS.NEOPE.Application.ViewModels.LinkedTasks;
using CCMS.NEOPE.Application.ViewModels.Tasks;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Enums;
using CCMS.NEOPE.Infra.Helpers;
using CCMS.NEOPE.Infra.Identity;
using Microsoft.EntityFrameworkCore;
using Status = CCMS.NEOPE.Domain.Enums.Status;

namespace CCMS.NEOPE.Application.AutoMapper.MapProfiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<TaskItem, ViewTaskModel>()
            .ForMember(dest => dest.Id, 
                src => 
                    src.MapFrom(task => task.Id))
            .ForMember(dest => dest.ProjectName,
                opt => 
                    opt.MapFrom(src => src.Project!.Name))
            .ForMember(dest => dest.Title,
                opt => 
                    opt.MapFrom(src => src.Title ?? string.Empty))
            .ForMember(dest => dest.Priority,
                opt => 
                    opt.MapFrom(src => src.Priority.HasValue ? EnumHelper<TaskPriority>.GetDisplayValue(src.Priority.Value) : string.Empty))
            .ForMember(dest => dest.Status,
                opt => 
                    opt.MapFrom(src => EnumHelper<Status>.GetDisplayValue(src.Status)))
            .ForMember(dest => dest.StartDate,
                opt => 
                    opt.MapFrom(src => src.StartDate.HasValue ? 
                        src.StartDate.Value.ToString("dd/MM/yyyy") : string.Empty))
            .ForMember(dest => dest.DueDate,
                opt => 
                    opt.MapFrom(src => 
                        src.DueDate.HasValue ? src.DueDate.Value.ToString("dd/MM/yyyy") : string.Empty))
            .ForMember(dest => dest.TaskType,
                opt => 
                    opt.MapFrom(src => src.Type.Name))
            .ForMember(dest => dest.Category, 
                opt => 
                    opt.MapFrom( src => src.Category.Name ?? string.Empty))
            .ForMember(dest => dest.SapNoteNumber, 
                opt => 
                    opt.MapFrom(src => src.SapNoteNumber ?? string.Empty))
            ;

        CreateMap<TaskItem, AddTaskModel>()
            .ForMember(model => model.TypeId,
                opt => opt.MapFrom(source =>
                    source.Type.Id))
            .ForMember(model => model.ProjectId, 
                opt => 
                    opt.MapFrom(source => source.Project!.Id))
            .ForMember(model => model.StepId, 
                opt => 
                    opt.MapFrom(source => source.Step!.Id))
            .ForMember(model => model.SelectedStatus, 
                opt => 
                    opt.MapFrom(source => source.Status))
            .ForMember(model => model.Status, 
                opt => opt.Ignore())
            .ForMember(model => model.SelectedPriority, 
                opt => 
                    opt.MapFrom(source => source.Priority))
            .ForMember(model => model.Priorities, 
                opt => opt.Ignore())
            .ForMember(model => model.ReporterId, 
                opt => 
                    opt.MapFrom(source => source.Reporter != null ? source.Reporter.Id.ToString() : null))
            .ForMember(model => model.AssigneeIds, 
                opt => 
                    opt.MapFrom(source => 
                        source.Assignees.Select(x => x.Id.ToString()).ToList()))

            .ForMember(model => model.Assignees, 
                opt => opt.Ignore())
            .ForMember(model => model.ParentTaskId, 
                opt => 
                    opt.MapFrom(source => source.ParentTask!.Id))
            .ForMember(dest => dest.SelectedCategory, 
                opt => 
                    opt.MapFrom(src => src.Category.Id))
            .ForMember(dest => dest.Categories, 
                opt => opt.Ignore())
            .ReverseMap()
            .ForMember(item => item.Id, opt => opt.Ignore())
            .ForMember(item => item.ParentTask, opt => opt.Ignore())
            .ForMember(item => item.Reporter, opt => opt.Ignore())
            .ForMember(item => item.Step, opt => opt.Ignore())
            .ForMember(item => item.Project, opt => opt.Ignore())
            .ForMember(item => item.Type, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            
            ;
        
        CreateMap<TaskItem, EditTaskModel>()
            .ForMember(model => model.TypeId,
                opt => opt.MapFrom(source =>
                    source.Type.Id))
            .ForMember(model => model.ProjectId, 
                opt => 
                    opt.MapFrom(source => source.Project!.Id))
            .ForMember(model => model.StepId, 
                opt => 
                    opt.MapFrom(source => source.Step!.Id))
            .ForMember(model => model.SelectedStatus, 
                opt => 
                    opt.MapFrom(source => source.Status))
            .ForMember(model => model.Status, 
                opt => opt.Ignore())
            .ForMember(model => model.SelectedPriority, 
                opt => 
                    opt.MapFrom(source => source.Priority))
            .ForMember(model => model.Priorities, 
                opt => opt.Ignore())
            .ForMember(model => model.ReporterId, 
                opt => 
                    opt.MapFrom(source => source.Reporter!= null ? source.Reporter.Id.ToString() : null))
            .ForMember(model => model.AssigneeIds, 
                opt => 
                    opt.MapFrom(source => 
                        source.Assignees.Select(x => x.Id.ToString())))
            .ForMember(model => model.Assignees, 
                opt => opt.Ignore())
            .ForMember(model => model.ParentTaskId, 
                opt => 
                    opt.MapFrom(source => source.ParentTask!.Id))
            .ForMember(dest => dest.SelectedCategory, 
                opt => 
                    opt.MapFrom(src => src.Category.Id))
            .ForMember(dest => dest.Categories, 
                opt => opt.Ignore())
            .ReverseMap()
            .ForMember(x => x.Id, opt => opt.MapFrom(src =>
                src.Id))
            .ForMember(item => item.ParentTask, opt => opt.Ignore())
            .ForMember(item => item.Reporter, opt => opt.Ignore())
            .ForMember(item => item.Step, opt => opt.Ignore())
            .ForMember(item => item.Project, opt => opt.Ignore())
            .ForMember(item => item.Type, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            ;
        
        CreateMap<TaskItem, ViewCalendarModel>()
            .ForMember(ev => ev.id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(ev => ev.title, opt => opt.MapFrom(src => src.Title))
            ;
        
    }
}
