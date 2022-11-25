using CCMS.NEOPE.Domain.Entities;
using CCMS.NEOPE.Infra.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class CommentMap : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);

        builder.Property(e => e.Content).IsRequired().HasMaxLength(256);
        builder.HasOne(e => e.AssetStatus).WithMany(e => e.Comments);
        builder.HasOne<Accountable>(e => e.User).WithMany(e => e.CommentsPerAccountable);

        builder.ToTable("Comments");
    }
}
