using CCMS.NEOPE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;
using Type = CCMS.NEOPE.Domain.Entities.Type;

public class TypeMap : IEntityTypeConfiguration<Domain.Entities.Type>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Type> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);
        builder.Property(e => e.Name).IsRequired();
        builder.HasIndex(e => e.Name).IsUnique();
        
        builder.ToTable("Types");
        
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