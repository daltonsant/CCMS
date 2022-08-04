using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.Project;
using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;

namespace CCMS.NEOPE.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProjectService(
        IProjectRepository repository, 
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public void CreateProject(CreateProjectViewModel model)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        var project = _mapper.Map<Project>(model);
        _repository.Save(project);
        transaction.Commit();
    }
}