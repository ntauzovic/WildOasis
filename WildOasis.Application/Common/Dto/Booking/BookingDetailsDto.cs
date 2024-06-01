namespace WildOasis.Application.Common.Dto.Booking;

public record BookingDetailsDto(DateTime CreateAt,
    DateTime StartedAt,
    DateTime EndAt,
    int NumGuest,
    decimal CabinPrice,
    decimal ExtraPrice,
    decimal TotalPrice,
    bool HasBreakfast,
    bool IsPaid,
    string Observation,
    string CabinName,
    string userEmial);