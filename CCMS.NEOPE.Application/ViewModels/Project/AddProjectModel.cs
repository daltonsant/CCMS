using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Application.ViewModels.Project;

public class AddProjectModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(32, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Nome")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(32, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Num. projeto")]
    public string Code { get; set; } = string.Empty;
}