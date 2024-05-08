using MediatR;
using WildOasis.Application.Cabin.Commands;
using WildOasis.Application.Common.Interfaces;

namespace WildOasis.Application.Resort.Commands;


public record ResortCommmandDelete(string Id) : IRequest;

public class ResortCommmandDeleteHandler(IWildOasisDbContext context) : IRequestHandler<ResortCommmandDelete>
{
  

    public async Task Handle(ResortCommmandDelete request, CancellationToken cancellationToken)
    {
        var resort = await context.Resorts.FindAsync(Guid.Parse(request.Id));

        if (resort == null)
        {
            throw new Exception($"Cabin with id {request.Id} not found");
        }

        context.Resorts.Remove(resort);
        await context.SaveChangesAsync(cancellationToken);


    }
}