
using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.Assets;
using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Enums;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Customs;
using CCMS.NEOPE.Infra.Helpers;
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
    private readonly ITaskStepRepository _stepRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAccountableRepository _accountableRepository;
    private readonly IAssetProjectStatusRepository _assetProjectStatusRepository;

    public AssetService(
        IAssetRepository assetRepository,
        IProjectRepository projectRepository,
        IAssetTypeRepository assetTypeRepository,
        ITaskRepository taskRepository,
        ITaskStepRepository stepRepository,
        ICategoryRepository categoryRepository,
        IAccountableRepository accountableRepository,
        IAssetProjectStatusRepository assetProjectStatusRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _assetRepository = assetRepository;
        _projectRepository = projectRepository;
        _taskRepository = taskRepository;
        _assetTypeRepository = assetTypeRepository;
        _unitOfWork = unitOfWork;
        _stepRepository = stepRepository;
        _categoryRepository = categoryRepository;
        _accountableRepository = accountableRepository;
        _assetProjectStatusRepository = assetProjectStatusRepository;
        _mapper = mapper;
    }
    
    public void Add(AddAssetModel model)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        var asset = _mapper.Map<Asset>(model);
        Project?  project = null;
        
        if(model.SelectedProject.HasValue)
        {
            project = _projectRepository.Get(model.SelectedProject.Value);
            asset.Project = project;
        }

        AssetType?  assetType = null;
        if(model.TypeId.HasValue)
             assetType = _assetTypeRepository.Get(model.TypeId.Value);
        asset.Type = assetType;

        var status = new AssetProjectStatus()
        {
            CreateDate = DateTime.Now,
            Status = Domain.Enums.Status.NotStarted,
            Asset = asset
        };
        asset.Status = status;
        
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
            .Include(x => x.Project)
            .Include(x => x.Type)
            .ThenInclude(x => x.AllowedSteps)
            .Include(x => x.Status)
            .FirstOrDefault(x => x.Id == model.Id);

        if (asset != null)
        {
            _mapper.Map(model, asset);
            
            Project?  project = null;
        
            if(model.SelectedProject.HasValue)
            {
                project = _projectRepository.Get(model.SelectedProject.Value);
                asset.Project = project;
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
            .Include(x => x.Project)
            .Include(x => x.Status)
            .Include(x => x.Type)
            .ThenInclude(x => x.AllowedSteps)
            .FirstOrDefault(x => x.Id == id);
        if (project == null) return null;
        var model = _mapper.Map<EditAssetModel>(project);
        model.Projects = GetProjectsSelectList(model.SelectedProject);
        model.Types = GetTypesSelectList(model.TypeId);

        return model;
    }

    private SelectList GetProjectsSelectList(ulong? id)
    {
        return new SelectList(_projectRepository.Entities
            .ToList().Select(x =>
                new SelectListItem() { Text = x.Code, Value = x.Id.ToString() }).ToList(),"Value","Text", id);
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
        model.Projects = GetProjectsSelectList(model.SelectedProject);
        model.Types = GetTypesSelectList(model.TypeId);
        
        return model;
    }

    public ActivityModel GetActivity(ulong assetId)
    {
        var assetStatus = _assetProjectStatusRepository.Entities
            .Include(x => x.Asset)
            .ThenInclude(x => x.Type)
            .ThenInclude(x => x.AllowedSteps)
            .Include(x => x.Asset)
            .ThenInclude(x => x.Project)
            .Include(x => x.Assignees)
            .Include(x => x.Attachments)
            .Include(x => x.Category)
            .Include(x => x.Step)
            .Include(x => x.Logs)
            .Include(x => x.Comments)
            .Where(x => x.Asset.Id == assetId)
            .FirstOrDefault();
            
        if(assetStatus != null)
        {
            var model = _mapper.Map<ActivityModel>(assetStatus);

            model.Assignees = GetAssigneesSelectList(model.AssigneeIds);

            model.Categories = GetCategoriesSelectList(model.SelectedCategory);

            model.Status = GetStatusSelectList(model.SelectedStatus);

            model.Steps = GetStepsSelectList(model.StepId, assetStatus.Asset.Type);

            return model;
        }

        return null;
    }

    private SelectList GetStatusSelectList(Status? status)
    {
        var types = new List<SelectListItem>();
        types.AddRange(Enum.GetValues<Status>()
            .Select(x => new SelectListItem() { Text = EnumHelper<Status>.GetDisplayValue(x), Value = x.ToString() }));
        return new SelectList(types, "Value","Text", status);
    }
    private MultiSelectList GetAssigneesSelectList(ICollection<ulong>? ids)
    {
        var types = new List<SelectListItem>();
        types.AddRange(_accountableRepository.Entities.ToList()
            .Select(x => new SelectListItem() { Text = x.DisplayName, Value = x.Id.ToString() }));
        return new MultiSelectList(types, "Value","Text", ids);
    }
    private SelectList GetStepsSelectList(int? stepId, AssetType assetType)
    {
        var types = new List<SelectListItem>()
            { new SelectListItem() { Text = "" } };
        types.AddRange(_stepRepository.Entities.Where(x => !assetType.AllowedSteps.Select(x => x.Id).Any() || 
            assetType.AllowedSteps.Select(x => x.Id).Any(id => id == x.Id) || x.Id == stepId ).ToList()
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

}