using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Features.Posts.GetPostByIds;

[ApiController]
[Route("api/posts")]
public class GetPostById : ControllerBase
{
    private readonly AppService _appService;

    public GetPostById(AppService appService)
    {
        _appService = appService;
    }
    [HttpGet("/{id}")]
    public async Task<ActionResult<Response>> Handler([FromRoute] int id)
    {
        return Ok(await _appService.Handler(id));
    }
}
