using FluentValidation;
using WildOasis.Application.Cabin.Commands;

namespace WildOasis.Application.Cabin.Queries;

public class CabinDetailsQueryModelValidator : AbstractValidator<CabinDetailsQuery>
{
    public CabinDetailsQueryModelValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id have not be empty");
    }   
}