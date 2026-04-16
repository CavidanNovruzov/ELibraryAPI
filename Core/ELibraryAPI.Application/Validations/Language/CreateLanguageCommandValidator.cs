using ELibraryAPI.Application.Features.Commands.Language.CreateLanguage;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Language;

public sealed class CreateLanguageCommandValidator : AbstractValidator<CreateLanguageCommandRequest>
{
    public CreateLanguageCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty().MaximumLength(10);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
