using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.AssetTypes;
using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Customs;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CCMS.NEOPE.Application.Services;

public class AssetTypeService : IAssetTypeService
{
    private readonly IAssetTypeRepository _assetTypeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITaskStepRepository _stepRepository;
    private readonly IMapper _mapper;

    public AssetTypeService(
        IAssetTypeRepository assetTypeRepository, 
        IUnitOfWork unitOfWork,
        ITaskStepRepository stepRepository,
        IMapper mapper)
    {
        _assetTypeRepository = assetTypeRepository;
        _stepRepository = stepRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public void Add(AddAssetTypeModel model)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        var assetType = _mapper.Map<AssetType>(model);
        if(model.SelectedSteps != null && model.SelectedSteps.Any())
        {
            var ids = model.SelectedSteps.ToList();
            var steps = _stepRepository.Entities.Where(x => ids.Contains(x.Id)).OrderBy(x => x.Id).ToList();
            assetType.AllowedSteps = new List<Step>(steps);
        }

        _assetTypeRepository.Save(assetType);
        transaction.Commit();
    }

    public IPagedList<ViewAssetTypeModel> List(string? searchString, int skip, int pageSize)
    {
        var data = _assetTypeRepository.Entities;
        
        var totalRecord = data.Count();
        
        if (!string.IsNullOrEmpty(searchString)) {
            data = data.Where(x => 
                x.Name != null && x.Description != null && 
                (x.Name.ToLower().Contains(searchString.ToLower()) || 
                 x.Description.ToLower().Contains(searchString.ToLower())));
        }
        var filterRecord = data.Count();
        
        var list = data.Skip(skip).Take(pageSize).ToList();
        
        var records = 
            _mapper.Map<ICollection<AssetType>, ICollection<ViewAssetTypeModel>>(list.ToList());

        return new PagedList<ViewAssetTypeModel>(totalRecord, filterRecord, records);
    }

    public void Edit(EditAssetTypeModel model)
    {
       
        var assetTypeToUpdate = _assetTypeRepository.Entities
            .Include(x => x.AllowedSteps)
            .FirstOrDefault(x => x.Id == model.Id);

        if(assetTypeToUpdate != null)
        {
             using var transaction = _unitOfWork.BeginTransaction();
            _mapper.Map(model, assetTypeToUpdate);

            if(model.SelectedSteps != null && model.SelectedSteps.Any())
            {
                var ids = model.SelectedSteps.ToList();
                var steps = _stepRepository.Entities.Where(x => ids.Contains(x.Id)).OrderBy(x => x.Id).ToList();
                assetTypeToUpdate.AllowedSteps.Clear();
                assetTypeToUpdate.AllowedSteps = new List<Step>(steps);
            }

            _assetTypeRepository.Update(assetTypeToUpdate);
            transaction.Commit();
        }
    }

    public void Delete(ulong id)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        
        _assetTypeRepository.Delete(id);
        transaction.Commit();
    }

    public EditAssetTypeModel? Get(ulong id)
    {
        var assetType = _assetTypeRepository.Entities
            .Include(x => x.AllowedSteps)
            .FirstOrDefault(x => x.Id ==id);

        if (assetType == null) return null;

        var model = _mapper.Map<EditAssetTypeModel>(assetType);
        
        var steps = new List<SelectListItem>();
        steps.AddRange(_stepRepository.Entities.ToList()
            .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }));

         model.AvailableSteps =  new MultiSelectList(steps, "Value","Text", model.SelectedSteps.Select(x => x.ToString()));

        return model;
    }
    public AddAssetTypeModel Get()
    {
        var model = new AddAssetTypeModel();

        var steps = new List<SelectListItem>();
        steps.AddRange(_stepRepository.Entities.ToList()
            .Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }));

        model.AvailableSteps = new MultiSelectList(steps, "Value","Text");

        return model;
    }
}