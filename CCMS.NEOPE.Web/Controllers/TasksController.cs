using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;

public class TasksController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetTasks(int pageIndex = 0)
    {
        return Json(new {
            Nome = "Dalton",
            Idade = "32",
            Options = new List<string>(){ "arroz","feijao","carne"}
        });
    }
    
}