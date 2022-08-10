using CCMS.NEOPE.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;
[Authorize]
public class TasksController : Controller
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult GetTasks()
    {
        int totalRecord = 0;
        int filterRecord = 0;
        var draw = Request.Form["draw"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        var pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
        var skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
        
        var data = /*_context.Set < Employees > ()*/_taskService.GetTasks(searchValue, skip, pageSize).AsQueryable();
        //get total count of data in table
        totalRecord = data.Count();
        
        // search data when search value found
       /* if (!string.IsNullOrEmpty(searchValue)) {
            data = data.Where(x => 
                x.EmployeeFirstName.ToLower().Contains(searchValue.ToLower()) || 
                x.EmployeeLastName.ToLower().Contains(searchValue.ToLower()) || 
                x.Designation.ToLower().Contains(searchValue.ToLower()) || 
                x.Salary.ToString().ToLower().Contains(searchValue.ToLower()));
        }*/
        
        // get total count of records after search
        filterRecord = data.Count();
        
        //sort data
        /*if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection)) 
            data = data.OrderBy(sortColumn + " " + sortColumnDirection);*/
        /*
         *inputs: skip, pagesize, string searchValue, sort expressions
         * outputs: total records, filteredRecords, list
         */
        
        //pagination
        var empList = data.Skip(skip).Take(pageSize).ToList();
        
        var returnObj = new {
            draw = draw, recordsTotal = totalRecord, recordsFiltered = filterRecord, data = empList
        };
        
        return Json(returnObj);
    }

    public IActionResult Edit(int id)
    {
        return View();
    }
    public IActionResult Add()
    {
        return Json("");
    }
    public IActionResult EditType()
    {
        return Json("");
    }
    public IActionResult AddType()
    {
        return Json("");
    }
}