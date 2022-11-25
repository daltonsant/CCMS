using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Domain.Enums;

public enum Status
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