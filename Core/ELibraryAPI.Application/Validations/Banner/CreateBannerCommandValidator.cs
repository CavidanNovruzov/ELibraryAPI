using ELibraryAPI.Application.Features.Commands.Banner.CreateBanner;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Banner;

public sealed class CreateBannerCommandValidator : AbstractValidator<CreateBannerCommandRequest>
{
    public CreateBannerCommandValidator()
    {
        RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(1000);
        RuleFor(x => x.RedirectUrl).NotEmpty().MaximumLength(1000);
    }
}
