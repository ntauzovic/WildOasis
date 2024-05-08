using WildOasis.Application.Common.Dto.Resort;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Application.Common.Mappers;

namespace WildOasis.Infrastructure.Services;

public class ResortService(IWildOasisDbContext dbContext) : IResortServices
{
    public async Task<ResortDetailsDto> Create(ResortCreateDto resortCreateDto, CancellationToken cancellationToken)
    {
        var resort = resortCreateDto.ToEntityResort();

        dbContext.Resorts.Add(resort);
        await dbContext.SaveChangesAsync(cancellationToken);
        return resort.ToDto();
    }
}