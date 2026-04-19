using ELibraryAPI.Application.Features.Commands.Review.CreateReview;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Review;

public sealed class CreateReviewCommandValidator : AbstractValidator<CreateReviewCommandRequest>
{
    public CreateReviewCommandValidator()
    {
        RuleFor(x => x.Comment).NotEmpty().MaximumLength(2000);
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Rating).InclusiveBetween(1,5);
        RuleFor(x => x.UserId).NotEmpty();
    }
}
