using ELibraryAPI.Application.Features.Commands.Campaign.CreateCampaign;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Campaign;

public sealed class CreateCampaignCommandValidator : AbstractValidator<CreateCampaignCommandRequest>
{
    public CreateCampaignCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");

        RuleFor(x => x.DiscountPercent)
            .InclusiveBetween(0, 100).WithMessage("Discount percent must be between 0 and 100.");

        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(DateTime.UtcNow.Date)
            .WithMessage("Start date cannot be in the past.");

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate)
            .WithMessage("End date must be later than the start date.");
    }
}