using ELibraryAPI.Application.Features.Commands.Basket.CreateBasket;
using ELibraryAPI.Application.Features.Commands.Basket.DeleteBasket;
using ELibraryAPI.Application.Features.Commands.BasketItem.ClearBasketItem;
using ELibraryAPI.Application.Features.Commands.BasketItem.CreateBasketItem;
using ELibraryAPI.Application.Features.Commands.BasketItem.DeleteBasketItem;
using ELibraryAPI.Application.Features.Commands.BasketItem.UpdateBasketItem;
using ELibraryAPI.Application.Features.Queries.Basket.GetAllBasket;
using ELibraryAPI.Application.Features.Queries.Basket.GetByIdBasket;
using ELibraryAPI.Domain.Constants;
using ELibraryAPI.Infrastructure.Security.Attributes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Authorize]
[Route("api/[controller]")]
public sealed class BasketsController : ApiControllerBase
{
    private readonly IMediator _mediator;
    public BasketsController(IMediator mediator) => _mediator = mediator;

    #region Basket Operations

    [HttpGet]
    [HasPermission(AuthorizePermissions.Basket.ViewAll)]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllBasketQueryRequest(), ct));

    [HttpGet("my-basket/{id:guid}")]
    public async Task<IActionResult> GetMyBasket(Guid id,CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdBasketQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create(CreateBasketCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteBasketCommandRequest(id), ct));
    #endregion

    #region BasketItem Operations

    [HttpPost("items")]
    public async Task<IActionResult> AddItem([FromBody] CreateBasketItemCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("items/{id:guid}")]
    public async Task<IActionResult> UpdateItemQuantity(Guid id, [FromBody] UpdateBasketItemQuantityRequest request, CancellationToken ct)
    {
        var command = request with { Id = id };
        return FromResult(await _mediator.Send(command, ct));
    }

    [HttpDelete("items/{id:guid}")]
    public async Task<IActionResult> RemoveItem(Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteBasketItemCommandRequest(id), ct));

    [HttpDelete("items/clear")]
    public async Task<IActionResult> ClearMyBasket([FromBody] ClearBasketItemCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));
    #endregion
}