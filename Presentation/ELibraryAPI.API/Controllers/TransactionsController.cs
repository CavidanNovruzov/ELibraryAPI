using ELibraryAPI.Application.Features.Commands.Transaction.CreateTransaction;
using ELibraryAPI.Application.Features.Commands.Transaction.DeleteTransaction;
using ELibraryAPI.Application.Features.Commands.Transaction.UpdateTransaction;
using ELibraryAPI.Application.Features.Queries.Transaction.GetAllTransaction;
using ELibraryAPI.Application.Features.Queries.Transaction.GetByIdTransaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/transactions")]
public sealed class TransactionsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllTransactionQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdTransactionQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTransactionCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTransactionCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteTransactionCommandRequest(id), ct));
}

