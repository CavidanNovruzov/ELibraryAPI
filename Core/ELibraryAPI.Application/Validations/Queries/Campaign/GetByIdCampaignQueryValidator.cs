using ELibraryAPI.Application.Features.Queries.Campaign.GetByIdCampaign;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.Campaign;

public sealed class GetByIdCampaignQueryValidator : AbstractValidator<GetByIdCampaignQueryRequest>
{
    public GetByIdCampaignQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
