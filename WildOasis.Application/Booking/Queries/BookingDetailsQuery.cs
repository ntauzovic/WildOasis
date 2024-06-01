using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WildOasis.Application.Common.Dto.Booking;
using WildOasis.Application.Common.Exceptions;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Application.Common.Mappers;

namespace WildOasis.Application.Booking.Queries;

public record BookingDetailsQuery(string id) : IRequest<BookingDetailsDto?>;

public class BookingDetailsQueryHandler(IWildOasisDbContext context)
    : IRequestHandler<BookingDetailsQuery, BookingDetailsDto?>
{
    public async Task<BookingDetailsDto?> Handle(BookingDetailsQuery request, CancellationToken cancellationToken)
    {
        var bookingId = Guid.Parse(request.id);
        var booking = await context.Bookings
            .Include(b => b.Cabin)
            .Include(b => b.User)
            .FirstOrDefaultAsync(b => b.Id == bookingId, cancellationToken);

        if (booking == null)
        {
            throw new NotFoundException("Booking not found", new { request.id });
        }

        return booking.ToDtoBooking();
    
    }
}
