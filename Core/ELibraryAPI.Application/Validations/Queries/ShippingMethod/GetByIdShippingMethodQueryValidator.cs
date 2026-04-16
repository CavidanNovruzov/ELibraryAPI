using ELibraryAPI.Application.Features.Queries.ShippingMethod.GetByIdShippingMethod;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.ShippingMethod;

public sealed class GetByIdShippingMethodQueryValidator : AbstractValidator<GetByIdShippingMethodQueryRequest>
{
    public GetByIdShippingMethodQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
