using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CCMS.NEOPE.Application.ViewModels.Assets;

public class ViewAssetModel
{
    [Display(Name = "Id")]
    public ulong Id { get; set; }

    public string Code { get; set; } = string.Empty;
    
    public string ProjectCode { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public string TypeName { get; set; }
    
}