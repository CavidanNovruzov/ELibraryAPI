using ELibraryAPI.Application.Features.Commands.RefreshToken.DeleteRefreshToken;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.RefreshToken;

public sealed class DeleteRefreshTokenCommandValidator : AbstractValidator<DeleteRefreshTokenCommandRequest>
{
    public DeleteRefreshTokenCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
