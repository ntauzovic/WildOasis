using FluentValidation;
using WildOasis.Application.Cabin.Commands;
using WildOasis.Application.Common.Dto.Cabin;
using WildOasis.Domain.Common.Extensions;

namespace WildOasis.Application.Common.Validators;

public class CabinTestCreateDtoValidator : AbstractValidator<CabinTestDto>
{
    public CabinTestCreateDtoValidator()
    {
        RuleFor(x=>x.Json).Must(t=>t.TryDeserialaize<CabinCommandCreate>
            (out _,SerializerExtensions.SettingsWebOptions)).WithMessage(
            t => "Json is not in good format");


    }
    
}