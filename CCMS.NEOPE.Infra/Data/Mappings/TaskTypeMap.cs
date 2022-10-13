using CCMS.NEOPE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class TaskTypeMap : IEntityTypeConfiguration<Domain.Entities.PendencyType>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.PendencyType> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);
        builder.Property(e => e.Name).IsRequired();
        builder.HasIndex(e => e.Name).IsUnique();
        
        builder.ToTable("TaskTypes");
        
        builder.HasData(
            new Type()
            {
                Id = 1,
                CreateDate = DateTime.Now,
                Name = "Informativo"
            },
            new Type()
            {
                Id = 2,
                CreateDate = DateTime.Now,
                Name = "Acompanhamento"
            },
            new Type()
            {
                Id = 3,
                CreateDate = DateTime.Now,
                Name = "Pendência não impeditiva"
            },
            new Type()
            {
                Id = 4,
                CreateDate = DateTime.Now,
                Name = "Pendência impeditiva"
            },
            new Type()
            {
                Id = 5,
                CreateDate = DateTime.Now,
                Name = "Não conformidade"
            }
        );
       
    }
}