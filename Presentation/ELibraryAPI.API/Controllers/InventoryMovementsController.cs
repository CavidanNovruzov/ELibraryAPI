using ELibraryAPI.Application.Features.Commands.InventoryMovement.CreateInventoryMovement;
using ELibraryAPI.Application.Features.Commands.InventoryMovement.DeleteInventoryMovement;
using ELibraryAPI.Application.Features.Commands.InventoryMovement.UpdateInventoryMovement;
using ELibraryAPI.Application.Features.Queries.InventoryMovement.GetAllInventoryMovement;
using ELibraryAPI.Application.Features.Queries.InventoryMovement.GetByIdInventoryMovement;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/inventory-movements")]
public sealed class InventoryMovementsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public InventoryMovementsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllInventoryMovementQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdInventoryMovementQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateInventoryMovementCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateInventoryMovementCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteInventoryMovementCommandRequest(id), ct));
}

