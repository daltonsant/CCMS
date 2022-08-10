using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.AssetTypes;
using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Customs;

namespace CCMS.NEOPE.Application.Services;

public class AssetTypeService : IAssetTypeService
{
    private readonly IAssetTypeRepository _assetTypeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AssetTypeService(
        IAssetTypeRepository assetTypeRepository, 
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _assetTypeRepository = assetTypeRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public void Add(AddAssetTypeModel model)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        var project = _mapper.Map<AssetType>(model);
        _assetTypeRepository.Save(project);
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
        using var transaction = _unitOfWork.BeginTransaction();
        var projectToUpdate = _assetTypeRepository.Get(model.Id);

        _mapper.Map(model, projectToUpdate);
        
        _assetTypeRepository.Update(projectToUpdate);
        transaction.Commit();
    }

    public void Delete(ulong id)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        
        _assetTypeRepository.Delete(id);
        transaction.Commit();
    }

    public EditAssetTypeModel? Get(ulong id)
    {
        var project = _assetTypeRepository.Get(id);
        if (project == null) return null;
        var model = _mapper.Map<EditAssetTypeModel>(project);
        return model;

    }
}