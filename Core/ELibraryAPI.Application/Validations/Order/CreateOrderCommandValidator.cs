using ELibraryAPI.Application.Features.Commands.Order.CreateOrder;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Order;

public sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommandRequest>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.OrderNote).NotEmpty().MaximumLength(1000);
        RuleFor(x => x.OrderNumber).NotEmpty().MaximumLength(50);
        RuleFor(x => x.OrderStatusId).NotEmpty();
        RuleFor(x => x.PaymentMethodId).NotEmpty();
        RuleFor(x => x.ShippingMethodId).NotEmpty();
        RuleFor(x => x.TotalAmount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.UserId).NotEmpty();
    }
}
