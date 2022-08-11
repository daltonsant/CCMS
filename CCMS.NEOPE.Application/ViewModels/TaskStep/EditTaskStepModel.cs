using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Application.ViewModels.TaskStep;

public class EditTaskStepModel
{
    [Display(Name = "Id")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(40, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Nome")]
    public string Name { get; set; } = string.Empty;
}