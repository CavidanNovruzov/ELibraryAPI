using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.UserAddress.GetByIdUserAddress;

public sealed class GetByIdUserAddressQueryHandler : IRequestHandler<GetByIdUserAddressQueryRequest, Result<GetByIdUserAddressQueryResponse>>
{
    public Task<Result<GetByIdUserAddressQueryResponse>> Handle(GetByIdUserAddressQueryRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
