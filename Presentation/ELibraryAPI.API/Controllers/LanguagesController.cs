using ELibraryAPI.Application.Features.Commands.Language.CreateLanguage;
using ELibraryAPI.Application.Features.Commands.Language.DeleteLanguage;
using ELibraryAPI.Application.Features.Commands.Language.UpdateLanguage;
using ELibraryAPI.Application.Features.Queries.Language.GetAllLanguage;
using ELibraryAPI.Application.Features.Queries.Language.GetByIdLanguage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[Route("api/languages")]
public sealed class LanguagesController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public LanguagesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
        => FromResult(await _mediator.Send(new GetAllLanguageQueryRequest(), ct));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new GetByIdLanguageQueryRequest(id), ct));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLanguageCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request, ct));

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateLanguageCommandRequest request, CancellationToken ct)
        => FromResult(await _mediator.Send(request with { Id = id }, ct));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        => FromResult(await _mediator.Send(new DeleteLanguageCommandRequest(id), ct));
}

