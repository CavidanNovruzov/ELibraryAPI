using ELibraryAPI.Application.Features.Queries.Order.GetByIdOrder;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.Order;

public sealed class GetByIdOrderQueryValidator : AbstractValidator<GetByIdOrderQueryRequest>
{
    public GetByIdOrderQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
