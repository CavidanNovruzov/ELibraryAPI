using ELibraryAPI.Application.Features.Queries.Wishlist.GetByIdWishlist;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.Wishlist;

public sealed class GetByIdWishlistQueryValidator : AbstractValidator<GetByIdWishlistQueryRequest>
{
    public GetByIdWishlistQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
