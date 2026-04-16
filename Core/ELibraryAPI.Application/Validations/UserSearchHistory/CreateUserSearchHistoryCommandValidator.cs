using ELibraryAPI.Application.Features.Commands.UserSearchHistory.CreateUserSearchHistory;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.UserSearchHistory;

public sealed class CreateUserSearchHistoryCommandValidator : AbstractValidator<CreateUserSearchHistoryCommandRequest>
{
    public CreateUserSearchHistoryCommandValidator()
    {
        RuleFor(x => x.SearchQuery).NotEmpty().MaximumLength(500);
        RuleFor(x => x.UserId).NotEmpty();
    }
}
