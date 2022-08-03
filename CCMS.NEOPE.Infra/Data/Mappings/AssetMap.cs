using CCMS.NEOPE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class AssetMap : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);
        builder.Property(e => e.Code).IsRequired().HasMaxLength(64);
        builder.HasIndex(e => e.Code).IsUnique();

        builder.Property(e => e.Description).HasMaxLength(256);

        builder.HasOne(e => e.Type)
            .WithMany(e => e.AssetsByType);

        builder.ToTable("Assets");
    }
}