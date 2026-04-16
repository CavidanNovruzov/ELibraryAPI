using ELibraryAPI.Application.Features.Commands.Campaign.DeleteCampaign;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Campaign;

public sealed class DeleteCampaignCommandValidator : AbstractValidator<DeleteCampaignCommandRequest>
{
    public DeleteCampaignCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
