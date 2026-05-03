using ELibraryAPI.Application.Features.Commands.UserSearchHistory.UpdateUserSearchHistory;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.UserSearchHistory;

public sealed class UpdateUserSearchHistoryCommandValidator : AbstractValidator<UpdateUserSearchHistoryCommandRequest>
{
    public UpdateUserSearchHistoryCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.SearchQuery)
            .NotEmpty().WithMessage("Search query cannot be empty.")
            .MaximumLength(500).WithMessage("Search query is too long.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");
    }
}
