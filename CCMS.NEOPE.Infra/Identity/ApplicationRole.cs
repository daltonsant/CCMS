using CCMS.NEOPE.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CCMS.NEOPE.Infra.Identity;

public class ApplicationRole : IdentityRole<string>, IRole
{
    public string Description { get; set; } = string.Empty;
}