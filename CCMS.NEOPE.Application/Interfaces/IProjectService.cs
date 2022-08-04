using CCMS.NEOPE.Application.ViewModels.Project;

namespace CCMS.NEOPE.Application.Interfaces;

public interface IProjectService
{
    void CreateProject(CreateProjectViewModel model);
}