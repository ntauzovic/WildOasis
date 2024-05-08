using FluentValidation;
using MediatR;
using WildOasis.Application.Common.Extensions;
using ValidationException = WildOasis.Application.Common.Exceptions.ValidationException;

namespace WildOasis.Application.Common.Behaviours;

public class ValidationBehaviours<TRequest,TResponse>(IEnumerable<IValidator<TRequest>>validators):
    IPipelineBehavior<TRequest,TResponse> where TRequest: IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!validators.Any())
            return await next();
        var context = new ValidationContext<TRequest>(request);

        var validationResult = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResult.Where(r => r.Errors.Count != 0).SelectMany(r => r.Errors).ToList();

        if (failures.Count != 0)
            throw new ValidationException(failures.ToGroup());
        return await next();
    }
}