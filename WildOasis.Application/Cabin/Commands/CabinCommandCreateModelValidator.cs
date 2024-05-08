using FluentValidation;
using WildOasis.Application.Common.Validators;

namespace WildOasis.Application.Cabin.Commands;

public class CabinCommandCreateModelValidator : AbstractValidator<CabinCommandCreate>
{
    public CabinCommandCreateModelValidator()
    {
        RuleFor(x => x.cabin.ResortId).NotEmpty();
        RuleFor(x => x.cabin.Name).NotEmpty();
        RuleFor(x => x.cabin.Description).NotEmpty().MinimumLength(10);
        RuleFor(x => x.cabin.MaxCapacity).NotEmpty().GreaterThanOrEqualTo(1);
        RuleFor(x => x.cabin.RegularPrice).NotEmpty();
        RuleFor(x => x.cabin.Discount).NotEmpty().LessThan(x=>x.cabin.RegularPrice);
        RuleFor(x => x.cabin.Image).NotEmpty();
        RuleFor(x => x.cabin).SetValidator(new CabinCreateDtoValidator());
    }

}