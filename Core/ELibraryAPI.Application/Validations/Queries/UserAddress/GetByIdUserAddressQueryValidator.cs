using ELibraryAPI.Application.Features.Queries.UserAddress.GetByIdUserAddress;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.Queries.UserAddress;

public sealed class GetByIdUserAddressQueryValidator : AbstractValidator<GetByIdUserAddressQueryRequest>
{
    public GetByIdUserAddressQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
