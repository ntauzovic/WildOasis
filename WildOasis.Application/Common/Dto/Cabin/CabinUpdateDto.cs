namespace WildOasis.Application.Common.Dto.Cabin;

public record CabinUpdateDto (Guid id, string Name,string Description, int MaxCapacity, int RegularPrice, 
    int Discount, string Image, Guid ResortId );
