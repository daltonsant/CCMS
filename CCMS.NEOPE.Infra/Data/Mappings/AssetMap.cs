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
        builder.HasIndex(e => e.Code);
        builder.Property(e => e.AttachmentsLink).HasMaxLength(384);

        builder.Property(e => e.Description).HasMaxLength(256);

        builder.HasOne(e => e.Type)
            .WithMany(e => e.AssetsByType);

        builder.HasOne(e => e.Status).WithOne(e => e.Asset)
            .HasForeignKey<AssetProjectStatus>("AssetId").OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Assets");
    }
}