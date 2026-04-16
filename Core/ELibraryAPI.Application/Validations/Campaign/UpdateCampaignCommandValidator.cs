using ELibraryAPI.Application.Features.Commands.Campaign.UpdateCampaign;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Campaign;

public sealed class UpdateCampaignCommandValidator : AbstractValidator<UpdateCampaignCommandRequest>
{
    public UpdateCampaignCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();

        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.DiscountPercent).InclusiveBetween(0,100);
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
    }
}
