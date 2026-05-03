using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.PaymentMethod.GetAllPaymentMethod;

public sealed record GetAllPaymentMethodQueryRequest : IRequest<Result<GetAllPaymentMethodQueryResponse>>;
