using CCMS.NEOPE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class StepMap : IEntityTypeConfiguration<Step>
{
    public void Configure(EntityTypeBuilder<Step> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);

        builder.Property(e => e.Name).IsRequired();
        builder.HasIndex(e => e.Name).IsUnique();
        
        builder.ToTable("Steps");

        builder.HasData(
            new Step()
            {
                Id = 1,
                CreateDate = DateTime.Now,
                Name = "Planejamento"
            },
            new Step()
            {
                Id = 2,
                CreateDate = DateTime.Now,
                Name = "Inspeção"
            },
            new Step()
            {
                Id = 3,
                CreateDate = DateTime.Now,
                Name = "TAC Equip. Interlig."
            },
            new Step()
            {
                Id = 4,
                CreateDate = DateTime.Now,
                Name = "TAF SPCS"
            },
            new Step()
            {
                Id = 5,
                CreateDate = DateTime.Now,
                Name = "TAC SPCS"
            },
            new Step()
            {
                Id = 6,
                CreateDate = DateTime.Now,
                Name = "Energização"
            },
            new Step()
            {
                Id = 7,
                CreateDate = DateTime.Now,
                Name = "SAP"
            }
        );
    }
}