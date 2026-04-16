using ELibraryAPI.Application.Features.Queries.Review.GetByIdReview;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.Review;

public sealed class GetByIdReviewQueryValidator : AbstractValidator<GetByIdReviewQueryRequest>
{
    public GetByIdReviewQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
