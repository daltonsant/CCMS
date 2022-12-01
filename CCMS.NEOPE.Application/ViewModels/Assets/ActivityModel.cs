using System.ComponentModel.DataAnnotations;
using CCMS.NEOPE.Application.ViewModels.LinkedTasks;
using CCMS.NEOPE.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Status = CCMS.NEOPE.Domain.Enums.Status;

namespace CCMS.NEOPE.Application.ViewModels.Assets;

public class ActivityModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(64, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Título")]
    public string? Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(64, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Comissionamento")]
    public string? Project { get; set; } = string.Empty;

    public ulong AssetId { get; set; }
    
    [Display(Name = "Categoria")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int? SelectedCategory { get; set; }
    public SelectList? Categories { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Etapa")]
    public int? StepId { get; set; }
    public SelectList? Steps { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Status")]
    public Status SelectedStatus { get; set; }
    public SelectList? Status { get; set; }

    [Display(Name = "Data Início")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? StartDate { get; set; }
    
    [Display(Name = "Prazo")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? DueDate { get; set; }

    [Display(Name = "Responsáveis")] 
    public ICollection<ulong> AssigneeIds { get; set; } = new List<ulong>();
    public MultiSelectList Assignees { get; set; }
    
    public Dictionary<string, string> Errors = new Dictionary<string, string>();
    
    public string? AttachmentsLink { get; set; }
    
    public ActivityModel()
    {
        Assignees = new MultiSelectList(new List<SelectListItem>(), "Value", "Text", AssigneeIds);
        Steps = new SelectList(new List<SelectListItem>(), "", "", StepId);
        Status = new SelectList(new List<SelectListItem>(), "", "", SelectedStatus);
        Categories = new SelectList(new List<SelectListItem>(), "Value", "Text", SelectedCategory);
    }
}