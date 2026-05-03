using FluentValidation;
using ELibraryAPI.Application.Features.Commands.Banner.DeleteBanner;

namespace ELibraryAPI.Application.Validations.Banner;

public sealed class DeleteBannerCommandValidator : AbstractValidator<DeleteBannerCommandRequest>
{
    public DeleteBannerCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Banner ID is required for deletion.")
            .NotEqual(Guid.Empty).WithMessage("Invalid Banner ID.");
    }
}