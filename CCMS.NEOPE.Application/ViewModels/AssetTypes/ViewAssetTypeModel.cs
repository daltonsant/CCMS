using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Application.ViewModels.AssetTypes;

public class ViewAssetTypeModel
{
    [Display(Name = "Id")]
    public ulong Id { get; set; }
    
    [Display(Name = "Nome")]
    public string Name { get; set; } = string.Empty;
    
}