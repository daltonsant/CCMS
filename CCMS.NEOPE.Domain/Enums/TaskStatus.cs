using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Domain.Enums;

public enum TaskStatus
{
    [Display(Name="Não iniciada")]
    NotStarted,
    [Display(Name="Em andamento")]
    InProgress,
    [Display(Name="Em revisão")]
    InReview,
    [Display(Name="Concluída")]
    Done
}