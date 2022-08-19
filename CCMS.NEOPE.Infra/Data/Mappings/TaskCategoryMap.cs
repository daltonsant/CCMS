using CCMS.NEOPE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class TaskCategoryMap : IEntityTypeConfiguration<TaskCategory>
{
    public void Configure(EntityTypeBuilder<TaskCategory> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);
        builder.Property(e => e.Name).IsRequired();
        builder.HasIndex(e => e.Name).IsUnique();
        
        builder.ToTable("TaskCategories");
        
        builder.HasData(
            new TaskCategory()
            {
                Id = 1,
                CreateDate = DateTime.Now,
                Name = "Civil"
            },
            new TaskCategory()
            {
                Id = 2,
                CreateDate = DateTime.Now,
                Name = "Eletromecânico"
            },
            new TaskCategory()
            {
                Id = 3,
                CreateDate = DateTime.Now,
                Name = "Aterramento"
            },
            new TaskCategory()
            {
                Id = 4,
                CreateDate = DateTime.Now,
                Name = "Projeto"
            },
            new TaskCategory()
            {
                Id = 5,
                CreateDate = DateTime.Now,
                Name = "Painéis"
            } ,
            new TaskCategory()
            {
                Id = 6,
                CreateDate = DateTime.Now,
                Name = "Equipamentos"
            } ,
            new TaskCategory()
            {
                Id = 7,
                CreateDate = DateTime.Now,
                Name = "Interligações"
            } ,
            new TaskCategory()
            {
                Id = 8,
                CreateDate = DateTime.Now,
                Name = "SPCS"
            }
        );
    }
    
}