using CCMS.NEOPE.Application.Interfaces;
using CCMS.NEOPE.Application.ViewModels.AssetTypes;
using CCMS.NEOPE.Infra.Data.Mappings;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Web.Controllers;

public class AssetTypesController : Controller
{
    private readonly IAssetTypeService _assetTypeService;

    public AssetTypesController(IAssetTypeService assetTypeService)
    {
        _assetTypeService = assetTypeService;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Add()
    {
        var model = _assetTypeService.Get();
        return View(model);
    }
    
    
    [HttpPost]
    public IActionResult Add(AddAssetTypeModel model)
    {
        if (!ModelState.IsValid) return View(model);
        _assetTypeService.Add(model);
        return RedirectToAction("Index", "AssetTypes");
    }
    
    [HttpPost]
    public IActionResult List()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        var pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
        var skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");

        var paged = _assetTypeService.List(searchValue, skip, pageSize);
        
        var returnObj = new {
            draw = draw, recordsTotal = paged.TotalCount, recordsFiltered = paged.FilteredCount, data = paged.ToList()
        };
        
        return Json(returnObj);
    }

    [HttpGet]
    public IActionResult Edit(ulong id)
    {
        var model = _assetTypeService.Get((ulong)id);
        
        if (model != null)
            return View(model);
        
        return NotFound();
    }
    
    [HttpPost]
    public IActionResult Edit(EditAssetTypeModel model)
    {
        if (!ModelState.IsValid) return View(model);
        _assetTypeService.Edit(model);
        return RedirectToAction("Index", "AssetTypes");
    }

    [HttpDelete]
    public IActionResult Delete(ulong id)
    {
        _assetTypeService.Delete(id);
        return Ok();
    }
}