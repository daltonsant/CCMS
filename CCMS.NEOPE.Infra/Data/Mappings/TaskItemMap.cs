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
        builder.Property(e => e.Description).HasMaxLength(512);
        builder.Property(e => e.Priority).IsRequired();
        builder.Property(e => e.StartDate);
        builder.Property(e => e.DueDate);
        builder.Property(e => e.PlannedDate);
        builder.Property(e => e.CompletedDate);

        builder.HasOne(e => e.ParentTask).WithMany(e => e.ChildTasks);
        builder.HasOne(e => e.Step);
        builder.HasOne(e => e.Project).WithMany(e => e.Tasks);
        builder.HasMany(e => e.Assets).WithMany(e => e.Tasks);
        builder.HasOne(e => e.Project).WithMany(e => e.Tasks);

        builder.HasMany(e => e.Labels).WithMany(e => e.Tasks);
        builder.HasMany(e => e.Assignees as ICollection<ApplicationUser>).WithMany(e => e.AssignedTasks);
        builder.HasOne(e => e.Reporter as ApplicationUser).WithMany(e => e.ReportedTasks);
        builder.HasMany(e => e.Comments).WithOne(e => e.Task);
        builder.HasMany(e => e.Attachments).WithOne(e => e.Task);
        builder.HasMany(e => e.LinkedTasks).WithMany(e => e.Tasks);
        builder.HasMany(e => e.CheckListItems).WithOne(e => e.Task);
        
        builder.Property(e => e.Key).IsRequired().ValueGeneratedOnAdd();
        builder.HasIndex(e => e.Key).IsUnique();
        
        builder.ToTable("TaskItems");
    }
}
