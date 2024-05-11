using FluentValidation;

namespace WildOasis.Application.Auth.Command.BeginLoginCommand;

public class BeginLoginCommandModelValidator : AbstractValidator<BeginLoginCommand>
{
    public BeginLoginCommandModelValidator()
    {
        RuleFor(x => x.EmailAddress).EmailAddress().NotNull();
    }

}