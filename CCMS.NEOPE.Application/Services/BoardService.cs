using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCMS.NEOPE.Domain.Enums;
using CCMS.NEOPE.Infra.Helpers;
using TaskStatus = CCMS.NEOPE.Domain.Enums.TaskStatus;

namespace CCMS.NEOPE.Application.Services;

public class BoardService : IBoardService
{
    private readonly ITaskRepository _taskRepository;
    private readonly ITaskStepRepository _stepRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITaskTypeRepository _taskTypeRepository;

    public BoardService(
        ITaskRepository taskRepository,
        ITaskStepRepository stepRepository,
        ICategoryRepository categoryRepository,
        ITaskTypeRepository taskTypeRepository)
    {
        _taskRepository = taskRepository;
        _stepRepository = stepRepository;
        _categoryRepository = categoryRepository;
        _taskTypeRepository = taskTypeRepository;
    }

    public decimal GetAdherence(ulong? projectId)
    {
        var entities = _taskRepository.Entities
            .Include(x => x.Project)
            .Include(x => x.Type)
            .AsQueryable();

        if (projectId.HasValue)
            entities = entities.Where(x => x.Project.Id == projectId.Value);
        
        return GetAdherence(entities);
    }

    private decimal GetAdherence(IQueryable<TaskItem> entities)
    {
        var totalTasks = entities.Count(x => x.Status != TaskStatus.Done);
        var scheduledTasks = entities.Count(x => x.Status != TaskStatus.Done &&
                                                 (!x.DueDate.HasValue || x.DueDate.Value < DateTime.Now));
        return totalTasks != decimal.Zero ? 1.0M-((decimal)scheduledTasks / totalTasks) : decimal.One;
    }

    public decimal GetConformity(ulong? projectId)
    {
        var entities = _taskRepository.Entities
            .Include(x => x.Project)
            .Include(x => x.Type)
            .AsQueryable();

        if (projectId.HasValue)
            entities = entities.Where(x => x.Project.Id == projectId.Value);

        return GetConformity(entities);
    }

    public decimal GetQo(ulong? projectId = null)
    {
        var entities = _taskRepository.Entities
            .Include(x => x.Project)
            .Include(x => x.Type)
            .Include(x => x.Category)
            .AsQueryable();

        if (projectId.HasValue)
            entities = entities.Where(x => x.Project.Id == projectId.Value);

        var notesPerCategory = new Dictionary<string, decimal>();
        var weightPerCategory = new Dictionary<string, decimal>();
        weightPerCategory.Add("Civil",10.0M);
        weightPerCategory.Add("Eletromecânico",10.0M);
        weightPerCategory.Add("Aterramento",10.0M);
        weightPerCategory.Add("Projeto",10.0M);
        weightPerCategory.Add("Painéis",10.0M);
        weightPerCategory.Add("Equipamentos",10.0M);
        weightPerCategory.Add("Interligações",10.0M);
        weightPerCategory.Add("SPCS",10.0M);
        
        



        
        var totalClosedNotes =
            entities.Where(x => x.Status == TaskStatus.Done &&
                                !string.IsNullOrEmpty(x.SapNoteNumber))
                .Count();
        
        
        
        
        
        
        
        
        var totalR1AndR2Notes =  entities.Where(x => x.Status != TaskStatus.Done && !string.IsNullOrEmpty(x.SapNoteNumber) && 
                                                     (x.Priority == Priority.Critical || x.Priority == Priority.Urgent)).Count();
        
        var denom = totalClosedNotes + totalR1AndR2Notes;
        
        return denom != decimal.Zero ? (decimal) totalClosedNotes / denom : decimal.Zero;
    }

    public decimal GetApos(ulong? projectId = null)
    {
        var entities = _taskRepository.Entities
            .Include(x => x.Project)
            .Include(x => x.Type)
            .AsQueryable();

        if (projectId.HasValue)
            entities = entities.Where(x => x.Project.Id == projectId.Value);
        
        var totalClosedNotes =
            entities.Where(x => x.Status == TaskStatus.Done && !string.IsNullOrEmpty(x.SapNoteNumber)).Count();
        var totalR1AndR2Notes =  entities.Where(x => x.Status != TaskStatus.Done && !string.IsNullOrEmpty(x.SapNoteNumber) && 
                                                     (x.Priority == Priority.Critical || x.Priority == Priority.Urgent)).Count();
        
        var denom = totalClosedNotes + totalR1AndR2Notes;

        return denom != decimal.Zero ? (decimal) totalClosedNotes / denom : decimal.Zero;
    }
    
    private decimal GetConformity(IQueryable<TaskItem> entities)
    {
        var totalTasks = entities.Count();
        var commonTasks = entities.Where(x => !x.Type.Name.ToLower().Contains("pendência")).Count();
        return totalTasks != decimal.Zero ? (decimal)commonTasks / totalTasks : decimal.Zero;
    }

    public decimal GetProgress(ulong? projectId = null)
    {
        var entities = _taskRepository.Entities
            .Include(x => x.Project)
            .AsQueryable();

        if (projectId.HasValue)
            entities = entities.Where(x => x.Project.Id == projectId.Value);
        
        return GetProgress(entities);
    }
    
    private decimal GetProgress(IQueryable<TaskItem> entities)
    {
        var totalTasks = entities.Count();
        var doneTasks = entities.Where(x => x.Status == Domain.Enums.TaskStatus.Done).Count();
        return totalTasks != decimal.Zero ? (decimal)doneTasks / totalTasks : decimal.Zero;
    }
    
    public object[] GetPendenciesPerStepsChart(ulong? projectId=null)
    {
        var typeIds = _taskTypeRepository.Entities
            .Where(x => x.Name == "Pendência não impeditiva" ||
                        x.Name == "Pendência impeditiva" || x.Name == "Não conformidade")
            .Select(x => x.Id);

        var pendenciesPerSteps = _taskRepository.Entities
            .Include(x => x.Project)
            .Include(x => x.Step)
            .Where(x => typeIds.Contains(x.Type.Id))
            .AsQueryable();

        var steps = _stepRepository.Entities.ToList()
            .GroupBy(x => x.Name)
            .ToDictionary(k => k.Key, v => false);

        if (projectId.HasValue)
            pendenciesPerSteps = pendenciesPerSteps
                .Where(x => x.Project.Id == projectId.Value);
        
        var result = new List<object[]>
        {
            new object[] //header
            {
                "Step", "Não iniciada", "Em andamento", "Em revisão", "Concluída"
            }
        };

        var grouped = pendenciesPerSteps
            .GroupBy(x => x.Step.Id)
            .Select(x => new
        {
            Name = x.FirstOrDefault()!.Step.Name,
            NotStarted = x.Count(e => e.Status == TaskStatus.NotStarted),
            InProgress = x.Count(e => e.Status == TaskStatus.InProgress),
            InReview = x.Count(e => e.Status == TaskStatus.InReview),
            Done = x.Count(e => e.Status == TaskStatus.Done),
            Priority = x.Count(e => e.Status != TaskStatus.Done)
        }).OrderByDescending(x => x.Priority).ToList();

        var resultValues = new List<object[]>();
        
        foreach (var entry in grouped)
        {
            steps[entry.Name] = true;
            resultValues = resultValues.Append(
                new object[]
                {
                    entry.Name, 
                    entry.NotStarted != 0 ? entry.NotStarted : "", 
                    entry.InProgress != 0 ? entry.InProgress : "", 
                    entry.InReview != 0 ? entry.InReview : "", 
                    entry.Done != 0 ? entry.Done : ""
                }).ToList();
        }

        foreach (var key in steps.Where(v => v.Value == false))
        {
            resultValues = resultValues.Append(
                new object[]
                {
                    key.Key,
                    "",
                    "",
                    "",
                    ""
                }).ToList();
        }

        resultValues.Reverse();
        result.AddRange(resultValues);
        
        return result.ToArray();
    }

    public object[] GetPendenciesPerCategoryChart(ulong? projectId=null)
    {
        var typeIds = _taskTypeRepository.Entities
            .Where(x => x.Name == "Pendência não impeditiva" ||
                        x.Name == "Pendência impeditiva" || x.Name == "Não conformidade")
            .Select(x => x.Id);

        var pendenciesPerCategory = _taskRepository.Entities
            .Include(x => x.Project)
            .Include(x => x.Category)
            .Where(x => typeIds.Contains(x.Type.Id))
            .AsQueryable();

        var categories = _categoryRepository.Entities.ToList()
            .GroupBy(x => x.Name)
            .ToDictionary(k => k.Key, v => false);
        
        if (projectId.HasValue)
            pendenciesPerCategory = pendenciesPerCategory
                .Where(x => x.Project.Id == projectId.Value);
        
        var result = new List<object[]>
        {
            new object[] //header
            {
                "Category", "Não iniciada", "Em andamento", "Em revisão", "Concluída"
            }
        };
        
        var grouped = pendenciesPerCategory
            .GroupBy(x => x.Category.Id)
            .Select(x => new
            {
                Name = x.FirstOrDefault()!.Category.Name,
                NotStarted = x.Count(e => e.Status == TaskStatus.NotStarted),
                InProgress = x.Count(e => e.Status == TaskStatus.InProgress),
                InReview = x.Count(e => e.Status == TaskStatus.InReview),
                Done = x.Count(e => e.Status == TaskStatus.Done),
                Priority = x.Count(e => e.Status != TaskStatus.Done)
            }).OrderByDescending(x => x.Priority).ToList();
        
        var resultValues = new List<object[]>();
        
        foreach (var entry in grouped)
        {
            categories[entry.Name] = true;
            resultValues = resultValues.Append(
                new object[]
                {
                    entry.Name, 
                    entry.NotStarted != 0 ? entry.NotStarted : "", 
                    entry.InProgress != 0 ? entry.InProgress : "", 
                    entry.InReview != 0 ? entry.InReview : "", 
                    entry.Done != 0 ? entry.Done : ""
                }).ToList();
        }

        foreach (var key in categories.Where(v => v.Value == false))
        {
            resultValues = resultValues.Append(
                new object[]
                {
                    key.Key,
                    "",
                    "",
                    "",
                    ""
                }).ToList();
        }

        resultValues.Reverse();
        result.AddRange(resultValues);
        
        return result.ToArray();
    }

    public object[] GetProgressChart(ulong? projectId=null)
    {
        var progressPerType = _taskRepository.Entities
            .Include(x => x.Project)
            .Include(x => x.Type).AsQueryable();

        var types = _taskTypeRepository.Entities.ToList()
            .GroupBy(x => x.Name)
            .ToDictionary(k => k.Key, v => false);
        
        if (projectId.HasValue)
            progressPerType = progressPerType.Where(x => x.Project.Id == projectId.Value);
        
        var result = new List<object[]>
        {
            new object[] //header
            {
                "Type", "Não iniciada", "Em andamento", "Em revisão", "Concluída"
            }
        };
        
        var grouped = progressPerType
            .GroupBy(x => x.Type.Id)
            .Select(x => new
            {
                Name = x.FirstOrDefault()!.Type.Name,
                NotStarted = x.Count(e => e.Status == TaskStatus.NotStarted),
                InProgress = x.Count(e => e.Status == TaskStatus.InProgress),
                InReview = x.Count(e => e.Status == TaskStatus.InReview),
                Done = x.Count(e => e.Status == TaskStatus.Done),
                Priority = x.Count(e => e.Status != TaskStatus.Done)
            }).OrderByDescending(x => x.Priority).ToList();
        
        var resultValues = new List<object[]>();
        
        foreach (var entry in grouped)
        {
            types[entry.Name] = true;
            resultValues = resultValues.Append(
                new object[]
                {
                    entry.Name, 
                    entry.NotStarted != 0 ? entry.NotStarted : "", 
                    entry.InProgress != 0 ? entry.InProgress : "", 
                    entry.InReview != 0 ? entry.InReview : "", 
                    entry.Done != 0 ? entry.Done : ""
                }).ToList();
        }

        foreach (var key in types.Where(v => v.Value == false))
        {
            resultValues = resultValues.Append(
                new object[]
                {
                    key.Key,
                    "",
                    "",
                    "",
                    ""
                }).ToList();
        }

        resultValues.Reverse();
        result.AddRange(resultValues);
        
        return result.ToArray();
    }

    public object[] GetProgressPerProjectChart(ulong? projectId = null)
    {
        var progressPerProjects = _taskRepository.Entities
            .Include(x => x.Project)
            .AsQueryable();

        if (projectId.HasValue)
            progressPerProjects = progressPerProjects.Where(x => x.Project.Id == projectId.Value);
        
        var result = new List<object[]>
        {
            
        };
        var taskStatus = Enum.GetValues<TaskStatus>()
            .GroupBy(x => x)
            .ToDictionary(k => k.Key, v => 0);
        
        var grouped = progressPerProjects
            .GroupBy(x => x.Status)
            .Select(x => new
            {
                Status = x.Key,
                Count = x.Count()
            }).ToList();
        
        var resultValues = new List<object[]>();
        
        foreach (var entry in grouped)
        {
            taskStatus[entry.Status] = entry.Count;
        }
        
        foreach (var entry in taskStatus)
        {
            resultValues = resultValues.Append(
                new object[]
                {
                    EnumHelper<TaskStatus>.GetDisplayValue(entry.Key) + 
                    (entry.Key is TaskStatus.Done or TaskStatus.NotStarted ? "s" : string.Empty), 
                    entry.Value
                }).ToList();
        }
        
        result.AddRange(resultValues);
        
        return result.ToArray();
    }
}

