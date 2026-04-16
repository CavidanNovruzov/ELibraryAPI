using ELibraryAPI.Application.Features.Commands.Tag.CreateTag;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Tag;

public sealed class CreateTagCommandValidator : AbstractValidator<CreateTagCommandRequest>
{
    public CreateTagCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
