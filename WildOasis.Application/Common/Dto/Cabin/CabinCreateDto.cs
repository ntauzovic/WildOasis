using WildOasis.Domain.Enums;

namespace WildOasis.Application.Common.Dto.Cabin;

public record CabinCreateDto(Guid ResortId, string Name,string Description,int MaxCapacity, int RegularPrice, 
    int Discount, string Image, int Category)
{
    
}