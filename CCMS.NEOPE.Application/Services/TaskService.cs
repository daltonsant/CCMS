using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.LinkedTasks;
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
    private readonly ILinkedTasksRepository _linkedTasksRepository;
    private readonly IAccountableRepository _accountableRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TaskService(
        ITaskRepository taskRepository,
        ITaskTypeRepository taskTypeRepository,
        IProjectRepository projectRepository,
        ITaskStepRepository taskStepRepository,
        ICategoryRepository categoryRepository,
        ILinkedTasksRepository linkedTasksRepository,
        IUserService userService,
        IUnitOfWork unitOfWork,
        IAccountableRepository accountableRepository, 
        IMapper mapper)
    {
        _taskTypeRepository = taskTypeRepository;
        _projectRepository = projectRepository;
        _taskStepRepository = taskStepRepository;
        _categoryRepository = categoryRepository;
        _linkedTasksRepository = linkedTasksRepository;
        _userService = userService;
        _taskRepository = taskRepository;
        _accountableRepository = accountableRepository;
        _unitOfWork = unitOfWork;
        
        _mapper = mapper;
    }

    public void Add(AddTaskModel model)
    {
        var task = _mapper.Map<TaskItem>(model);

        var hasErrors = model.SelectedStatus == TaskStatus.Done && IsToBlockDoneStatus(model.LinkedTasks);
        
        if(hasErrors) model.Errors.Add("SelectedStatus", "Esta atividade pussui dependência em atividade não concluida.");

        if (!hasErrors)
        {
            using var transaction = _unitOfWork.BeginTransaction();
            Project? project = null;
            if(model.ProjectId.HasValue)
            {
                project = _projectRepository.Get(model.ProjectId.Value);
            }
            task.Project = project;

            Domain.Entities.Type? taskType = null;
            if (model.TypeId.HasValue)
            {
                taskType = _taskTypeRepository.Get(model.TypeId.Value);
            }
            task.Type = taskType;

            Step? taskStep = null;
            if (model.StepId.HasValue)
            {
                taskStep = _taskStepRepository.Get(model.StepId.Value);
            }
            task.Step = taskStep;
            
            Category? category = null;
            if (model.SelectedCategory.HasValue)
            {
                category = _categoryRepository.Get(model.SelectedCategory.Value);
            }
            task.Category = category;

            Accountable? user = null;
            if (model.ReporterId != null)
            {
                ulong reporterId = 0;
                ulong.TryParse(model.ReporterId, out reporterId);
                if(reporterId != 0)
                {
                    user = _accountableRepository.Entities.FirstOrDefault(x => x.Id == reporterId);
                }
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
                    ulong assigneeId = 0;
                    ulong.TryParse(id, out assigneeId);
                    if(assigneeId != 0)
                    {
                        var assignee = _accountableRepository.Entities.FirstOrDefault(x => x.Id == assigneeId);
                        if (assignee != null)
                        {
                            task.Assignees.Add(assignee);
                        }
                    }
                }
            }
            _taskRepository.Save(task);
            
            //Add activities that relates to the added task
            var linkedTasks = new List<LinkedTasks>();
            foreach (var linkedTaskModel in model.LinkedTasks)
            {
                TaskItem otherTask;
                LinkedTasks linked = null;
                if (linkedTaskModel.SubjectTaskId.HasValue)
                {
                    otherTask = _taskRepository.Entities.FirstOrDefault(e => e.Id == linkedTaskModel.SubjectTaskId);
                    
                    if (otherTask != null)
                    {
                        linked = new LinkedTasks()
                        {
                            SubjectTask = otherTask,
                            ObjectTask = task,
                            Type = linkedTaskModel.Type,
                            CreateDate = DateTime.Now
                        };
                    }
                }
                else
                {
                    otherTask = _taskRepository.Entities.FirstOrDefault(e => e.Id == linkedTaskModel.ObjectTaskId);
                    
                    if (otherTask != null)
                    {
                        linked = new LinkedTasks()
                        {
                            SubjectTask = task,
                            ObjectTask = otherTask,
                            Type = linkedTaskModel.Type,
                            CreateDate = DateTime.Now
                        };
                    }
                }
                if(linked!=null)
                    linkedTasks.Add(linked);
            }
            foreach(var linked in linkedTasks) _linkedTasksRepository.Save(linked);
            
            transaction.Commit();
        }
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
                (x.Reporter != null && x.Reporter.DisplayName.Contains(searchString.ToLower())) ||
                (x.Category != null && x.Category.Name.Contains(searchString.ToLower())) ||  
                (x.Assignees.Any(a =>
                     a.DisplayName.ToLower().Contains(searchString.ToLower()))));
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
            .Include(x => x.LinkedObjectTasks)
            .Include(x => x.LinkedSubjectTasks)
            .FirstOrDefault(x => x.Id == model.Id);

        if (task != null)
        {
            bool hasValidationErros = model.SelectedStatus == TaskStatus.Done &&
                                      HasBlockingLink(task, model.LinkedTasks);
            
            if(hasValidationErros) model.Errors.Add("SelectedStatus", "Esta atividade pussui dependência em atividade não concluida.");

            if (!hasValidationErros)
            {
                task.Assignees.Clear();
                _mapper.Map(model, task);
                
                Project? project = null;
                if(model.ProjectId.HasValue)
                {
                    project = _projectRepository.Get(model.ProjectId.Value);
                }
                task.Project = project;

                Domain.Entities.Type? taskType = null;
                if (model.TypeId.HasValue)
                {
                    taskType = _taskTypeRepository.Get(model.TypeId.Value);
                }
                task.Type = taskType;
                
                Category? category = null;
                if (model.SelectedCategory.HasValue)
                {
                    category = _categoryRepository.Get(model.SelectedCategory.Value);
                }
                task.Category = category;

                Step? taskStep = null;
                if (model.StepId.HasValue)
                {
                    taskStep = _taskStepRepository.Get(model.StepId.Value);
                }
                task.Step = taskStep;

                 Accountable? user = null;
                if (model.ReporterId != null)
                {
                    ulong reporterId = 0;
                    ulong.TryParse(model.ReporterId, out reporterId);
                    if(reporterId != 0)
                    {
                        user = _accountableRepository.Entities.FirstOrDefault(x => x.Id == reporterId);
                    }
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
                        ulong assigneeId = 0;
                        ulong.TryParse(id, out assigneeId);
                        if(assigneeId != 0)
                        {
                            var assignee = _accountableRepository.Entities.FirstOrDefault(x => x.Id == assigneeId);
                            if (assignee != null)
                            {
                                task.Assignees.Add(assignee);
                            }
                        }
                    }
                }
                
                //here we update the linkedtasks
                //get all existing links
                var modelLinkIds = model.LinkedTasks.Where(x => x.Id != null).Select(x => x.Id);
                var linkedTasks = task.LinkedObjectTasks.Where(x => modelLinkIds.Contains(x.Id)).ToList();
                linkedTasks.AddRange(task.LinkedSubjectTasks.Where(x => modelLinkIds.Contains(x.Id)));
                task.LinkedObjectTasks.Clear();
                task.LinkedSubjectTasks.Clear();

                foreach (var link in model.LinkedTasks)
                {
                    if (link.Id.HasValue)
                    {
                        var oldLink = linkedTasks.FirstOrDefault(x => x.Id == link.Id.Value);
                        if (oldLink != null && link.ObjectTaskId.HasValue && link.SubjectTaskId.HasValue)
                        {
                            oldLink.Type = link.Type;
                            oldLink.ObjectTaskId = link.ObjectTaskId.Value;
                            oldLink.SubjectTaskId = link.SubjectTaskId.Value;
                            oldLink.ObjectTask = null;
                            oldLink.SubjectTask = null;
                            oldLink.UpdateDate = DateTime.Now;
                        }
                        
                        if (link.SubjectTaskId == task.Id)
                        {
                            task.LinkedSubjectTasks.Add(oldLink);
                            oldLink.SubjectTask = task;
                        }
                        else if (link.ObjectTaskId == task.Id)
                        {
                            task.LinkedObjectTasks.Add(oldLink);
                            oldLink.ObjectTask = task;
                        }
                        
                        _linkedTasksRepository.Update(oldLink);
                        
                    }
                    else if(link.ObjectTaskId.HasValue && link.SubjectTaskId.HasValue) // vai ser adicao com certeza
                    {
                        var linkToAdd = new LinkedTasks()
                        {
                            CreateDate = DateTime.Now,
                            Type = link.Type,
                            ObjectTaskId = link.ObjectTaskId.Value,
                            SubjectTaskId = link.SubjectTaskId.Value,
                        };
                        
                        if (link.SubjectTaskId == task.Id)
                        {
                            task.LinkedSubjectTasks.Add(linkToAdd);
                            linkToAdd.SubjectTask = task;
                        }
                        else if (link.ObjectTaskId == task.Id)
                        {
                            task.LinkedObjectTasks.Add(linkToAdd);
                            linkToAdd.ObjectTask = task;
                        }
                    }
                }
                
                _taskRepository.Update(task);
            }
        }
        
        transaction.Commit();
    }

    private bool HasBlockingLink(TaskItem task, List<ViewLinkedTaskModel> links)
    {
        var hasError = false;

        foreach (var link in links.Where(x => x.Type == LinkType.Blocks))
        {
            var subjectTask =  _taskRepository.Entities
                .FirstOrDefault(x => x.Id == link.SubjectTaskId);
            var objectTask = _taskRepository.Entities
                .FirstOrDefault(x => x.Id == link.ObjectTaskId);

            if (subjectTask != null && objectTask != null &&
                objectTask.Id == task.Id && subjectTask.Status != TaskStatus.Done)
            {
                hasError = true;
                break;
            }
        }
        
        return hasError;
    }

    private bool IsToBlockDoneStatus(List<ViewLinkedTaskModel> links)
    {
        var hasError = false;
        foreach (var link in links.Where(x => x.Type == LinkType.Blocks))
        {
            var subjectTask =  _taskRepository.Entities
                .FirstOrDefault(x => x.Id == link.SubjectTaskId);
            if (subjectTask != null && subjectTask.Status != TaskStatus.Done)
            {
                hasError = true;
                break;
            }
        }

        return hasError;
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
            .Include(x => x.LinkedObjectTasks).ThenInclude(x => x.SubjectTask).ThenInclude(x => x.Project)
            .Include(x => x.LinkedSubjectTasks).ThenInclude(x => x.ObjectTask).ThenInclude(x => x.Project)
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

        foreach (var obj in task.LinkedObjectTasks)
        {
            model.LinkedTasks.Add(new ViewLinkedTaskModel()
            {
                Id = obj.Id,
                Type = obj.Type,
                ObjectTaskId = obj.ObjectTaskId,
                SubjectTaskId = obj.SubjectTaskId,
                TaskText = obj.SubjectTask.Project.Name + " - " + obj.SubjectTask.Title,
                TypeText = TypeText(obj.Type, false)
            });
        }
        foreach (var sub in task.LinkedSubjectTasks)
        {
            model.LinkedTasks.Add(new ViewLinkedTaskModel()
            {
                Id = sub.Id,
                Type = sub.Type,
                ObjectTaskId = sub.ObjectTaskId,
                SubjectTaskId = sub.SubjectTaskId,
                TaskText = sub.ObjectTask.Project.Name + " - " + sub.ObjectTask.Title,
                TypeText = TypeText(sub.Type, true)
            });
        }
        
        return model;
    }

    private string TypeText(LinkType type, bool isSubject)
    {
        string typeText = string.Empty;

        switch (type)
        {
           case LinkType.Blocks:
               typeText = "Bloqueia";
               if (!isSubject)
                   typeText = "Bloqueada por";
               break;
           case LinkType.Causes:
               typeText = "Causa";
               if (!isSubject)
                   typeText = "Causada por";
               break;
           case LinkType.Duplicates:
               typeText = "Duplica";
               break;
           case LinkType.RelatesTo:
               typeText = "Relacionada a";
               break;
        }

        return typeText;
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

    public object GetTasks(string search, int page, ulong? exceptId)
    {
        var entities = _taskRepository.Entities.Include(x => x.Project)
            .Where(x => (exceptId == null || exceptId.Value != x.Id) &&(x.Title.ToLower().Contains(search.ToLower()) ||
                        x.Project.Name.ToLower().Contains(search.ToLower())))
            .OrderBy(x => x.Id);
        
        var skip = (page-1) > 0 ? (page-1)*10 : 0;
        
        var tasks = entities.Skip(skip).Take(10).ToList();

        return new
        {
            total_count = tasks.Count,
            items = tasks.Select(x => new
            {
                id = x.Id,
                text = x.Project.Name + " - " + x.Title
            }).ToArray()
        };
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