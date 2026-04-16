using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.UserAddress.GetAllUserAddress;

public sealed class GetAllUserAddressQueryHandler : IRequestHandler<GetAllUserAddressQueryRequest, Result<GetAllUserAddressQueryResponse>>
{
    public Task<Result<GetAllUserAddressQueryResponse>> Handle(GetAllUserAddressQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
