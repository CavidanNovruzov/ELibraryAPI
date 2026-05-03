using ELibraryAPI.Application.Features.Commands.PaymentMethod.CreatePaymentMethod;
using ELibraryAPI.Application.Features.Commands.PaymentMethod.DeletePaymentMethod;
using ELibraryAPI.Application.Features.Commands.PaymentMethod.UpdatePaymentMethod;
using ELibraryAPI.Application.Features.Queries.PaymentMethod.GetAllPaymentMethod;
using ELibraryAPI.Application.Features.Queries.PaymentMethod.GetByIdPaymentMethod;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/payment-methods")]
public sealed class PaymentMethodsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public PaymentMethodsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllPaymentMethodQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdPaymentMethodQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePaymentMethodCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePaymentMethodCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeletePaymentMethodCommandRequest(id), ct));
}

