using MediatR;
using Microsoft.EntityFrameworkCore;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Domain.Events;

namespace WildOasis.Application.Booking.Handler;

public class CabinReservedDomainEventHandler(IWildOasisDbContext _dbContext, IEmailService emailService) : INotificationHandler<CabinReservationDomainEvents>
{
  

    public async Task Handle(CabinReservationDomainEvents notification, CancellationToken cancellationToken)
    {
        var cabin = await _dbContext.Cabins.FindAsync(notification.CabinId);
        if (cabin != null)
        {
            var reservation = await _dbContext.Bookings
                .Where(b => b.Cabin.Id == notification.CabinId && b.StartedAt == notification.ReservationCreate && b.EndAt == notification.ReservationEnd)
                .FirstOrDefaultAsync(cancellationToken);

            if (reservation != null)
            {
                var user = await _dbContext.Bookings.FindAsync(reservation.User.Id);
                
                if (user != null)
                {
                    var emailMessage = $"Dear {user.User.Email},Your reservation for cabin {cabin.Name} from {notification.ReservationCreate} to {notification.ReservationEnd} has been confirmed.";
                    await emailService.SendEmailAsync(user.User.Email, "Cabin Reservation Confirmed", emailMessage);
                }
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}