using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.Tasks;
using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Enums;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Customs;
using CCMS.NEOPE.Infra.Helpers;
using CCMS.NEOPE.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskStatus = CCMS.NEOPE.Domain.Enums.TaskStatus;

namespace CCMS.NEOPE.Application.Services;

public class TaskService : ITaskService
{
    private readonly IProjectRepository _projectRepository;
    private readonly ITaskStepRepository _taskStepRepository;
    private readonly IUserService _userService;
    private readonly ITaskRepository _taskRepository;
    private readonly ITaskTypeRepository _taskTypeRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TaskService(
        ITaskRepository taskRepository,
        ITaskTypeRepository taskTypeRepository,
        IProjectRepository projectRepository,
        ITaskStepRepository taskStepRepository,
        ICategoryRepository categoryRepository,
        IUserService userService,
        IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        _taskTypeRepository = taskTypeRepository;
        _projectRepository = projectRepository;
        _taskStepRepository = taskStepRepository;
        _categoryRepository = categoryRepository;
        _userService = userService;
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
        
        _mapper = mapper;
    }

    public void Add(AddTaskModel model)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        var task = _mapper.Map<TaskItem>(model);

        Project? project = null;
        if(model.ProjectId.HasValue)
        {
            project = _projectRepository.Get(model.ProjectId.Value);
        }
        task.Project = project;

        TaskType? taskType = null;
        if (model.TypeId.HasValue)
        {
            taskType = _taskTypeRepository.Get(model.TypeId.Value);
        }
        task.Type = taskType;

        TaskStep? taskStep = null;
        if (model.StepId.HasValue)
        {
            taskStep = _taskStepRepository.Get(model.StepId.Value);
        }
        task.Step = taskStep;
        
        TaskCategory? category = null;
        if (model.SelectedCategory.HasValue)
        {
            category = _categoryRepository.Get(model.SelectedCategory.Value);
        }
        task.Category = category;

        IUser? user = null;
        if (model.ReporterId != null)
        {
            user = _userService.Users.FirstOrDefault(x => x.Id == model.ReporterId);
        }
        task.Reporter = user;

        TaskItem? parent = null;
        if (model.ParentTaskId.HasValue)
        {
            parent = _taskRepository.Get(model.ParentTaskId.Value);
        }
        task.ParentTask = parent;

        if (model.AssigneeIds.Any())
        {
            foreach (var id in model.AssigneeIds)
            {
                var assignee = _userService.Users.FirstOrDefault(x => x.Id == id);
                if (assignee != null)
                {
                    task.Assignees.Add(assignee);
                }
            }
        }
        _taskRepository.Save(task);
        
        transaction.Commit();
    }

    public IPagedList<ViewTaskModel> List(string? searchString, int skip, int pageSize)
    {
        var data = _taskRepository.Entities
            .Include(x => x.Type)
            .Include(x => x.Project)
            .Include(x => x.Step)
            .Include(x => x.Reporter)
            .Include(x => x.Assignees)
            .Include(x => x.Category)
            .AsQueryable();
        
        var totalRecord = data.Count();
        
        if (!string.IsNullOrEmpty(searchString)) {
            data = data.Where(x => 
                (x.Title != null && x.Title.ToLower().Contains(searchString.ToLower())) ||
                (x.Description != null && x.Description.ToLower().Contains(searchString.ToLower())) ||
                (x.Type != null && x.Type.Name.ToLower().Contains(searchString.ToLower())) ||
                (x.Step != null && x.Step.Name.ToLower().Contains(searchString.ToLower())) ||
                (x.Project != null && x.Project.Name.ToLower().Contains(searchString.ToLower())) ||
                (x.Reporter != null && x.Reporter.FirstName.Contains(searchString.ToLower())) ||
                (x.Reporter != null && x.Reporter.LastName.Contains(searchString.ToLower())) ||
                (x.Category != null && x.Category.Name.Contains(searchString.ToLower())) ||  
                (x.Assignees.Any(a =>
                     a.FirstName.ToLower().Contains(searchString.ToLower()) ||
                     a.LastName.ToLower().Contains(searchString.ToLower()))));
        }
        var filterRecord = data.Count();
        
        var list = data.Skip(skip).Take(pageSize).ToList();
        
        var records = 
            _mapper.Map<ICollection<TaskItem>, ICollection<ViewTaskModel>>(list.ToList());

        return new PagedList<ViewTaskModel>(totalRecord, filterRecord, records);
    }

    public void Edit(EditTaskModel model)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        var task = _taskRepository.Entities
            .Include(x => x.Type)
            .Include(x => x.Project)
            .Include(x => x.Step)
            .Include(x => x.Reporter)
            .Include(x => x.Assignees)
            .Include(x => x.Category)
            .FirstOrDefault(x => x.Id == model.Id);

        if (task != null)
        {
            task.Assignees.Clear();
            _mapper.Map(model, task);
            
            Project? project = null;
            if(model.ProjectId.HasValue)
            {
                project = _projectRepository.Get(model.ProjectId.Value);
            }
            task.Project = project;

            TaskType? taskType = null;
            if (model.TypeId.HasValue)
            {
                taskType = _taskTypeRepository.Get(model.TypeId.Value);
            }
            task.Type = taskType;
            
            TaskCategory? category = null;
            if (model.SelectedCategory.HasValue)
            {
                category = _categoryRepository.Get(model.SelectedCategory.Value);
            }
            task.Category = category;

            TaskStep? taskStep = null;
            if (model.StepId.HasValue)
            {
                taskStep = _taskStepRepository.Get(model.StepId.Value);
            }
            task.Step = taskStep;

            IUser? user = null;
            if (model.ReporterId != null)
            {
                user = _userService.Users.FirstOrDefault(x => x.Id == model.ReporterId);
            }
            task.Reporter = user;

            TaskItem? parent = null;
            if (model.ParentTaskId.HasValue)
            {
                parent = _taskRepository.Get(model.ParentTaskId.Value);
            }
            task.ParentTask = parent;
            
            if (model.AssigneeIds.Any())
            {
                foreach (var id in model.AssigneeIds)
                {
                    var assignee = _userService.Users.FirstOrDefault(x => x.Id == id);
                    if (assignee != null)
                    {
                        task.Assignees.Add(assignee);
                    }
                }
            }
            _taskRepository.Update(task);
        }
        
        transaction.Commit();
    }

    public void Delete(ulong id)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        _taskRepository.Delete(id);
        transaction.Commit();
    }

    public EditTaskModel? Get(ulong id)
    {
        var task = _taskRepository.Entities
            .Include(x => x.Project)
            .Include(x => x.ParentTask)
            .Include(x => x.Type)
            .Include(x => x.Step)
            .Include(x => x.Reporter)
            .Include(x => x.Assignees)
            .Include(x => x.CheckListItems)
            .Include(x => x.Category)
            .FirstOrDefault(x => x.Id == id);
        
        if (task == null) return null;
        var model = _mapper.Map<EditTaskModel>(task);
        model.Tasks = GetTasksSelectList(model.ParentTaskId);
        model.Users = GetUsersSelectList(model.ReporterId);
        model.Assignees = GetAssigneesSelectList(model.AssigneeIds);
        model.Steps = GetStepsSelectList(model.StepId);
        model.Priorities = GetPrioritySelectList(model.SelectedPriority);
        model.Status = GetStatusSelectList(model.SelectedStatus);
        model.Projects = GetProjectSelectList(model.ProjectId);
        model.Types = GetTypesSelectList(model.TypeId);
        model.Categories = GetCategoriesSelectList(model.SelectedCategory);
        
        return model;
    }

    public AddTaskModel Get()
    {
        var model = new AddTaskModel();

        model.Tasks = GetTasksSelectList(model.ParentTaskId);
        model.Users = GetUsersSelectList(model.ReporterId);
        model.Assignees = GetAssigneesSelectList(model.AssigneeIds);
        model.Steps = GetStepsSelectList(model.StepId);
        model.Priorities = GetPrioritySelectList(model.SelectedPriority);
        model.Status = GetStatusSelectList(model.SelectedStatus);
        model.Projects = GetProjectSelectList(model.ProjectId);
        model.Types = GetTypesSelectList(model.TypeId);
        model.Categories = GetCategoriesSelectList(model.SelectedCategory);
        
        return model;
    }
    
    private SelectList GetProjectSelectList(ulong? id)
    {
        var projects = new List<SelectListItem>()
            { new SelectListItem() { Text = "" } };
        projects.AddRange(_projectRepository.Entities.ToList()
            .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }));
        
        return new SelectList(projects.ToList(),"Value","Text", id);
    }
    private SelectList GetTasksSelectList(ulong? id)
    {
        return new SelectList(_taskRepository.Entities
            .ToList().Select(x =>
                new SelectListItem() { Text = x.Title, Value = x.Id.ToString() }).ToList(),"Value","Text", id);
    }
    private SelectList GetTypesSelectList(ulong? typeId)
    {
        var types = new List<SelectListItem>()
            { new SelectListItem() { Text = "" } };
        types.AddRange(_taskTypeRepository.Entities.ToList()
            .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }));
        return new SelectList(types, "Value","Text", typeId);
    }
    private SelectList GetUsersSelectList(string? id)
    {
        var types = new List<SelectListItem>()
            { new SelectListItem() { Text = "" } };
        types.AddRange(_userService.Users.ToList()
            .Select(x => new SelectListItem() { Text = x.FirstName + " "+x.LastName, Value = x.Id.ToString() }));
        return new SelectList(types, "Value","Text", id);
    }
    private MultiSelectList GetAssigneesSelectList(ICollection<string>? ids)
    {
        var types = new List<SelectListItem>();
        types.AddRange(_userService.Users.ToList()
            .Select(x => new SelectListItem() { Text = x.FirstName + " "+x.LastName, Value = x.Id.ToString() }));
        return new MultiSelectList(types, "Value","Text", ids);
    }
    private SelectList GetStepsSelectList(int? stepId)
    {
        var types = new List<SelectListItem>()
            { new SelectListItem() { Text = "" } };
        types.AddRange(_taskStepRepository.Entities.ToList()
            .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }));
        return new SelectList(types, "Value","Text", stepId);
    }
    private SelectList GetCategoriesSelectList(int? categoryId)
    {
        var types = new List<SelectListItem>()
            { new SelectListItem() { Text = "" } };
        types.AddRange(_categoryRepository.Entities.ToList()
            .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }));
        return new SelectList(types, "Value","Text", categoryId);
    }
    private SelectList GetPrioritySelectList(TaskPriority? priority)
    {
        var types = new List<SelectListItem>()
            { new SelectListItem() { Text = "" } };
        types.AddRange(Enum.GetValues<TaskPriority>()
            .Select(x => new SelectListItem() { Text = EnumHelper<TaskPriority>.GetDisplayValue(x), Value = x.ToString() }));
        return new SelectList(types, "Value","Text", priority);
    }
    private SelectList GetStatusSelectList(TaskStatus? status)
    {
        var types = new List<SelectListItem>();
        types.AddRange(Enum.GetValues<TaskStatus>()
            .Select(x => new SelectListItem() { Text = EnumHelper<TaskStatus>.GetDisplayValue(x), Value = x.ToString() }));
        return new SelectList(types, "Value","Text", status);
    }
}