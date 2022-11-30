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
        if (!ModelState.IsValid)
        {
            var dbmodel = _assetService.GetActivity(model.AssetId);

            if (dbmodel == null) return NotFound();
            
            _mapper.Map<ActivityModel, ActivityModel>(model, dbmodel);
            
            return View(dbmodel);
        }

        var dic = _assetService.SaveActivity(model);
        
        return Json(dic);
    }

    [HttpPost]
    public IActionResult MoveAsset(ulong sourceId, ulong targetId, ulong assetId)
    {
        var dic = _assetService.MoveActivity(sourceId, targetId, assetId);
        
        return Json(dic);
    }

    public IActionResult GetActivities() 
    {
        
        var cards = _assetService.GetActivities();
        
        
        return Json(cards);
    }

}