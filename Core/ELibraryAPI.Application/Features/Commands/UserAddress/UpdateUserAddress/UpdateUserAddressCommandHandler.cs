using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.UserAddress.UpdateUserAddress;

public sealed class UpdateUserAddressCommandHandler : IRequestHandler<UpdateUserAddressCommandRequest, Result<UpdateUserAddressCommandResponse>>
{
    public Task<Result<UpdateUserAddressCommandResponse>> Handle(UpdateUserAddressCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
