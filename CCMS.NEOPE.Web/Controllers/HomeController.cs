using System.Diagnostics;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBoardService _boardService;

    public HomeController(ILogger<HomeController> logger, IBoardService boardSerice)
    {
        _logger = logger;
        _boardService = boardSerice;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public IActionResult GetProgress(ulong? projectId=null)
    {
        return Json(
            new { 
                totalProgress = _boardService.GetProgress(), 
                totalConformity = _boardService.GetConformity(), 
                totalAdherence = _boardService.GetAdherence(),
                qo = _boardService.GetQo(),
                apos = _boardService.GetApos(),
                charts = new object[]
                {
                    _boardService.GetPendenciesPerStepsChart(),
                    _boardService.GetPendenciesPerCategoryChart(),
                    _boardService.GetProgressChart(),
                    _boardService.GetProgressPerProjectChart()
                }
            });
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(string code, string url)
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}