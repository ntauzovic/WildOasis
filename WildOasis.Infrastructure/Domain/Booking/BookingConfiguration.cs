using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WildOasis.Infrastructure.Domain.Booking;

public class BookingConfiguration : IEntityTypeConfiguration<WildOasis.Domain.Entities.Booking>
{
    public void Configure(EntityTypeBuilder<WildOasis.Domain.Entities.Booking> builder)
    {
        builder.ToTable("Booking");
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property<Guid>("CabinId");
        builder.HasIndex("CabinId");
        builder.HasOne(b => b.Cabin)
            .WithMany(c => c.Bookings)  // Specifikujte kolekciju Bookings na strani Cabin entiteta
            .HasForeignKey("CabinId")
            .IsRequired();
        
        builder.Property<string>("UserId");
        builder.HasIndex("UserId");
        builder.HasOne(b => b.User)
            .WithMany(u => u.Bookings)  // Specifikujte kolekciju Bookings na strani User entiteta
            .HasForeignKey("UserId")
            .IsRequired();
    }
}