using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Domain.Enums;

public enum TaskPriority
{
    [Display(Name="Emergencial")]
    Critical,
    [Display(Name="Urgente")]
    Urgent,
    [Display(Name="Importante")]
    Important,
    [Display(Name="Necessário")]
    Normal,
    [Display(Name="Esperado")]
    Low,
    [Display(Name="Desejável")]
    Lowest
}