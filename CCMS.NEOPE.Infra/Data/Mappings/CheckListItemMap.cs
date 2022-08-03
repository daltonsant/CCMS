using CCMS.NEOPE.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CCMS.NEOPE.Infra.Data.Mappings;

public class CheckListItemMap : IEntityTypeConfiguration<CheckListItem>
{
    public void Configure(EntityTypeBuilder<CheckListItem> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.CreateDate).IsRequired();
        builder.Property(e => e.UpdateDate);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(128);
        builder.Property(e => e.Value).IsRequired();
        
        builder.HasOne(e => e.Task).WithMany(e => e.CheckListItems);
        builder.ToTable("CheckListItems");
    }
}