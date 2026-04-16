using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.PromoCode.GetByIdPromoCode;

public sealed record GetByIdPromoCodeQueryRequest(Guid Id) : IRequest<Result<GetByIdPromoCodeQueryResponse>>;
