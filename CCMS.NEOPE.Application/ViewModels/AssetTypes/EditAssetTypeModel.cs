using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Application.ViewModels.AssetTypes;

public class EditAssetTypeModel
{
    [Display(Name = "Id")]
    public ulong Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(64, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Nome")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(256, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Description")]
    public string Description { get; set; } = string.Empty;
}