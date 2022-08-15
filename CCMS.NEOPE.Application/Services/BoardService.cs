using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = CCMS.NEOPE.Domain.Enums.TaskStatus;

namespace CCMS.NEOPE.Application.Services;

public class BoardService : IBoardService
{
    private readonly ITaskRepository _taskRepository;

    public BoardService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public decimal GetAdherence()
    {
        var entities = _taskRepository.Entities
            .Include(x => x.Project)
            .Include(x => x.Type);
        
        return GetAdherence(entities);
    }

    public decimal GetAdherencePerProject(ulong projectId)
    {
        var entities = _taskRepository.Entities
            .Include(x => x.Project)
            .Include(x => x.Type)
            .Where(x => x.Project.Id == projectId);

       
        return GetAdherence(entities);
    }

    private decimal GetAdherence(IQueryable<TaskItem> entities)
    {
        var totalTasks = entities.Count(x => x.Status != TaskStatus.Done);
        var scheduledTasks = entities.Count(x => x.Status != TaskStatus.Done &&
                                                 (!x.DueDate.HasValue || x.DueDate.Value < DateTime.Now));
        return totalTasks != decimal.Zero ? 1.0M-((decimal)scheduledTasks / totalTasks) : decimal.One;
    }

    public decimal GetConformity()
    {
        var entities = _taskRepository.Entities
            .Include(x => x.Project)
            .Include(x => x.Type);

        return GetConformity(entities);
    }

    public decimal GetConformityPerProject(ulong projectId)
    {
        var entities = _taskRepository.Entities
            .Include(x => x.Project)
            .Include(x => x.Type)
            .Where(x => x.Project.Id == projectId);

        return GetConformity(entities);
    }

    private decimal GetConformity(IQueryable<TaskItem> entities)
    {
        var totalTasks = entities.Count();
        var commonTasks = entities.Where(x => !x.Type.Name.ToLower().Contains("pendência")).Count();
        return totalTasks != decimal.Zero ? (decimal)commonTasks / totalTasks : decimal.Zero;
    }

    public decimal GetProgress()
    {
        var entities = _taskRepository.Entities
            .Include(x => x.Project);

        return GetProgress(entities);
    }

    public decimal GetProgressPerProject(ulong projectId)
    {
        var entities = _taskRepository.Entities
            .Include(x => x.Project)
            .Where(x => x.Project.Id == projectId); 

        return GetProgress(entities);
    }
    private decimal GetProgress(IQueryable<TaskItem> entities)
    {
        var totalTasks = entities.Count();
        var doneTasks = entities.Where(x => x.Status == Domain.Enums.TaskStatus.Done).Count();
        return totalTasks != decimal.Zero ? (decimal)doneTasks / totalTasks : decimal.Zero;
    }
}

