using ELibraryAPI.Application.Features.Commands.Campaign.UpdateCampaign;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Campaign;


public sealed class UpdateCampaignCommandValidator : AbstractValidator<UpdateCampaignCommandRequest>
{
    public UpdateCampaignCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.DiscountPercent).InclusiveBetween(0, 100);

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate)
            .WithMessage("End date must be later than the start date.");
    }
}