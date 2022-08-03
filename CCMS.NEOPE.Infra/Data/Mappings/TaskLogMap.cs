using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Infra.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class TaskLogMap : IEntityTypeConfiguration<TaskLog>
{
    public void Configure(EntityTypeBuilder<TaskLog> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);

        builder.Property(e => e.Log).IsRequired().HasMaxLength(128);
        builder.HasOne(e => e.User as ApplicationUser)
            .WithMany(e => e.Logs);

        builder.HasOne(e => e.Task).WithMany(e => e.Logs);

        builder.ToTable("TaskLogs");
    }
}
