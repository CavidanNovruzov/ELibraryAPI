using ELibraryAPI.Application.Features.Commands.Banner.UpdateBanner;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Banner;

public sealed class UpdateBannerCommandValidator : AbstractValidator<UpdateBannerCommandRequest>
{
    public UpdateBannerCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();


        RuleFor(x => x.Order)
            .GreaterThanOrEqualTo(0).WithMessage("Order cannot be negative.");

    }
}