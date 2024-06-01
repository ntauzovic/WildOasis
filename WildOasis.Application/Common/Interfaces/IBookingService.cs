using WildOasis.Application.Common.Dto.Booking;

namespace WildOasis.Application.Common.Interfaces;

public interface IBookingService
{
    Task<BookingDetailsDto> CreateReservation(BookingCreateDto reservationCreateDto, CancellationToken cancellationToken);

}