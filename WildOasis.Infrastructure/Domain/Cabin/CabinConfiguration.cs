using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WildOasis.Domain.Enums;

namespace WildOasis.Infrastructure.Domain.Cabin;

public class CabinsConfiguration : IEntityTypeConfiguration<WildOasis.Domain.Entities.Cabin>
{
    public void Configure(EntityTypeBuilder<WildOasis.Domain.Entities.Cabin> builder)
    {
        builder.ToTable("Cabins");
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property<Guid>("ResortId");
        builder.HasIndex("ResortId");
        builder.HasOne(p => p.Resort).
            WithMany(r => r.Cabins).HasForeignKey("ResortId").IsRequired();
        builder.Property(b => b.Category).IsRequired().HasDefaultValue(Category.Bungalow)
            .HasConversion(p => p.Value, p => Category.FromValue(p));
            
        
    }
}