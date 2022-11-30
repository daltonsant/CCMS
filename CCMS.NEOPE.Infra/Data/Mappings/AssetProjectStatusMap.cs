using CCMS.NEOPE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class AssetProjectStatusMap : IEntityTypeConfiguration<AssetProjectStatus>
{
    public void Configure(EntityTypeBuilder<AssetProjectStatus> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);
        

        builder.HasMany(e => e.Comments).WithOne(e => e.AssetStatus);
        builder.HasMany(e => e.Attachments).WithOne(e => e.AssetStatus);
        builder.HasMany(e => e.Logs).WithOne(e => e.AssetStatus);

        builder.HasMany(e => e.Assignees).WithMany(x => x.AssetStatusPerAccountable);
        builder.HasMany(e => e.Comments).WithOne(x => x.AssetStatus);
        builder.HasOne(e => e.Category).WithMany(x => x.StatusByCategory);
        builder.HasMany(e => e.Logs).WithOne(x => x.AssetStatus);

        builder.ToTable("AssetStatus");
    }
}