using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Enums;
using CCMS.NEOPE.Infra.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class TaskItemMap : IEntityTypeConfiguration<TaskItem>
{
    public void Configure(EntityTypeBuilder<TaskItem> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);

        builder.Property(e => e.Title).IsRequired().HasMaxLength(128);
        builder.Property(e => e.SapNoteNumber).HasMaxLength(128);
        builder.Property(e => e.Description).HasMaxLength(512);
        builder.Property(e => e.Priority);
        builder.Property(e => e.Status).IsRequired();
        builder.Property(e => e.StartDate);
        builder.Property(e => e.DueDate);
        builder.Property(e => e.PlannedDate);
        builder.Property(e => e.CompletedDate);
        builder.Property(e => e.Order);

        builder.HasOne(e => e.ParentTask).WithMany(e => e.ChildTasks);
        builder.HasOne(e => e.Step).WithMany().IsRequired();
        builder.HasOne(e => e.Project).WithMany(e => e.Tasks).IsRequired();
        builder.HasMany(e => e.Assets).WithMany(e => e.Tasks);
        builder.HasOne(e => e.Project).WithMany(e => e.Tasks);

        builder.HasMany(e => e.Labels).WithMany(e => e.Tasks);
        builder.HasMany(e => e.Assignees).WithMany(e => e.AssignedTasks);
        builder.HasOne(e => e.Reporter).WithMany(e => e.ReportedTasks);
 
        
        builder.HasMany(e => e.CheckListItems).WithOne(e => e.Task);

        builder.HasOne(e => e.Type)
            .WithMany(e =>e.TaskItemsByType).IsRequired()
            .HasForeignKey("TypeId");
        
        builder.HasOne(e => e.Category)
            .WithMany(e =>e.TaskItemsByCategory).IsRequired()
            .HasForeignKey("CategoryId");
        
        builder.ToTable("TaskItems");
    }
}
