using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WildOasis.Infrastructure.Domain.Resort;

public class ResortConfiguration : IEntityTypeConfiguration<WildOasis.Domain.Entities.Resort>
{
    public void Configure(EntityTypeBuilder<WildOasis.Domain.Entities.Resort> builder)
    {
        builder.ToTable("Resort");
        builder.Property(r => r.Id).ValueGeneratedNever();
    }
}