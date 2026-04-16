using ELibraryAPI.Application.Features.Commands.Campaign.CreateCampaign;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Campaign;

public sealed class CreateCampaignCommandValidator : AbstractValidator<CreateCampaignCommandRequest>
{
    public CreateCampaignCommandValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.DiscountPercent).InclusiveBetween(0,100);
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
    }
}
