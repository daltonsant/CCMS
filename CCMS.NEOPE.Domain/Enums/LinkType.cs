using System.ComponentModel.DataAnnotations;

namespace CCMS.NEOPE.Domain.Enums;

public enum LinkType
{
    [Display(Name="Bloqueia")]
    Blocks,
    [Display(Name="Clona")]
    Clones,
    [Display(Name="Duplica")]
    Duplicates,
    [Display(Name="Causa")]
    Causes,
    [Display(Name="Relacionada a")]
    RelatesTo
}