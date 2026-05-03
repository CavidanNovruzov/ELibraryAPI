using ELibraryAPI.Application.Features.Commands.OrderItem.CreateOrderItem;
using ELibraryAPI.Application.Features.Commands.OrderItem.DeleteOrderItem;
using ELibraryAPI.Application.Features.Commands.OrderItem.UpdateOrderItem;
using ELibraryAPI.Application.Features.Queries.OrderItem.GetAllOrderItem;
using ELibraryAPI.Application.Features.Queries.OrderItem.GetByIdOrderItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/order-items")]
public sealed class OrderItemsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public OrderItemsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllOrderItemQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdOrderItemQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderItemCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOrderItemCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteOrderItemCommandRequest(id), ct));
}

