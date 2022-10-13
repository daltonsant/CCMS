using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.TaskStep;
using CCMS.NEOPE.Domain.Core.Interfaces;
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Interfaces;
using CCMS.NEOPE.Infra.Customs;

namespace CCMS.NEOPE.Application.Services;

public class TaskStepService : ITaskStepService
{
    private readonly ITaskStepRepository _taskStepRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TaskStepService(
        ITaskStepRepository taskStepRepository, 
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _taskStepRepository = taskStepRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public void Add(AddTaskStepModel model)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        var step = _mapper.Map<Step>(model);
        _taskStepRepository.Save(step);
        transaction.Commit();
    }

    public IPagedList<ViewTaskStepModel> List(string? searchString, int skip, int pageSize)
    {
        var data = _taskStepRepository.Entities;
        
        var totalRecord = data.Count();
        
        if (!string.IsNullOrEmpty(searchString)) {
            data = data.Where(x => 
                x.Name != null && 
                x.Name.ToLower().Contains(searchString.ToLower()));
        }
        var filterRecord = data.Count();
        
        var list = data.Skip(skip).Take(pageSize).ToList();
        
        var records = 
            _mapper.Map<ICollection<Step>, ICollection<ViewTaskStepModel>>(list.ToList());

        return new PagedList<ViewTaskStepModel>(totalRecord, filterRecord, records);
    }

    public void Edit(EditTaskStepModel model)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        var stepToUpdate = _taskStepRepository.Get(model.Id);

        _mapper.Map(model, stepToUpdate);
        
        _taskStepRepository.Update(stepToUpdate);
        transaction.Commit();
    }

    public void Delete(int id)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        
        _taskStepRepository.Delete(id);
        transaction.Commit();

    }

    public EditTaskStepModel? Get(int id)
    {
        var project = _taskStepRepository.Get(id);
        if (project != null)
        {
            var model = _mapper.Map<EditTaskStepModel>(project);
            return model;
        }

        return null;
    }
}