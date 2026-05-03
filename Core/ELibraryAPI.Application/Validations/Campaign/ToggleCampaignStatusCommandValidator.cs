using ELibraryAPI.Application.Features.Commands.Campaign.ToggleCampaignStatus;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Campaign;

public sealed class ToggleCampaignStatusCommandValidator : AbstractValidator<ToggleCampaignStatusCommandRequest>
{
    public ToggleCampaignStatusCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Campaign ID is required.");
    }
}