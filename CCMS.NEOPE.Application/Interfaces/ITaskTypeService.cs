using CCMS.NEOPE.Application.ViewModels.Project;
using CCMS.NEOPE.Application.ViewModels.TaskType;
using CCMS.NEOPE.Domain.Core.Interfaces;

namespace CCMS.NEOPE.Application.Interfaces;

public interface ITaskTypeService
{
    void Add(AddTaskTypeModel model);
    IPagedList<ViewTaskTypeModel> List(string? searchString, int skip, int pageSize);
    void Edit(EditTaskTypeModel model);
    void Delete(ulong Id);
    EditTaskTypeModel? Get(ulong id);
}