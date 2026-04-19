using ELibraryAPI.Application.Features.Commands.PromoCode.CreatePromoCode;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.PromoCode;

public sealed class CreatePromoCodeCommandValidator : AbstractValidator<CreatePromoCodeCommandRequest>
{
    public CreatePromoCodeCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty().MaximumLength(50).Matches("^[A-Z0-9]+$");
        RuleFor(x => x.DiscountPercent).InclusiveBetween(0,100);
        RuleFor(x => x.EndDate).NotEmpty().GreaterThanOrEqualTo(DateTime.UtcNow.Date);
        RuleFor(x => x.StartDate).NotEmpty();
        RuleFor(x => x.UsageLimit).GreaterThanOrEqualTo(0);
    }
}
