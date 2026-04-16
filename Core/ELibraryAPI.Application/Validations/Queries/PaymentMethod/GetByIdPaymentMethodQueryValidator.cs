using ELibraryAPI.Application.Features.Queries.PaymentMethod.GetByIdPaymentMethod;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.PaymentMethod;

public sealed class GetByIdPaymentMethodQueryValidator : AbstractValidator<GetByIdPaymentMethodQueryRequest>
{
    public GetByIdPaymentMethodQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
