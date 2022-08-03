using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;

public class TasksController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}