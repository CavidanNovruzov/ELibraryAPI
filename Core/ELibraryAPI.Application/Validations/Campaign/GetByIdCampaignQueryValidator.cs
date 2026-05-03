using ELibraryAPI.Application.Features.Queries.Campaign.GetByIdCampaign;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Campaign
{
    public sealed class GetByIdCampaignQueryValidator : AbstractValidator<GetByIdCampaignQueryRequest>
    {
        public GetByIdCampaignQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotEqual(Guid.Empty);
        }
    }
}
