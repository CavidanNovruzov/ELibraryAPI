using ELibraryAPI.Application.Features.Queries.UserSearchHistory.GetByIdUserSearchHistory;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.UserSearchHistory;

public sealed class GetByIdUserSearchHistoryQueryValidator : AbstractValidator<GetByIdUserSearchHistoryQueryRequest>
{
    public GetByIdUserSearchHistoryQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
