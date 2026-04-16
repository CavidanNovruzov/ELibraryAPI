using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.UserAddress.GetByIdUserAddress;

public sealed record GetByIdUserAddressQueryRequest(Guid Id) : IRequest<Result<GetByIdUserAddressQueryResponse>>;
