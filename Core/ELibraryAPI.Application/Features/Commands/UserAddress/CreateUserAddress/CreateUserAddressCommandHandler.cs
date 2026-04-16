using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.UserAddress.CreateUserAddress;

public sealed class CreateUserAddressCommandHandler : IRequestHandler<CreateUserAddressCommandRequest, Result<CreateUserAddressCommandResponse>>
{
    public Task<Result<CreateUserAddressCommandResponse>> Handle(CreateUserAddressCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
