using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WildOasis.Application.Cabin.Queries;
using WildOasis.Application.Common.Dto.Cabin;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Application.Common.Mappers;

namespace WildOasis.Application.Cabin.Commands;

public record CabinCommmandDelete(string Id) : IRequest;

public class CabinCommmandDeleteHandler(IWildOasisDbContext context) : IRequestHandler<CabinCommmandDelete>
{
  

    public async Task Handle(CabinCommmandDelete request, CancellationToken cancellationToken)
    {
        var cabin = await context.Cabins.FindAsync(Guid.Parse(request.Id));

        if (cabin == null)
        {
            throw new Exception($"Cabin with id {request.Id} not found");
        }

        context.Cabins.Remove(cabin);
        await context.SaveChangesAsync(cancellationToken);


    }
}