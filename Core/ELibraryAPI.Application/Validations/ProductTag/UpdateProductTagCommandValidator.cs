using ELibraryAPI.Application.Features.Commands.ProductTag.UpdateProductTag;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.ProductTag;

public sealed class UpdateProductTagCommandValidator : AbstractValidator<UpdateProductTagCommandRequest>
{
    public UpdateProductTagCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.TagId).NotEmpty();
    }
}
