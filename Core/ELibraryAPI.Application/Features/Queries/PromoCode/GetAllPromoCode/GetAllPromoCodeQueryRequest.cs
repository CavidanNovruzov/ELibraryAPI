using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.PromoCode.GetAllPromoCode;

public sealed record GetAllPromoCodeQueryRequest : IRequest<Result<GetAllPromoCodeQueryResponse>>;
