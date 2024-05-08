namespace WildOasis.Application.Common.Dto.Cabin;

public record CabinDetailsDto(string Name,string Description, int MaxCapacity, int RegularPrice, 
    int Discount, string Image, string ResortName,string ResortDescription, string ResortAddress,uint ResortNumber,string Category, List<string>SubCategory);