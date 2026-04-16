using ELibraryAPI.Application.Features.Commands.CoverType.DeleteCoverType;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.CoverType;

public sealed class DeleteCoverTypeCommandValidator : AbstractValidator<DeleteCoverTypeCommandRequest>
{
    public DeleteCoverTypeCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
