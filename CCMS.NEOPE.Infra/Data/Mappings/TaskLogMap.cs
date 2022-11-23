using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Infra.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class TaskLogMap : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);

        builder.Property(e => e.Text).IsRequired().HasMaxLength(256);

        builder.HasOne(e => e.AssetStatus).WithMany(e => e.Logs);

        builder.ToTable("Logs");
    }
}
