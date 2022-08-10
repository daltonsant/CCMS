using Azure.Core;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.Project;
using CCMS.NEOPE.Application.ViewModels.TaskStep;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;

public class TaskStepsController : Controller
{
    private readonly ITaskStepService _taskStepService;

    public TaskStepsController(ITaskStepService taskStepService)
    {
        _taskStepService = taskStepService;
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
    public IActionResult Add(AddTaskStepModel model)
    {
        if (!ModelState.IsValid) return View(model);
        _taskStepService.Add(model);
        return RedirectToAction("Index", "TaskSteps");
    }
    
    public IActionResult List()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        var pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
        var skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");

        var paged = _taskStepService.List(searchValue, skip, pageSize);
        
        var returnObj = new {
            draw = draw, recordsTotal = paged.TotalCount, recordsFiltered = paged.FilteredCount, data = paged.ToList()
        };
        
        return Json(returnObj);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var model = _taskStepService.Get(id);
        
        if (model != null)
            return View(model);
        
        return NotFound();
    }
    
    [HttpPost]
    public IActionResult Edit(EditTaskStepModel model)
    {
        if (!ModelState.IsValid) return View(model);
        _taskStepService.Edit(model);
        return RedirectToAction("Index", "TaskSteps");
    }
}