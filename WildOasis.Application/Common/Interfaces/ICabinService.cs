using WildOasis.Application.Common.Dto.Cabin;

namespace WildOasis.Application.Common.Interfaces;

public interface ICabinService
{
    Task<CabinDetailsDto> CreateCabin(CabinCreateDto cabinCreateDto, CancellationToken cancellationToken);
    Task<CabinDetailsDto> UpdateCabin(CabinUpdateDto cabinUpdateDto, CancellationToken cancellationToken);
}