using ELibraryAPI.Application.Features.Commands.UserSearchHistory.CreateUserSearchHistory;
using ELibraryAPI.Application.Features.Commands.UserSearchHistory.DeleteUserSearchHistory;
using ELibraryAPI.Application.Features.Commands.UserSearchHistory.UpdateUserSearchHistory;
using ELibraryAPI.Application.Features.Queries.UserSearchHistory.GetAllUserSearchHistory;
using ELibraryAPI.Application.Features.Queries.UserSearchHistory.GetByIdUserSearchHistory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/user-search-histories")]
public sealed class UserSearchHistoriesController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public UserSearchHistoriesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllUserSearchHistoryQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdUserSearchHistoryQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserSearchHistoryCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserSearchHistoryCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteUserSearchHistoryCommandRequest(id), ct));
}

