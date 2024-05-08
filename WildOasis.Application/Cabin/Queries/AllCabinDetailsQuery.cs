using MediatR;
using Microsoft.EntityFrameworkCore;
using WildOasis.Application.Common.Dto.Cabin;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Application.Common.Mappers;

namespace WildOasis.Application.Cabin.Queries;

public record AllCabinDetailsQuery : IRequest<IEnumerable<CabinDetailsDto?>>;

public class AllCabinDetailsQueryHandler(IWildOasisDbContext context) : IRequestHandler<AllCabinDetailsQuery, IEnumerable<CabinDetailsDto?>>
{
    public async Task<IEnumerable<CabinDetailsDto?>> Handle(AllCabinDetailsQuery request, CancellationToken cancellationToken)
    {
        var results = await context.Cabins
            .Include(x => x.Resort)
            .ToListAsync(cancellationToken);

        var dtos = results.Select(x => x.ToDto());
        return dtos;
    }
}