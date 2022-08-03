
using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Domain.Enums;
using CCMS.NEOPE.Infra.Data.Mappings;
using CCMS.NEOPE.Infra.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CCMS.NEOPE.Infra.Data.Context;

public class ApplicationContext : IdentityDbContext<ApplicationUser,ApplicationRole, string>
{
    public override DbSet<ApplicationUser> Users { get; set; }
    public override DbSet<ApplicationRole> Roles { get; set; }
    
    public DbSet<LinkedTasks> LinkedTasks { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<Asset> Assets { get; set; }
    
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Label> Labels { get; set; }

    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskLog> TaskLogs { get; set; }
    public DbSet<TaskStep> TaskSteps { get; set; }

    public ApplicationContext (DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new CommentMap());
        builder.ApplyConfiguration(new LabelMap());

        builder.ApplyConfiguration(new TaskLogMap());

        builder.ApplyConfiguration(new AssetMap());
        builder.ApplyConfiguration(new ApplicationRoleMap());
        builder.ApplyConfiguration(new ApplicationUserMap());
        builder.ApplyConfiguration(new AttachmentMap());
        builder.ApplyConfiguration(new ProjectMap());
        builder.ApplyConfiguration(new TaskStepMap());
        builder.ApplyConfiguration(new TaskItemMap());
        builder.ApplyConfiguration(new LinkedTasksMap());

    }
}