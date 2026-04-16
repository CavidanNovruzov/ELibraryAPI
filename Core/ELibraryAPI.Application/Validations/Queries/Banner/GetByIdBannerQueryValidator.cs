using ELibraryAPI.Application.Features.Queries.Banner.GetByIdBanner;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.Banner;

public sealed class GetByIdBannerQueryValidator : AbstractValidator<GetByIdBannerQueryRequest>
{
    public GetByIdBannerQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
