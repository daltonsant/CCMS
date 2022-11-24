using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CCMS.NEOPE.Application.ViewModels.AssetTypes;

public class AddAssetTypeModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(64, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Nome")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(256, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Descrição")]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Etapas de comissionamento para o tipo")]
    public ICollection<int> SelectedSteps { get; set; }

    public MultiSelectList? AvailableSteps { get; set; }
}