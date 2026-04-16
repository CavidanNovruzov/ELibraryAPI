using ELibraryAPI.Application.Responses;
using MediatR;

namespace ELibraryAPI.Application.Features.Commands.Stock.DeleteStock;

public sealed class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommandRequest, Result>
{
    public Task<Result> Handle(DeleteStockCommandRequest request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
