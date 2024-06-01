using Microsoft.EntityFrameworkCore;
using WildOasis.Domain.Entities;

namespace WildOasis.Application.Common.Interfaces;

public interface IWildOasisDbContext
{
    public DbSet<Domain.Entities.Cabin> Cabins { get; }
    public DbSet<Domain.Entities.Resort> Resorts { get; }
    public DbSet<Domain.Entities.Booking> Bookings { get; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}