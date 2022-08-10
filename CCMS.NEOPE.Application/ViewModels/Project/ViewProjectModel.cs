using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Application.ViewModels.Project;

public class ViewProjectModel
{
    [Display(Name = "Id")]
    public ulong Id { get; set; }
    [Display(Name = "Chave")]
    public string Code { get; set; }
    [Display(Name = "Nome")]
    public string Name { get; set; }
}