using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Application.ViewModels.TaskStep;

public class AddTaskStepModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(40, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Nome")]
    public string Name { get; set; } = string.Empty;
    
}