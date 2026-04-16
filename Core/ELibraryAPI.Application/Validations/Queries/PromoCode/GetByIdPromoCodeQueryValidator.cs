using ELibraryAPI.Application.Features.Queries.PromoCode.GetByIdPromoCode;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.PromoCode;

public sealed class GetByIdPromoCodeQueryValidator : AbstractValidator<GetByIdPromoCodeQueryRequest>
{
    public GetByIdPromoCodeQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
