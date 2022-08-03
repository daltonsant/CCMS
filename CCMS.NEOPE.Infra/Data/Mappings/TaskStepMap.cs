using CCMS.NEOPE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class TaskStepMap : IEntityTypeConfiguration<TaskStep>
{
    public void Configure(EntityTypeBuilder<TaskStep> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);

        builder.Property(e => e.Name).IsRequired();
        builder.HasIndex(e => e.Name).IsUnique();

        builder.ToTable("TaskSteps");
    }
}