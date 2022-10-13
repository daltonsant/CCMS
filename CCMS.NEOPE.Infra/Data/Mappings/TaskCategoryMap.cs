using CCMS.NEOPE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class TaskCategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);
        builder.Property(e => e.Name).IsRequired();
        builder.HasIndex(e => e.Name).IsUnique();
        
        builder.ToTable("TaskCategories");
        
        builder.HasData(
            new Category()
            {
                Id = 1,
                CreateDate = DateTime.Now,
                Name = "Civil"
            },
            new Category()
            {
                Id = 2,
                CreateDate = DateTime.Now,
                Name = "Eletromecânico"
            },
            new Category()
            {
                Id = 3,
                CreateDate = DateTime.Now,
                Name = "Aterramento"
            },
            new Category()
            {
                Id = 4,
                CreateDate = DateTime.Now,
                Name = "Projeto"
            },
            new Category()
            {
                Id = 5,
                CreateDate = DateTime.Now,
                Name = "Painéis"
            } ,
            new Category()
            {
                Id = 6,
                CreateDate = DateTime.Now,
                Name = "Equipamentos"
            } ,
            new Category()
            {
                Id = 7,
                CreateDate = DateTime.Now,
                Name = "Interligações"
            } ,
            new Category()
            {
                Id = 8,
                CreateDate = DateTime.Now,
                Name = "SPCS"
            }
        );
    }
    
}