using ELibraryAPI.Application.Features.Queries.Order.GetOrdersByStatus;
using FluentValidation;


namespace ELibraryAPI.Application.Validations.OrderItem;

public sealed class GetOrdersByStatusQueryValidator : AbstractValidator<GetOrdersByStatusQueryRequest>
{
    public GetOrdersByStatusQueryValidator()
    {
        RuleFor(x => x.StatusId)
            .NotEmpty().WithMessage("Status ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Valid Status ID is required.");
    }
}
