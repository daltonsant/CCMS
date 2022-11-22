using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Infra.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class AccountableMap : IEntityTypeConfiguration<Accountable>
{
    public void Configure(EntityTypeBuilder<Accountable> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Code).HasMaxLength(128);
        builder.Property(e => e.DisplayName).HasMaxLength(128);
        builder.Property(e => e.Sector).HasMaxLength(128);

        builder.HasMany(e => e.ReportedTasks).WithOne(t => t.Reporter);
        builder.HasMany(e => e.AssignedTasks).WithMany(t => t.Assignees);

        builder.HasOne(e => e.User as ApplicationUser)
            .WithOne(e => e.Accountable);

        builder.ToTable("Accountables");
    }
}