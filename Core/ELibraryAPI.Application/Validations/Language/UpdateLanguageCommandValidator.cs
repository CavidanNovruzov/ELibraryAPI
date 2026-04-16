using ELibraryAPI.Application.Features.Commands.Language.UpdateLanguage;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Language;

public sealed class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommandRequest>
{
    public UpdateLanguageCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Code).NotEmpty().MaximumLength(10);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
