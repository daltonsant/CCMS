using CCMS.NEOPE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class AttachmentMap : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);
        builder.Property(e => e.Size).IsRequired();
        builder.Property(e => e.Path).IsRequired();
        builder.Property(e => e.Name).IsRequired();
        builder.HasOne(e => e.AssetStatus).WithMany(a => a.Attachments);

        builder.ToTable("Attachments");
    }
}