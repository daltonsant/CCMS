using CCMS.NEOPE.Application.ViewModels.TaskStep;
using CCMS.NEOPE.Domain.Core.Interfaces;

namespace CCMS.NEOPE.Application.Interfaces;

public interface ITaskStepService
{
    void Add(AddTaskStepModel model);
    IPagedList<ViewTaskStepModel> List(string? searchString, int skip, int pageSize);
    void Edit(EditTaskStepModel model);
    void Delete(int Id);
    EditTaskStepModel? Get(int id);
}