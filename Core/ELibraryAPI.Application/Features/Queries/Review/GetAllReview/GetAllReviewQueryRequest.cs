using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.Review.GetAllReview;

public sealed record GetAllReviewQueryRequest : IRequest<Result<GetAllReviewQueryResponse>>;
