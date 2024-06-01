using MediatR;

namespace WildOasis.Domain.Events;

public class CabinReservationDomainEvents : INotification
{
    public Guid CabinId { get; }
    public DateTime ReservationCreate { get; }
    public DateTime ReservationEnd { get; }

    public CabinReservationDomainEvents(Guid cabinId, DateTime reservationCreate,DateTime reservationEnd)
    {
        CabinId = cabinId;
        ReservationCreate = reservationCreate;
        ReservationEnd = reservationEnd;

    }
    

}