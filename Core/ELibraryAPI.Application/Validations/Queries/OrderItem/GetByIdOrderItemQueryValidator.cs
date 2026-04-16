using ELibraryAPI.Application.Features.Queries.OrderItem.GetByIdOrderItem;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.OrderItem;

public sealed class GetByIdOrderItemQueryValidator : AbstractValidator<GetByIdOrderItemQueryRequest>
{
    public GetByIdOrderItemQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
