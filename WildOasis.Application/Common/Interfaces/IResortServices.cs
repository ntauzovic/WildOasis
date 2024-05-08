using WildOasis.Application.Common.Dto.Resort;

namespace WildOasis.Application.Common.Interfaces;

public interface IResortServices
{
    Task<ResortDetailsDto> Create(ResortCreateDto resortCreateDto,CancellationToken cancellationToken);

}