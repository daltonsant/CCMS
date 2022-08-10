using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CCMS.NEOPE.Application.ViewModels.TaskType;

public class AddTaskTypeModel
{

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(64, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Nome")]
    public string Name { get; set; } = string.Empty;
}