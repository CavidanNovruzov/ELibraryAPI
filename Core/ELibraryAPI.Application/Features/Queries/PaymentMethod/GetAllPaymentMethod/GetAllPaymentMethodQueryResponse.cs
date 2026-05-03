namespace ELibraryAPI.Application.Features.Queries.PaymentMethod.GetAllPaymentMethod;

public sealed record GetAllPaymentMethodQueryResponse(
    List<PaymentMethodListDto> PaymentMethods
);

public sealed record PaymentMethodListDto(
    Guid Id,
    string Name
);
