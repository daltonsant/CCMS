using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;

public class DashboardsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}