using FluentValidation;

namespace WildOasis.Application.Auth.Command.CompleteLoginCommand;

public class CompleteLoginModelValidator : AbstractValidator<CompleteLoginCommand>
{
    public CompleteLoginModelValidator()
    {
        RuleFor(x => x.ValidationToken)
            .NotEmpty();
    }
}