using MediatR;
using Microsoft.EntityFrameworkCore;
using WildOasis.Application.Common.Dto.Resort;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Application.Common.Mappers;

namespace WildOasis.Application.Resort.Queries;

public record ResortDetailQuery(string Id) : IRequest<ResortDetailsDto?>;

public class ResortDetailQueryHandler(IWildOasisDbContext context) : IRequestHandler<ResortDetailQuery, ResortDetailsDto?>
{
    public async Task<ResortDetailsDto?> Handle(ResortDetailQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Resorts
            .Where(x => x.Id == Guid.Parse(request.Id))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        
        var dto = result?.ToDto();
        return dto;
    }
}