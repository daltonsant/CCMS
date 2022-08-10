using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Application.ViewModels.TaskType;

public class ViewTaskTypeModel
{
    [Display(Name = "Id")]
    public ulong Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(64, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Nome")]
    public string Name { get; set; } = string.Empty;
}