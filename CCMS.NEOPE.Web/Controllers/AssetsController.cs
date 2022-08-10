using AutoMapper;
using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.Assets;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;

public class AssetsController : Controller
{
    private readonly IAssetService _assetService;
    private readonly IMapper _mapper;

    public AssetsController(
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

    public IActionResult Add()
    {
        var model = _assetService.GetAddAssetModel();
        return View(model);
    }
    
    [HttpPost]
    public IActionResult Add(AddAssetModel model)
    {
        if(ModelState.IsValid)
        {
            _assetService.Add(model);
        }
        var dbmodel = _assetService.GetAddAssetModel();
        _mapper.Map<AddAssetModel, AddAssetModel>(model, dbmodel);
        
        return View(dbmodel);
    }
    
    public IActionResult List()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        var pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
        var skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");

        var paged = _assetService.List(searchValue, skip, pageSize);
        
        var returnObj = new {
            draw = draw, recordsTotal = paged.TotalCount, recordsFiltered = paged.FilteredCount, data = paged.ToList()
        };

        return Json(returnObj);
    }

    [HttpGet]
    public IActionResult Edit(ulong id)
    {
        var model = _assetService.Get((ulong)id);
        
        if (model != null)
            return View(model);

        return NotFound();
    }
    
    [HttpPost]
    public IActionResult Edit(EditAssetModel model)
    {
        if (!ModelState.IsValid) return View(model);
        _assetService.Edit(model);
        return RedirectToAction("Index", "Assets");
    }
}