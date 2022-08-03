using CCMS.NEOPE.Infra.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class ApplicationRoleMap : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Description).IsRequired().HasMaxLength(64);

        builder.HasData(
            new ApplicationRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Description = "Administrador do sistema"
            },
            new ApplicationRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "USER",
                Description = "Usuário comum do sistema"
            });
        
        builder.ToTable("ApplicationRoles");
    }
}