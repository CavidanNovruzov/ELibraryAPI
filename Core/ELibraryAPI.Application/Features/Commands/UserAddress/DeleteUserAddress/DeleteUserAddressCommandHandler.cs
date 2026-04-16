using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.UserAddress.DeleteUserAddress;

public sealed class DeleteUserAddressCommandHandler : IRequestHandler<DeleteUserAddressCommandRequest, Result>
{
    public Task<Result> Handle(DeleteUserAddressCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
