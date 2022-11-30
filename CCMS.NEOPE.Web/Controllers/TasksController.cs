using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;
[Authorize]
public class TasksController : Controller
{
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;

    public TasksController(
        ITaskService taskService,
        IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult GetTasks()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        var pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
        var skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
        
        var data = _taskService.List(searchValue, skip, pageSize);

        var returnObj = new {
            draw = draw, recordsTotal = data.TotalCount, recordsFiltered = data.FilteredCount, data = data.ToList()
        };
        
        return Json(returnObj);
    }

    public IActionResult Edit(ulong id)
    {
        var model = _taskService.Get(id);
        
        if (model != null)
            return View(model);

        return NotFound();
    }
    
    [HttpPost]
    public IActionResult Edit(EditTaskModel model)
    {
        if (ModelState.IsValid)
        {
            _taskService.Edit(model);
            if(!model.Errors.Any())
                return RedirectToAction("Index", "Tasks");
            
            foreach (var error in model.Errors)
            {
                ModelState.AddModelError(error.Key, error.Value);
            }
        }
        
        var dbmodel = _taskService.Get(model.Id);

        if (dbmodel == null) NotFound();
        
        _mapper.Map<EditTaskModel, EditTaskModel>(model, dbmodel);
        dbmodel.LinkedTasks = model.LinkedTasks;
        
        return View(dbmodel);
    }
    
    public IActionResult Add()
    {
        return View(_taskService.Get());
    }
    
    [HttpPost]
    public IActionResult Add(AddTaskModel model)
    {
        if(ModelState.IsValid)
        {
            _taskService.Add(model);
            if(!model.Errors.Any())
                return RedirectToAction("Index", "Tasks");
            
            foreach (var error in model.Errors)
            {
                ModelState.AddModelError(error.Key, error.Value);
            }
        }
        
        var dbmodel = _taskService.Get();
        _mapper.Map<AddTaskModel, AddTaskModel>(model, dbmodel);
        dbmodel.LinkedTasks = model.LinkedTasks;
        
        return View(dbmodel);
    }

    [HttpDelete]
    public IActionResult Delete(ulong id)
    {
        _taskService.Delete(id);
        return Ok();
    }

    public IActionResult SearchTasks(string search, int page, ulong? taskId)
    {
        return Json(_taskService.GetTasks(search, page, taskId));
    }
}