using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Domain.Enums;

public enum TaskPriority
{
    [Display(Name="Crítico")]
    Critical,
    [Display(Name="Urgente")]
    Urgent,
    [Display(Name="Normal")]
    Normal,
    [Display(Name="Baixo")]
    Low,
    [Display(Name="Baixíssimo")]
    Lowest
}