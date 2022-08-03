using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;

public class CalendarController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}