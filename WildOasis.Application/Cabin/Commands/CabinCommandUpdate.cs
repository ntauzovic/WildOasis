using MediatR;
using Microsoft.EntityFrameworkCore;
using WildOasis.Application.Common.Dto.Cabin;
using WildOasis.Application.Common.Exceptions;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Application.Common.Mappers;

namespace WildOasis.Application.Cabin.Commands;

public record CabinCommandUpdate(CabinUpdateDto cabin) : IRequest<CabinDetailsDto?>;

public class CabinCommandUpdateHandler(ICabinService cabinService) : IRequestHandler<CabinCommandUpdate, CabinDetailsDto?>
{
    public async Task<CabinDetailsDto?> Handle(CabinCommandUpdate request, CancellationToken cancellationToken) =>
        await cabinService.UpdateCabin(request.cabin, cancellationToken);
}