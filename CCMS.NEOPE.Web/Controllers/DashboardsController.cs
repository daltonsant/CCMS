using CCMS.NEOPE.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;

public class DashboardsController : Controller
{
    private readonly IBoardService _boardService;
    private readonly IProjectService _projectService;

    public DashboardsController(
        IBoardService boardSerice,
        IProjectService projectService)
    {
        _boardService = boardSerice;
        _projectService = projectService;
    }
    
    // GET
    public IActionResult Index()
    {
        return View(_projectService.GetProjectSelect());
    }
    
    [HttpPost]
    public IActionResult GetProgress(ulong? projectId=null)
    {
        return Json(
            new { 
                totalProgress = _boardService.GetProgress(projectId), 
                totalConformity = _boardService.GetConformity(projectId), 
                totalAdherence = _boardService.GetAdherence(projectId),
                qo = _boardService.GetQo(projectId),
                apos = _boardService.GetApos(projectId),
                charts = new object[]
                {
                    _boardService.GetPendenciesPerStepsChart(projectId),
                    _boardService.GetPendenciesPerCategoryChart(projectId),
                    _boardService.GetProgressChart(projectId),
                    _boardService.GetProgressPerProjectChart(projectId)
                }
            });
    }
    
}