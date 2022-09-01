using System.ComponentModel.DataAnnotations;
using CCMS.NEOPE.Domain.Enums;

namespace CCMS.NEOPE.Application.ViewModels.LinkedTasks;

public class AddLinkedTaskModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public ulong TargetTaskId { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Atividade")]
    public string TaskTitle { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Tipo de Relacionamento")]
    public LinkType Type { get; set; }
    
}