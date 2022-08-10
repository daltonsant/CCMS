using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;
[Authorize]
public class ProjectsController : Controller
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Add()
    {
        return View();
    }
    
    
    [HttpPost]
    public IActionResult Add(AddProjectModel model)
    {
        if (!ModelState.IsValid) return View(model);
        _projectService.Add(model);
        return RedirectToAction("Index", "Projects");
    }
    
    public IActionResult List()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        var pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
        var skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");

        var paged = _projectService.List(searchValue, skip, pageSize);
        
        var returnObj = new {
            draw = draw, recordsTotal = paged.TotalCount, recordsFiltered = paged.FilteredCount, data = paged.ToList()
        };
        
        return Json(returnObj);
    }

    [HttpGet]
    public IActionResult Edit(ulong id)
    {
        var model = _projectService.Get((ulong)id);
        
        if (model != null)
            return View(model);
        
        return NotFound();
    }
    
    [HttpPost]
    public IActionResult Edit(EditProjectModel model)
    {
        if (ModelState.IsValid)
        {
            _projectService.Edit(model);
            return RedirectToAction("Index", "Projects");
        }
        return View(model);
    }
}