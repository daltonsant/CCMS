using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.Project;
using CCMS.NEOPE.Application.ViewModels.TaskType;
using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Customs;

namespace CCMS.NEOPE.Application.Services;

public class TaskTypeService : ITaskTypeService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITaskTypeRepository _taskTypeRepository;

    public TaskTypeService(
        ITaskTypeRepository taskTypeRepository, 
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _taskTypeRepository = taskTypeRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    
    public void Add(AddTaskTypeModel model)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        var project = _mapper.Map<TaskType>(model);
        _taskTypeRepository.Save(project);
        transaction.Commit();
    }

    public IPagedList<ViewTaskTypeModel> List(string? searchString, int skip, int pageSize)
    {
        var data = _taskTypeRepository.Entities;
        
        var totalRecord = data.Count();
        
        if (!string.IsNullOrEmpty(searchString)) {
            data = data.Where(x => 
                x.Name != null && 
                (x.Name.ToLower().Contains(searchString.ToLower())));
        }
        var filterRecord = data.Count();
        
        var list = data.Skip(skip).Take(pageSize).ToList();
        
        var records = 
            _mapper.Map<ICollection<TaskType>, ICollection<ViewTaskTypeModel>>(list.ToList());

        return new PagedList<ViewTaskTypeModel>(totalRecord, filterRecord, records);
    }

    public void Edit(EditTaskTypeModel model)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        var projectToUpdate = _taskTypeRepository.Get(model.Id);

        _mapper.Map(model, projectToUpdate);
        
        _taskTypeRepository.Update(projectToUpdate);
        transaction.Commit();
    }

    public void Delete(ulong id)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        
        _taskTypeRepository.Delete(id);
        transaction.Commit();
    }

    public EditTaskTypeModel? Get(ulong id)
    {
        var project = _taskTypeRepository.Get(id);
        if (project != null)
        {
            var model = _mapper.Map<EditTaskTypeModel>(project);
            return model;
        }

        return null;
    }
}