using ELibraryAPI.Application.Features.Commands.Banner.CreateBanner;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Banner;

public sealed class CreateBannerCommandValidator : AbstractValidator<CreateBannerCommandRequest>
{
    public CreateBannerCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().MaximumLength(200);

        RuleFor(x => x.RedirectUrl)
            .MaximumLength(500);

        RuleFor(x => x.Order)
            .GreaterThanOrEqualTo(0);
    }
}