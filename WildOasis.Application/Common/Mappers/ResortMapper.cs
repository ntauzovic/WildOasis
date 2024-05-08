using Riok.Mapperly.Abstractions;
using WildOasis.Application.Common.Dto.Resort;

namespace WildOasis.Application.Common.Mappers;

[Mapper]
public static partial class ResortMapper
{
    public static partial ResortDetailsDto ToDto(this Domain.Entities.Resort entity);

    public static partial Domain.Entities.Resort ToEntityResortUpdate(this ResortUpdateDto entity);

  

    public static partial Domain.Entities.Resort ToEntityResort(this ResortCreateDto entity);
    
    
    
}