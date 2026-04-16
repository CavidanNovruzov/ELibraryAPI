using ELibraryAPI.Application.Features.Commands.Banner.UpdateBanner;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Banner;

public sealed class UpdateBannerCommandValidator : AbstractValidator<UpdateBannerCommandRequest>
{
    public UpdateBannerCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(1000);
        RuleFor(x => x.RedirectUrl).NotEmpty().MaximumLength(1000);
    }
}
