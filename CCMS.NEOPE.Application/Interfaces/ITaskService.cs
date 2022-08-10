using CCMS.NEOPE.Application.ViewModels.Tasks;

namespace CCMS.NEOPE.Application.Interfaces;

public interface ITaskService
{
    ICollection<TaskReadViewModel> GetTasks(string? searchString, int skip, int pageSize);
}