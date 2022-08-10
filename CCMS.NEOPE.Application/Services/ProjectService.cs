using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.Project;
using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Customs;

namespace CCMS.NEOPE.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProjectService(
        IProjectRepository projectRepository, 
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public void Add(AddProjectModel model)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        var project = _mapper.Map<Project>(model);
        _projectRepository.Save(project);
        transaction.Commit();
    }

    public IPagedList<ViewProjectModel> List(string? searchString, int skip, int pageSize)
    {
        var data = _projectRepository.Entities;
        
        var totalRecord = data.Count();
        
        if (!string.IsNullOrEmpty(searchString)) {
            data = data.Where(x => 
                x.Code != null && x.Name != null && 
                (x.Code.ToLower().Contains(searchString.ToLower()) || 
                 x.Name.ToLower().Contains(searchString.ToLower())));
        }
        var filterRecord = data.Count();
        
        var list = data.Skip(skip).Take(pageSize).ToList();
        
        var records = 
            _mapper.Map<ICollection<Project>, ICollection<ViewProjectModel>>(list.ToList());

        return new PagedList<ViewProjectModel>(totalRecord, filterRecord, records);
    }

    public void Edit(EditProjectModel model)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        var projectToUpdate = _projectRepository.Get(model.Id);

        _mapper.Map(model, projectToUpdate);
        
        _projectRepository.Update(projectToUpdate);
        transaction.Commit();
    }

    public void Delete(ulong id)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        
        _projectRepository.Delete(id);
        transaction.Commit();
    }

    public EditProjectModel? Get(ulong id)
    {
        var project = _projectRepository.Get(id);
        if (project != null)
        {
            var model = _mapper.Map<EditProjectModel>(project);
            return model;
        }

        return null;
    }
}