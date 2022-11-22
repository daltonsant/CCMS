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

        builder.HasData(
            new TaskStep()
            {
                Id = 1,
                CreateDate = DateTime.Now,
                Name = "Planejamento"
            },
            new TaskStep()
            {
                Id = 2,
                CreateDate = DateTime.Now,
                Name = "TAC Equip. Interlig."
            },
            new TaskStep()
            {
                Id = 3,
                CreateDate = DateTime.Now,
                Name = "TAF SPCS"
            },
            new TaskStep()
            {
                Id = 4,
                CreateDate = DateTime.Now,
                Name = "TAC SPCS"
            },
            new TaskStep()
            {
                Id = 5,
                CreateDate = DateTime.Now,
                Name = "Energização"
            },
            new TaskStep()
            {
                Id = 6,
                CreateDate = DateTime.Now,
                Name = "SAP"
            }
        );
    }
}