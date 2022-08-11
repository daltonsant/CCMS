using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Application.ViewModels.Project;

public class ViewProjectModel
{
    [Display(Name = "Id")]
    public ulong Id { get; set; }
    [Display(Name = "Num. projeto")]
    public string Code { get; set; }
    [Display(Name = "Nome")]
    public string Name { get; set; }
}