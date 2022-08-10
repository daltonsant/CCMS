
using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.Assets;
using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Customs;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CCMS.NEOPE.Application.Services;

public class AssetService : IAssetService
{
    private readonly IAssetRepository _assetRepository;
    private readonly IAssetTypeRepository _assetTypeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepository;
    private readonly ITaskRepository _taskRepository;

    public AssetService(
        IAssetRepository assetRepository,
        IProjectRepository projectRepository,
        IAssetTypeRepository assetTypeRepository,
        ITaskRepository taskRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _assetRepository = assetRepository;
        _projectRepository = projectRepository;
        _taskRepository = taskRepository;
        _assetTypeRepository = assetTypeRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public void Add(AddAssetModel model)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        var asset = _mapper.Map<Asset>(model);
        Project?  project = null;
        
        if(model.ProjectIds != null)
        {
            foreach (var id in model.ProjectIds)
            {
                project = _projectRepository.Get(id);
                if(project != null)
                    asset.Projects.Add(project);
            }
        }
           
        TaskItem? task = null;
        if (model.TaskIds!=null)
        {
            foreach (var id in model.TaskIds)
            {
                task = _taskRepository.Get(id);
                if(task != null)
                    asset.Tasks.Add(task);
            }
        }

        AssetType?  assetType = null;
        if(model.TypeId.HasValue)
             assetType = _assetTypeRepository.Get(model.TypeId.Value) ;
        
        asset.Type = assetType;

        _assetRepository.Save(asset);
        
        transaction.Commit();
    }

    public IPagedList<ViewAssetModel> List(string? searchString, int skip, int pageSize)
    {
        var data = _assetRepository.Entities.Include(c => c.Type).AsQueryable();
        
        var totalRecord = data.Count();
        
        if (!string.IsNullOrEmpty(searchString)) {
            data = data.Where(x => 
                x.Code != null && x.Description != null &&
                (x.Code.ToLower().Contains(searchString.ToLower()) || 
                 x.Description.ToLower().Contains(searchString.ToLower()) ||
                 x.Type.Name.ToLower().Contains(searchString.ToLower())));
        }
        var filterRecord = data.Count();
        
        var list = data.Skip(skip).Take(pageSize).ToList();
        
        var records = 
            _mapper.Map<ICollection<Asset>, ICollection<ViewAssetModel>>(list.ToList());

        return new PagedList<ViewAssetModel>(totalRecord, filterRecord, records);
    }

    public void Edit(EditAssetModel model)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        var asset = _assetRepository.Entities
            .Include(x => x.Tasks)
            .Include(x => x.Projects)
            .Include(x => x.Type)
            .FirstOrDefault(x => x.Id == model.Id);

        if (asset != null)
        {
            asset.Tasks.Clear();
            asset.Projects.Clear();
            _mapper.Map(model, asset);
            
            Project?  project = null;
        
            if(model.ProjectIds != null)
            {
                foreach (var id in model.ProjectIds)
                {
                    project = _projectRepository.Get(id);
                    if(project != null)
                        asset.Projects.Add(project);
                }
            }
           
            TaskItem? task = null;
            if (model.TaskIds!=null)
            {
                foreach (var id in model.TaskIds)
                {
                    task = _taskRepository.Get(id);
                    if(task != null)
                        asset.Tasks.Add(task);
                }
            }

            AssetType?  assetType = null;
            if(model.TypeId.HasValue)
                assetType = _assetTypeRepository.Get(model.TypeId.Value) ;
        
            asset.Type = assetType;
            _assetRepository.Update(asset);
        }
        
        transaction.Commit();
    }

    public void Delete(ulong id)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        _assetRepository.Delete(id);
        transaction.Commit();
    }

    public EditAssetModel? Get(ulong id)
    {
        var project = _assetRepository.Entities
            .Include(x => x.Projects)
            .Include(x => x.Tasks)
            .Include(x => x.Type)
            .FirstOrDefault(x => x.Id == id);
        if (project == null) return null;
        var model = _mapper.Map<EditAssetModel>(project);
        model.Projects = GetProjectsSelectList(model.ProjectIds);
        model.Tasks = GetTasksSelectList(model.TaskIds);
        model.Types = GetTypesSelectList(model.TypeId);

        return model;
    }

    private MultiSelectList GetProjectsSelectList(IEnumerable<ulong>? ids)
    {
        return new MultiSelectList(_projectRepository.Entities
            .ToList().Select(x =>
                new SelectListItem() { Text = x.Code, Value = x.Id.ToString() }).ToList(),"Value","Text", ids);
    }
    private MultiSelectList GetTasksSelectList(IEnumerable<ulong>? ids)
    {
        return new MultiSelectList(_taskRepository.Entities
            .ToList().Select(x =>
                new SelectListItem() { Text = x.Title, Value = x.Id.ToString() }).ToList(),"Value","Text", ids);
    }

    private SelectList GetTypesSelectList(ulong? id)
    {
        var types = new List<SelectListItem>()
            { new SelectListItem() { Text = "Selecione um tipo" } };
        types.AddRange(_assetTypeRepository.Entities.ToList()
            .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }));
        return new SelectList(types, "Value","Text", id);
    }
    
    public AddAssetModel GetAddAssetModel()
    {
        var model = new AddAssetModel();
        model.Projects = GetProjectsSelectList(model.ProjectIds);
        model.Tasks = GetTasksSelectList(model.TaskIds);
        model.Types = GetTypesSelectList(model.TypeId);
        
        return model;
    }
}