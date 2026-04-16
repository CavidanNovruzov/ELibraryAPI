using ELibraryAPI.Application.Features.Queries.WishlistItem.GetByIdWishlistItem;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.WishlistItem;

public sealed class GetByIdWishlistItemQueryValidator : AbstractValidator<GetByIdWishlistItemQueryRequest>
{
    public GetByIdWishlistItemQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
