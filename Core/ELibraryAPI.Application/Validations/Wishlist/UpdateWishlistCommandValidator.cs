using ELibraryAPI.Application.Features.Commands.Wishlist.UpdateWishlist;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Wishlist;

public sealed class UpdateWishlistCommandValidator : AbstractValidator<UpdateWishlistCommandRequest>
{
    public UpdateWishlistCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.UserId).NotEmpty();
    }
}
