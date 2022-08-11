using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.TaskType;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;

public class TaskTypesController : Controller
{
    private readonly ITaskTypeService _taskTypeService;

    public TaskTypesController(ITaskTypeService taskTypeService)
    {
        _taskTypeService = taskTypeService;
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
    public IActionResult Add(AddTaskTypeModel model)
    {
        if (!ModelState.IsValid) return View(model);
        _taskTypeService.Add(model);
        return RedirectToAction("Index", "TaskTypes");
    }
    
    public IActionResult List()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        var pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
        var skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");

        var paged = _taskTypeService.List(searchValue, skip, pageSize);
        
        var returnObj = new {
            draw = draw, recordsTotal = paged.TotalCount, recordsFiltered = paged.FilteredCount, data = paged.ToList()
        };
        
        return Json(returnObj);
    }

    [HttpGet]
    public IActionResult Edit(ulong id)
    {
        var model = _taskTypeService.Get((ulong)id);
        
        if (model != null)
            return View(model);
        
        return NotFound();
    }
    
    [HttpPost]
    public IActionResult Edit(EditTaskTypeModel model)
    {
        if (!ModelState.IsValid) return View(model);
        _taskTypeService.Edit(model);
        return RedirectToAction("Index", "TaskTypes");
    }

    [HttpDelete]
    public IActionResult Delete(ulong id)
    {
        _taskTypeService.Delete(id);
        return Ok();
    }
}