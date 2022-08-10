using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.Tasks;
using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Helpers;
using TaskStatus = CCMS.NEOPE.Domain.Enums.TaskStatus;

namespace CCMS.NEOPE.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TaskService(
        ITaskRepository taskRepository, 
        IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public ICollection<TaskReadViewModel> GetTasks(string? searchString, int skip, int pageSize)
    {
        var data = _taskRepository.Entities;
        
        var totalRecord = data.Count();
        
        if (!string.IsNullOrEmpty(searchString)) {
            data = data.Where(x => 
                x.Title != null && x.Project != null && 
                    (x.Title.ToLower().Contains(searchString.ToLower()) || 
                    x.Project.Name.ToLower().Contains(searchString.ToLower()) || 
                    x.Type.Name.ToString().ToLower().Contains(searchString.ToLower())));
        }
        var filterRecord = data.Count();
        
        //var models = _mapper
            //.Map<ICollection<TaskItem>, ICollection<TaskReadViewModel>>(data.ToList());
        
        return new List<TaskReadViewModel>()
        {
            new TaskReadViewModel()
            {
                Id = "1",
                Key = "0001",
                Priority = "Altissima",
                ProjectName = "Meu",
                Status = "Concluida",
                TaskType = "ADMdddddddddddddddddddddd",
                Title = "oi oi oi "
            },
            new TaskReadViewModel()
            {
                Id = "2",
                Key = "0002",
                Priority = "Altissima",
                ProjectName = "Meu",
                Status = "Concluida",
                TaskType = "ADM",
                Title = "oi oi oidddddddddddddddddddddddddddddddddddddddddddddddddddd "
            },new TaskReadViewModel()
            {
                Id = "3",
                Key = "0003",
                Priority = "Altissima",
                ProjectName = "Meu",
                Status = "Concluida",
                TaskType = "ADM",
                Title = "oi oi oi "
            },new TaskReadViewModel()
            {
                Id = "4",
                Key = "0004",
                Priority = "Altissima",
                ProjectName = "Meu",
                Status = "Concluida",
                TaskType = "ADM",
                Title = "oi oi oi "
            },new TaskReadViewModel()
            {
                Id = "5",
                Key = "0005",
                Priority = "Altissima",
                ProjectName = "Meu",
                Status = "Concluida",
                TaskType = "ADM",
                Title = "oi oi oi "
            },new TaskReadViewModel()
            {
                Id = "6",
                Key = "0006",
                Priority = "Altissima",
                ProjectName = "Meu",
                Status = "Concluida",
                TaskType = "ADM",
                Title = "oi oi oi "
            },new TaskReadViewModel()
            {
                Id = "7",
                Key = "0007",
                Priority = "Altissima",
                ProjectName = "Meu",
                Status = "Concluida",
                TaskType = "ADM",
                Title = "oi oi oi "
            },new TaskReadViewModel()
            {
                Id = "8",
                Key = "0008",
                Priority = "Altissima",
                ProjectName = "Meu",
                Status = "Concluida",
                TaskType = "ADM",
                Title = "oi oi oi "
            },new TaskReadViewModel()
            {
                Id = "9",
                Key = "0009",
                Priority = "Altissima",
                ProjectName = "Meu",
                Status = "Concluida",
                TaskType = "ADM",
                Title = "oi oi oi "
            },new TaskReadViewModel()
            {
                Id = "10",
                Key = "0010",
                Priority = "Altissima",
                ProjectName = "Meu asdawdess",
                Status = "Concluida",
                TaskType = "ADM",
                Title = "oi oi oi "
            },new TaskReadViewModel()
            {
                Id = "11",
                Key = "0011",
                Priority = "Altissima",
                ProjectName = "Meu",
                Status = "Concluida",
                TaskType = "ADM",
                Title = "oi oi oi "
            },new TaskReadViewModel()
            {
                Id = "12",
                Key = "0012",
                Priority = "Altissima",
                ProjectName = "Meu projeto favorito",
                Status = "Concluida",
                TaskType = "ADM",
                Title = "oi oi oi "
            }
        };
    }
}