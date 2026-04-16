using ELibraryAPI.Application.Features.Commands.OrderItem.CreateOrderItem;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.OrderItem;

public sealed class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommandRequest>
{
    public CreateOrderItemCommandValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
    }
}
