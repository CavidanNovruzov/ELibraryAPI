using ELibraryAPI.Application.Features.Commands.OrderItem.DeleteOrderItem;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.OrderItem;

public sealed class DeleteOrderItemCommandValidator : AbstractValidator<DeleteOrderItemCommandRequest>
{
    public DeleteOrderItemCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
