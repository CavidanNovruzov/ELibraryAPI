using ELibraryAPI.Application.Features.Commands.UserAddress.CreateUserAddress;
using FluentValidation;

namespace ELibraryAPI.Application.Validations.UserAddress;

public sealed class CreateUserAddressCommandValidator : AbstractValidator<CreateUserAddressCommandRequest>
{
    public CreateUserAddressCommandValidator()
    {
        RuleFor(x => x.AddressLine).NotEmpty().MaximumLength(1000);
        RuleFor(x => x.UserId).NotEmpty();
    }
}
