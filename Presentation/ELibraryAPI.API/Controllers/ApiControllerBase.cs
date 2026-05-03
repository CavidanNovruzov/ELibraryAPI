using ELibraryAPI.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ELibraryAPI.API.Controllers;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    protected IActionResult FromResult(Result result)
        => result.IsSuccess ? Ok(result) : BadRequest(result);

    protected IActionResult FromResult<T>(Result<T> result)
        => result.IsSuccess ? Ok(result) : BadRequest(result);
}

