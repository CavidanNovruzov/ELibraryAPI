using ELibraryAPI.Application.Features.Commands.OrderItem.UpdateOrderItem;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.OrderItem;

public sealed class UpdateOrderItemCommandValidator : AbstractValidator<UpdateOrderItemCommandRequest>
{
    public UpdateOrderItemCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.OrderId).NotEmpty();
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThan(0);
        RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
    }
}
