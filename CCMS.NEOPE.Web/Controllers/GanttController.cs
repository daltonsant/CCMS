using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;

public class GanttController : Controller
{
    
    private readonly ITaskService _taskService;
    private readonly IMapper _mapper;

    public GanttController(
        ITaskService taskService,
        IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }
    
}