using CCMS.NEOPE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class LinkedTasksMap : IEntityTypeConfiguration<LinkedTasks>
{
    public void Configure(EntityTypeBuilder<LinkedTasks> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);
        builder.Property(e => e.Type).IsRequired();

        builder.HasOne(e => e.SubjectTask)
            .WithMany(e => e.LinkedSubjectTasks)
            .HasForeignKey(e => e.SubjectTaskId);

        builder.HasOne(e => e.ObjectTask)
            .WithMany(e => e.LinkedObjectTasks)
            .HasForeignKey(e => e.ObjectTaskId);
        
        builder.ToTable("LinkedTasks");
    }
}
