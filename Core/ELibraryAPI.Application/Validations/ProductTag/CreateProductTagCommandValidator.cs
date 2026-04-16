using ELibraryAPI.Application.Features.Commands.ProductTag.CreateProductTag;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.ProductTag;

public sealed class CreateProductTagCommandValidator : AbstractValidator<CreateProductTagCommandRequest>
{
    public CreateProductTagCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty();
        RuleFor(x => x.TagId).NotEmpty();
    }
}
