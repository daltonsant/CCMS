using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;

public class BoardController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}