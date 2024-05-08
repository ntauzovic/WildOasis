using MediatR;
using Microsoft.EntityFrameworkCore;
using WildOasis.Application.Cabin.Queries;
using WildOasis.Application.Common.Dto.Cabin;
using WildOasis.Application.Common.Dto.Resort;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Application.Common.Mappers;

namespace WildOasis.Application.Resort.Queries;

public class AllResortDetailsQuery : IRequest<IEnumerable<ResortDetailsDto?>>;

public class AllresortDetailsQueryHandler(IWildOasisDbContext context) : IRequestHandler<AllResortDetailsQuery, IEnumerable<ResortDetailsDto?>>
{
    public async Task<IEnumerable<ResortDetailsDto?>> Handle(AllResortDetailsQuery request, CancellationToken cancellationToken)
    {
        var results = await context.Resorts
          
            .ToListAsync(cancellationToken);

        var dtos = results.Select(x => x.ToDto());
        return dtos;
    }
}