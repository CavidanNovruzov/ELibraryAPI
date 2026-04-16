using ELibraryAPI.Application.Features.Commands.Order.UpdateOrder;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Order;

public sealed class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommandRequest>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.OrderNote).NotEmpty().MaximumLength(1000);
        RuleFor(x => x.OrderNumber).NotEmpty().MaximumLength(50);
        RuleFor(x => x.OrderStatusId).NotEmpty();
        RuleFor(x => x.PaymentMethodId).NotEmpty();
        RuleFor(x => x.ShippingMethodId).NotEmpty();
        RuleFor(x => x.TotalAmount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.UserId).NotEmpty();
    }
}
