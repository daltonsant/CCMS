using CCMS.NEOPE.Application.ViewModels.Tasks;
using CCMS.NEOPE.Domain.Core.Interfaces;

namespace CCMS.NEOPE.Application.Interfaces;

public interface ITaskService
{
    void Add(AddTaskModel model);
    IPagedList<ViewTaskModel> List(string? searchString, int skip, int pageSize);
    void Edit(EditTaskModel model);
    void Delete(ulong Id);
    EditTaskModel? Get(ulong id);
    AddTaskModel Get();
    object GetTasks(string search, int page, ulong? exceptId);
}