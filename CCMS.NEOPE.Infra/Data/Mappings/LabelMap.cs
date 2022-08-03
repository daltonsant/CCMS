using CCMS.NEOPE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class LabelMap : IEntityTypeConfiguration<Label>
{
    public void Configure(EntityTypeBuilder<Label> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);

        builder.Property(e => e.Title).IsRequired().HasMaxLength(16);
        builder.Property(e => e.Color);
        builder.HasMany(e => e.Tasks).WithMany(e => e.Labels);

        builder.ToTable("Labels");
    }
}