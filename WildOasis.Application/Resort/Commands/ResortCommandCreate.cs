using MediatR;
using WildOasis.Application.Common.Dto.Resort;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Application.Common.Mappers;

namespace WildOasis.Application.Resort.Commands;

public record ResortCommandCreate(ResortCreateDto resort) : IRequest<ResortDetailsDto?>;

public class CreateCommandResortHandler(IResortServices resortServices) : IRequestHandler<ResortCommandCreate, ResortDetailsDto?>
{

    public async Task<ResortDetailsDto?> Handle(ResortCommandCreate request, CancellationToken cancellationToken) =>
        await resortServices.Create(request.resort, cancellationToken);
}