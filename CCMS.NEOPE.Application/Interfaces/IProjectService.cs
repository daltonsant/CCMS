using CCMS.NEOPE.Application.ViewModels.Project;
using CCMS.NEOPE.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CCMS.NEOPE.Application.Interfaces;

public interface IProjectService
{
    void Add(AddProjectModel model);
    IPagedList<ViewProjectModel> List(string? searchString, int skip, int pageSize);
    void Edit(EditProjectModel model);
    void Delete(ulong Id);
    EditProjectModel? Get(ulong id);

    SelectList GetProjectSelect();

}