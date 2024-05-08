using MediatR;
using Microsoft.EntityFrameworkCore;
using WildOasis.Application.Common.Dto.Cabin;
using WildOasis.Application.Common.Dto.Resort;
using WildOasis.Application.Common.Exceptions;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Application.Common.Mappers;

namespace WildOasis.Application.Resort.Commands;

public record ResortCommandUpdate(ResortUpdateDto resort) : IRequest<ResortDetailsDto?>;

public class ResortCommandUpdateHandler(IWildOasisDbContext context) : IRequestHandler<ResortCommandUpdate, ResortDetailsDto?>
{
    public async Task<ResortDetailsDto?> Handle(ResortCommandUpdate request, CancellationToken cancellationToken)
    {
        
        var existingResort = await context.Resorts.FindAsync(request.resort.Id);

        // Ako ne postoji resort s datim ID-om, izbaci iznimku
        if (existingResort == null)
        {
            throw new NotFoundException($"Resort with id {request.resort.Id} not found");
        }

        // Ažuriranje podataka resorta
        existingResort.Name = request.resort.Name;
        existingResort.Description = request.resort.Description;
        existingResort.Address = request.resort.Address;
        existingResort.Number = request.resort.Number;

        // Dodajte druge ažurirane atribute po potrebi

        // Spremanje promjena u bazu podataka
        await context.SaveChangesAsync(cancellationToken);

        // Vraćanje detalja ažuriranog resorta
        return existingResort.ToDto();
    }
}