using ELibraryAPI.Application.Features.Commands.ShippingMethod.CreateShippingMethod;
using ELibraryAPI.Application.Features.Commands.ShippingMethod.DeleteShippingMethod;
using ELibraryAPI.Application.Features.Commands.ShippingMethod.UpdateShippingMethod;
using ELibraryAPI.Application.Features.Queries.ShippingMethod.GetAllShippingMethod;
using ELibraryAPI.Application.Features.Queries.ShippingMethod.GetByIdShippingMethod;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/shipping-methods")]
public sealed class ShippingMethodsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ShippingMethodsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllShippingMethodQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdShippingMethodQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateShippingMethodCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateShippingMethodCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteShippingMethodCommandRequest(id), ct));
}

