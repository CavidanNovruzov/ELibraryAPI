using ELibraryAPI.Application.Features.Queries.OrderStatus.GetByIdOrderStatus;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.OrderStatus;

public sealed class GetByIdOrderStatusQueryValidator : AbstractValidator<GetByIdOrderStatusQueryRequest>
{
    public GetByIdOrderStatusQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
