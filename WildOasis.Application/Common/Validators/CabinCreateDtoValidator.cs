using FluentValidation;
using WildOasis.Application.Common.Dto.Cabin;
using WildOasis.Domain.Common.Extensions;
using WildOasis.Domain.Enums;

namespace WildOasis.Application.Common.Validators;

public class CabinCreateDtoValidator : AbstractValidator<CabinCreateDto>
{
     public CabinCreateDtoValidator()
     {
          RuleFor(x => x.Name).NotEmpty();
          RuleFor(x => x.ResortId).NotEmpty();
          RuleFor(x => x.Category).Must(t => Category.TryFromValue(t, out _)).WithName("Category").WithMessage(
               t => $"Category is not valid, it must have number one of the list:{EnumExtensions.CategoryValidList}");
     }
}