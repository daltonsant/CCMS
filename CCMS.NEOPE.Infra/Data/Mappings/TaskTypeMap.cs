using CCMS.NEOPE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class TaskTypeMap : IEntityTypeConfiguration<TaskType>
{
    public void Configure(EntityTypeBuilder<TaskType> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);
        builder.Property(e => e.Name).IsRequired();
        builder.HasIndex(e => e.Name).IsUnique();
        
        builder.ToTable("TaskTypes");
        
        builder.HasData(
            new TaskType()
            {
                Id = 1,
                CreateDate = DateTime.Now,
                Name = "Informativo"
            },
            new TaskType()
            {
                Id = 2,
                CreateDate = DateTime.Now,
                Name = "Acompanhamento"
            },
            new TaskType()
            {
                Id = 3,
                CreateDate = DateTime.Now,
                Name = "Pendência não impeditiva"
            },
            new TaskType()
            {
                Id = 4,
                CreateDate = DateTime.Now,
                Name = "Pendência impeditiva"
            },
            new TaskType()
            {
                Id = 5,
                CreateDate = DateTime.Now,
                Name = "Não conformidade"
            }
        );
       
    }
}