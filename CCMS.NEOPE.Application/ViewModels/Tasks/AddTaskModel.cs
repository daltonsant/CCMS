using System.ComponentModel.DataAnnotations;
using CCMS.NEOPE.Application.ViewModels.LinkedTasks;
using CCMS.NEOPE.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskStatus = CCMS.NEOPE.Domain.Enums.TaskStatus;

namespace CCMS.NEOPE.Application.ViewModels.Tasks;

public class AddTaskModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(64, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Título")]
    public string? Title { get; set; } = string.Empty;
    
    [StringLength(256, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Descrição")]
    public string? Description { get; set; } = string.Empty;
    
    [StringLength(64, ErrorMessage = "Use menos caracteres")]
    [Display(Name = "Numero da nota no SAP")]
    public string? SapNoteNumber { get; set; } = string.Empty;
    
    [Display(Name = "Tipo")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public ulong? TypeId { get; set; }
    public SelectList? Types { get; set; }
    
    [Display(Name = "Categoria")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int? SelectedCategory { get; set; }
    public SelectList? Categories { get; set; }
    
    [Display(Name = "Projeto")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public ulong? ProjectId { get; set; }
    public SelectList? Projects { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Etapa")]
    public int? StepId { get; set; }
    public SelectList? Steps { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Display(Name = "Status")]
    public TaskStatus SelectedStatus { get; set; }
    public SelectList? Status { get; set; }

    [Display(Name = "Prioridade")]
    public TaskPriority? SelectedPriority { get; set; }
    public SelectList? Priorities { get; set; }

    [Display(Name = "Data Início")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? StartDate { get; set; }
    
    [Display(Name = "Prazo")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? DueDate { get; set; }
    
    [Display(Name = "Criador")]
    public string? ReporterId { get; set; }
    public SelectList? Users { get; set; }

    [Display(Name = "Responsáveis")] 
    public ICollection<string> AssigneeIds { get; set; } = new List<string>();
    public MultiSelectList Assignees { get; set; }
    
    [Display(Name = "Atividade pai")]
    public ulong? ParentTaskId { get; set; }
    public SelectList? Tasks { get; set; } 
    
    [Display(Name = "É uma sub-atividade?")]
    public bool? IsSubTask { get; set; }
    
    public List<ViewLinkedTaskModel> LinkedTasks { get; set; }

    public AddTaskModel()
    {
        Tasks = new SelectList(new List<SelectListItem>(),"Value","Text",ParentTaskId);
        Priorities = new SelectList(new List<SelectListItem>(),"Value","Text",SelectedPriority);
        Users = new SelectList(new List<SelectListItem>(), "Value", "Text", ReporterId);
        Assignees = new MultiSelectList(new List<SelectListItem>(), "Value", "Text", AssigneeIds);
        Steps = new SelectList(new List<SelectListItem>(), "", "", StepId);
        Status = new SelectList(new List<SelectListItem>(), "", "", SelectedStatus);
        Projects = new SelectList(new List<SelectListItem>(),"Value","Text",ProjectId);
        Types = new SelectList(new List<SelectListItem>(), "Value", "Text", TypeId);
        Categories = new SelectList(new List<SelectListItem>(), "Value", "Text", SelectedCategory);
        LinkedTasks = new List<ViewLinkedTaskModel>();
    }
}