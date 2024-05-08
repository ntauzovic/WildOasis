using MediatR;
using Microsoft.EntityFrameworkCore;
using WildOasis.Application.Common.Dto.Cabin;
using WildOasis.Application.Common.Exceptions;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Application.Common.Mappers;
using WildOasis.Domain.Common.Extensions;

namespace WildOasis.Application.Cabin.Queries;

public record CabinDetailsQuery(string Id) : IRequest<CabinDetailsDto?>;

public class CabinDetailsQueryHandler(IWildOasisDbContext context) : IRequestHandler<CabinDetailsQuery, CabinDetailsDto?>
{
    public  async Task<CabinDetailsDto?> Handle(CabinDetailsQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Cabins.Include(x=>x.Resort)
            .Where(x => x.Id == Guid.Parse(request.Id))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        
        
        if (result == null)
        {
            throw new NotFoundException("Product not found", new { request.Id });
        }
        var dto = result?.ToDto();
        //var serializeDto = dto.Serialaze(SerializerExtensions.DefaultOptions);
        //var serializeDto2 = dto.Serialaze(SerializerExtensions.SettingsWebOptions);
        //var serializeDto3 = dto.Serialaze(SerializerExtensions.SettingsGeneralOptions);


        return dto;
    }
}