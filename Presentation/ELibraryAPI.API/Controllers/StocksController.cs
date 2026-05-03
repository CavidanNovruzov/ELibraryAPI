using ELibraryAPI.Application.Features.Commands.Stock.CreateStock;
using ELibraryAPI.Application.Features.Commands.Stock.DeleteStock;
using ELibraryAPI.Application.Features.Commands.Stock.UpdateStock;
using ELibraryAPI.Application.Features.Queries.Stock.GetAllStock;
using ELibraryAPI.Application.Features.Queries.Stock.GetByIdStock;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/stocks")]
public sealed class StocksController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public StocksController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllStockQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdStockQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStockCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateStockCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteStockCommandRequest(id), ct));
}

