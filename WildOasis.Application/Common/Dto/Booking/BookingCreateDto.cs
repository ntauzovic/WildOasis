namespace WildOasis.Application.Common.Dto.Booking;

public record BookingCreateDto(
    DateTime CreateAt,
    DateTime StartedAt,
    DateTime EndAt,
    int NumGuest,
    decimal CabinPrice,
    decimal ExtraPrice,
    decimal TotalPrice,
    bool HasBreakfast,
    bool IsPaid,
    string Observation,
    Guid CabinId,
    string UserId
);