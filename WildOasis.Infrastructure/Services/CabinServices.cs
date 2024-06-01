using Microsoft.EntityFrameworkCore;
using WildOasis.Application.Common.Dto.Cabin;
using WildOasis.Application.Common.Exceptions;
using WildOasis.Application.Common.Interfaces;
using WildOasis.Application.Common.Mappers;
using WildOasis.Infrastructure.Contexts;

namespace WildOasis.Infrastructure.Services;

public class CabinServices(WildOasisDbContext dbContext): ICabinService
{
    public async Task<CabinDetailsDto> CreateCabin(CabinCreateDto cabinCreateDto, CancellationToken cancellationToken)
    {
        var resort = await dbContext.Resorts.Where(x => x.Id == cabinCreateDto.ResortId)
            .FirstOrDefaultAsync(cancellationToken);

        if (resort == null)
        {
            throw new NotFoundException("Company not exist");
        }
        
        var cabin = cabinCreateDto.ToEntity().AddResort(resort);
        dbContext.Cabins.Add(cabin);
        await dbContext.SaveChangesAsync(cancellationToken);

        return cabin.ToDto();
    }

    public async Task<CabinDetailsDto> UpdateCabin(CabinUpdateDto cabinUpdateDto, CancellationToken cancellationToken)
    {
        var resort = await dbContext.Resorts.Where(x => x.Id == cabinUpdateDto.ResortId)
            .FirstOrDefaultAsync(cancellationToken);

        var existingCabin = await dbContext.Cabins.FindAsync(cabinUpdateDto.id);

        if (resort == null || existingCabin ==null)
        {
            throw new NotFoundException("Resort or cabin not exist");
        }

        existingCabin.Name = cabinUpdateDto.Name;
        existingCabin.Description = cabinUpdateDto.Description;
        existingCabin.MaxCapacity = cabinUpdateDto.MaxCapacity;
        existingCabin.RegularPrice = cabinUpdateDto.RegularPrice;
        existingCabin.Discount =  cabinUpdateDto.Discount;
        existingCabin.Image = cabinUpdateDto.Image;
        //existingCabin.Resort = request.cabin.ResortId;
        

        // Dodajte druge ažurirane atribute po potrebi

        // Spremanje promjena u bazu podataka
        await dbContext.SaveChangesAsync(cancellationToken);

        // Vraćanje detalja ažuriranog resorta
        return existingCabin.ToDto();
    }
    }
