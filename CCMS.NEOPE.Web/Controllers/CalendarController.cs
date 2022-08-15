using CCMS.NEOPE.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;

public class CalendarController : Controller
{
    private readonly ICalendarService _calendarService;

    public CalendarController(ICalendarService calendarService)
    {
        _calendarService = calendarService;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }


    public IActionResult List()
    {
        return Json(_calendarService.List());
    }
}