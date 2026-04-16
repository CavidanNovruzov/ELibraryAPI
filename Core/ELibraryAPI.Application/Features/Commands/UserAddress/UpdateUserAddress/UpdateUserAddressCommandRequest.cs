using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.UserAddress.UpdateUserAddress;

public sealed record UpdateUserAddressCommandRequest(
    Guid Id,
    string AddressLine,
    Guid UserId
) : IRequest<Result<UpdateUserAddressCommandResponse>>;
