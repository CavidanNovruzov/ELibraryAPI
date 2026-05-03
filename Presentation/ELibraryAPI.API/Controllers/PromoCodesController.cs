using ELibraryAPI.Application.Features.Commands.PromoCode.CreatePromoCode;
using ELibraryAPI.Application.Features.Commands.PromoCode.DeletePromoCode;
using ELibraryAPI.Application.Features.Commands.PromoCode.UpdatePromoCode;
using ELibraryAPI.Application.Features.Queries.PromoCode.GetAllPromoCode;
using ELibraryAPI.Application.Features.Queries.PromoCode.GetByIdPromoCode;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/promo-codes")]
public sealed class PromoCodesController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public PromoCodesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllPromoCodeQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdPromoCodeQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePromoCodeCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePromoCodeCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeletePromoCodeCommandRequest(id), ct));
}

