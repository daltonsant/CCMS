using System.ComponentModel.DataAnnotations;
using CCMS.NEOPE.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CCMS.NEOPE.Application.ViewModels.LinkedTasks;

public class EditLinkedTaskModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public ulong Id { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public ulong FromTaskId { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public ulong TargetTaskId { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Atividade")]
    public string TaskTitle { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Tipo de Relacionamento")]
    public string Type { get; set; }
    public SelectList Types { get; set; }
}