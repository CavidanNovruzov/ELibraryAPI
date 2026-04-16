using ELibraryAPI.Application.Features.Commands.UserSearchHistory.UpdateUserSearchHistory;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.UserSearchHistory;

public sealed class UpdateUserSearchHistoryCommandValidator : AbstractValidator<UpdateUserSearchHistoryCommandRequest>
{
    public UpdateUserSearchHistoryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.SearchQuery).NotEmpty().MaximumLength(500);
        RuleFor(x => x.UserId).NotEmpty();
    }
}
