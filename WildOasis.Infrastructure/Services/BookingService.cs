using MediatR;
using Microsoft.EntityFrameworkCore;
using WildOasis.Application.Common.Dto.Booking;
using WildOasis.Application.Common.Exceptions;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Infrastructure.Contexts;
using WildOasis.Application.Common.Mappers;
using WildOasis.Domain.Events;
using NotFoundException = WildOasis.Application.Common.Exceptions.NotFoundException;

namespace WildOasis.Infrastructure.Services;

public class BookingService(WildOasisDbContext dbContext, IMediator mediator, IEmailService emailService) : IBookingService
{
    public async Task<BookingDetailsDto> CreateReservation(BookingCreateDto reservationCreateDto, CancellationToken cancellationToken)
    {
        var cabin = await dbContext.Cabins.Where(x => x.Id == reservationCreateDto.CabinId)
            .FirstOrDefaultAsync(cancellationToken);
        var user = await dbContext.Users.Where(x => x.Id == reservationCreateDto.UserId)
            .FirstOrDefaultAsync(cancellationToken);

        if (cabin == null)
        {
            throw new NotFoundException("Cabin is not found");
        }
        if (user == null)
        {
            throw new NotFoundException("User is not found");
        }

        var existingReservation = await dbContext.Bookings
            .AnyAsync(b => b.Cabin.Id == reservationCreateDto.CabinId
                           && b.StartedAt < reservationCreateDto.EndAt
                           && b.EndAt > reservationCreateDto.StartedAt
                           && b.CreateAt > reservationCreateDto.StartedAt
                           && b.CreateAt > reservationCreateDto.EndAt

                , 
                cancellationToken);
        
        if (existingReservation)
        {
            throw new ExistReservation("Cabin is already reserved for this date.");
        }
        var booking = reservationCreateDto.ToEntityBooking().AddCabin(cabin).AddUser(user);

        dbContext.Bookings.Add(booking);
        await dbContext.SaveChangesAsync(cancellationToken);
        //Console.WriteLine($"CabinId: {reservationCreateDto.CabinId}, StartedAt: {reservationCreateDto.StartedAt}, EndAt: {reservationCreateDto.EndAt}");

        //await mediator.Publish(new CabinReservationDomainEvents(reservationCreateDto.CabinId, reservationCreateDto.StartedAt, reservationCreateDto.EndAt), cancellationToken);


        var subject = "Reservation Confirmation";
        

        var body = $"Dear {user.UserName},Thank you for your reservation at our resort. Your booking details are as follows:" +
                   $"<ul>" +
                   $"<li>Cabin: {cabin.Name}</li>" +
                   $"<li>Check-in: {booking.StartedAt}</li>" +
                   $"<li>Check-out: {booking.EndAt}</li>" +
                   $"<li>Total Price: {booking.TotalPrice:C}</li>" +
                   $"</ul><br/>Looking forward to welcoming you!<br/><br/>Best regards,<br/>Wild Oasis Team";

        Console.Write(body);

        if (user.Email != null) await emailService.SendEmailAsync(user.Email, subject, body);

        return booking.ToDtoBooking();
        
    }
}