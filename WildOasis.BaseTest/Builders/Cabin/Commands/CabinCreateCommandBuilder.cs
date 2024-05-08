using WildOasis.Application.Cabin.Commands;
using WildOasis.Application.Common.Dto.Cabin;
using WildOasis.BaseTest.Builders.Dto;

namespace WildOasis.BaseTest.Builders.Cabin.Commands;

public class CabinCreateCommandBuilder
{
    
    private CabinCreateDto _cabinCreateDto = new CabinCreateDtoBuilder().Build();
    
    public CabinCommandCreate Build() => new( _cabinCreateDto);

    public CabinCreateCommandBuilder WithCabinCreateDto(CabinCreateDto cabinCreateDto)
    {
        _cabinCreateDto = cabinCreateDto;
        return this;

    }
}