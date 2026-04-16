using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Queries.PaymentMethod.GetByIdPaymentMethod;

public sealed record GetByIdPaymentMethodQueryRequest(Guid Id) : IRequest<Result<GetByIdPaymentMethodQueryResponse>>;
