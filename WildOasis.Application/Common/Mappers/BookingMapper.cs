using Riok.Mapperly.Abstractions;
using WildOasis.Application.Common.Dto.Booking;
using WildOasis.Domain.Entities;

namespace WildOasis.Application.Common.Mappers;

[Mapper]
public static partial class BookingMapper
{
    public static Domain.Entities.Booking ToEntityBooking(this BookingCreateDto entity)
    {
        var booking= new Domain.Entities.Booking(entity.CreateAt,
            entity.StartedAt,
            entity.EndAt,
            entity.NumGuest,
            entity.CabinPrice,
            entity.ExtraPrice,
            entity.TotalPrice,
            entity.HasBreakfast,
            entity.IsPaid,
        entity.Observation);


        return booking;
        ;
    }
    
    public static  BookingDetailsDto ToDtoBooking(this Domain.Entities.Booking entity)
    {
        var dto = new BookingDetailsDto(entity.CreateAt,entity.StartedAt,entity.EndAt,entity.NumGuest,entity.CabinPrice,entity.ExtraPrice,
            entity.TotalPrice,entity.HasBreakfast,entity.IsPaid,entity.Observation,entity.Cabin.Name,entity.User.Email
        );
        return dto;
    }


}