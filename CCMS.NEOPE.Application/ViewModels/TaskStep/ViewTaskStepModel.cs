using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Application.ViewModels.TaskStep;

public class ViewTaskStepModel
{
    [Display(Name = "Id")]
    public int Id { get; set; }
    
    [Display(Name = "Nome")]
    public string Name { get; set; } = string.Empty;
}