using ELibraryAPI.Application.Features.Commands.OrderStatus.CreateOrderStatus;
using ELibraryAPI.Application.Features.Commands.OrderStatus.DeleteOrderStatus;
using ELibraryAPI.Application.Features.Commands.OrderStatus.UpdateOrderStatus;
using ELibraryAPI.Application.Features.Queries.OrderStatus.GetAllOrderStatus;
using ELibraryAPI.Application.Features.Queries.OrderStatus.GetByIdOrderStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/order-statuses")]
public sealed class OrderStatusesController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public OrderStatusesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllOrderStatusQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdOrderStatusQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderStatusCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOrderStatusCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteOrderStatusCommandRequest(id), ct));
}

