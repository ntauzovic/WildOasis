using FluentValidation.Results;

namespace WildOasis.Application.Common.Extensions;

public static class ValidationExtension
{
    public static IDictionary<string, string[]> ToGroup(this IEnumerable<ValidationFailure> validationFailures)
    {
        return validationFailures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key,
                failureGroup => failureGroup.ToArray());
    }
}