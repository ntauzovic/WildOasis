using MediatR;
using WildOasis.Application.Common.Dto.Booking;
using WildOasis.Application.Common.Interfaces;

namespace WildOasis.Application.Booking.Commands;

public record BookingCommmandCreate(BookingCreateDto bookingCreateDto) : IRequest<BookingDetailsDto>;


public class BookingCommandCreateHandler(IBookingService bookingService)
    : IRequestHandler<BookingCommmandCreate, BookingDetailsDto?>
{
    public async Task<BookingDetailsDto?> Handle(BookingCommmandCreate request, CancellationToken cancellationToken) =>
        await bookingService.CreateReservation(request.bookingCreateDto, cancellationToken);
}
