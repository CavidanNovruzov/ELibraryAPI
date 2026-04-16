using ELibraryAPI.Application.Features.Commands.Banner.DeleteBanner;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Banner;

public sealed class DeleteBannerCommandValidator : AbstractValidator<DeleteBannerCommandRequest>
{
    public DeleteBannerCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
