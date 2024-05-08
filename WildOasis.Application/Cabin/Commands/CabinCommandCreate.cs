using MediatR;
using Microsoft.EntityFrameworkCore;
using WildOasis.Application.Common.Dto.Cabin;
using WildOasis.Application.Common.Exceptions;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Application.Common.Mappers;

namespace WildOasis.Application.Cabin.Commands;

public record CabinCommandCreate(CabinCreateDto cabin) : IRequest<CabinDetailsDto?>;

public class CabinCommandCreateHandler(ICabinService cabinService)
    : IRequestHandler<CabinCommandCreate, CabinDetailsDto?>
{
    public async Task<CabinDetailsDto?> Handle(CabinCommandCreate request, CancellationToken cancellationToken) =>
        await cabinService.CreateCabin(request.cabin, cancellationToken);
}