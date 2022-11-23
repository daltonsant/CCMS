using CCMS.NEOPE.Infra.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Code).IsRequired().HasMaxLength(12);
        builder.HasIndex(e => e.Code).IsUnique();
        builder.Property(e => e.Photo);
        builder.Property(e => e.IsActive).IsRequired();
        builder.Property(e => e.IsFirstAccess).IsRequired();
        builder.Property(e => e.FirstName).IsRequired().HasMaxLength(32);
        builder.Property(e => e.LastName).IsRequired().HasMaxLength(64);

        builder.HasMany(e => e.Comments).WithOne(c => c.User as ApplicationUser);
        
        builder.HasOne(e => e.Accountable)
            .WithOne(e => e.User as ApplicationUser)
            .HasForeignKey<ApplicationUser>(x => x.AccountableId);

        builder.ToTable("ApplicationUsers");
    }
}
