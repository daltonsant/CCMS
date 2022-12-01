using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CCMS.NEOPE.Application.ViewModels.Assets;

public class EditAssetModel
{
    [Display(Name = "Id")]
    public ulong Id { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(64, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Nome")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(32, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Loc. Instal.")]
    public string Code { get; set; } = string.Empty;
    
    [Display(Name = "Tipo")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public ulong? TypeId { get; set; }
    public SelectList? Types { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Comissionamento")]
    public ulong? SelectedProject { get; set; }

    public SelectList? Projects { get; set; } 
    
    [Display(Name = "Link Compartilhamento de Documentos")]
    public string? AttachmentsLink { get; set; }
    public EditAssetModel()
    {
        Projects = new SelectList(new List<SelectListItem>(), "Value", "Text", SelectedProject);
        Types = new SelectList(new List<SelectListItem>(), "Value", "Text", TypeId);

    }
}