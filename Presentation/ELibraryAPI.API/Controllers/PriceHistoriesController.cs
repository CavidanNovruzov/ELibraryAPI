using ELibraryAPI.Application.Features.Commands.PriceHistory.CreatePriceHistory;
using ELibraryAPI.Application.Features.Commands.PriceHistory.DeletePriceHistory;
using ELibraryAPI.Application.Features.Commands.PriceHistory.UpdatePriceHistory;
using ELibraryAPI.Application.Features.Queries.PriceHistory.GetAllPriceHistory;
using ELibraryAPI.Application.Features.Queries.PriceHistory.GetByIdPriceHistory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/price-histories")]
public sealed class PriceHistoriesController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public PriceHistoriesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllPriceHistoryQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdPriceHistoryQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePriceHistoryCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePriceHistoryCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeletePriceHistoryCommandRequest(id), ct));
}

