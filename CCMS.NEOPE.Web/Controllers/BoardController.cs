using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.Assets;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;

public class BoardController : Controller
{
    private readonly IAssetService _assetService;
    private readonly IMapper _mapper;
    
    public BoardController(
        IAssetService assetService,
        IMapper mapper)
    {
        _assetService = assetService;
        _mapper = mapper;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Status(ulong id)
    {
        var model = new ActivityModel();
        model = _assetService.GetActivity(id);

        return View(model);
    }
     
    [HttpPost]
    public IActionResult Status(ActivityModel model)
    {
        if(ModelState.IsValid)
            return Json(new {  });
        return View(model);
    }

}