using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;

public class ProjectsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}