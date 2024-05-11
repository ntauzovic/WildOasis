using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WildOasis.Application.Common.Dto.Cabin;
using WildOasis.Application.Common.Exceptions;
using WildOasis.Application.Common.Extensions;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Application.Common.Mappers;
using WildOasis.Application.Configuration;
using WildOasis.Domain.Common.Extensions;

namespace WildOasis.Application.Cabin.Queries;

public record CabinDetailsQuery(string Id) : IRequest<CabinDetailsDto?>;

public class CabinDetailsQueryHandler(IWildOasisDbContext context,IOptions<AesEncryptionConfiguration>config) : IRequestHandler<CabinDetailsQuery, CabinDetailsDto?>
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
        //cXs7ErDmsM8DNH6bjB4i0w==

        var testPassword = "Nikola12345";
        var encryptPassword = testPassword.Encrypt(config.Value.Key);
        var decryptPassword = encryptPassword.Decrypt(config.Value.Key);


        return dto;
    }
}