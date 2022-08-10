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
    [Display(Name = "Código PM")]
    public string Code { get; set; } = string.Empty;
    
    [Display(Name = "Tipo")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public ulong? TypeId { get; set; }
    public SelectList? Types { get; set; }


    [Display(Name = "Projetos")]
    public IEnumerable<ulong>? ProjectIds { get; set; } = new List<ulong>();

    public MultiSelectList? Projects { get; set; } 
    
   
    [Display(Name = "Atividades")]
    public IEnumerable<ulong> TaskIds { get; set; } = new List<ulong>();
  
    public MultiSelectList? Tasks { get; set; }

    public EditAssetModel()
    {
        Projects = new MultiSelectList(new List<SelectListItem>(), "Value", "Text", ProjectIds);
        Tasks = new MultiSelectList(new List<SelectListItem>(), "Value", "Text", TaskIds);
        Types = new SelectList(new List<SelectListItem>(), "Value", "Text", TypeId);

    }
}