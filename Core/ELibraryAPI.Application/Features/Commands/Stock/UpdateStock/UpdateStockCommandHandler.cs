using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Stock.UpdateStock;

public sealed class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommandRequest, Result<UpdateStockCommandResponse>>
{
    public Task<Result<UpdateStockCommandResponse>> Handle(UpdateStockCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
