using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Stock.CreateStock;

public sealed class CreateStockCommandHandler : IRequestHandler<CreateStockCommandRequest, Result<CreateStockCommandResponse>>
{
    public Task<Result<CreateStockCommandResponse>> Handle(CreateStockCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
