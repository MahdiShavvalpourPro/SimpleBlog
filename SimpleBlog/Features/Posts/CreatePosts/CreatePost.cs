using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Features.Posts.CreatePosts;

[ApiController]
[Route("api/posts")]
public class CreatePost : ControllerBase
{
    private readonly AppService _createPostAppService;
    private readonly IMediator _mediator;
    //private readonly IValidator<Input> _validator;
    public CreatePost(
    AppService createPostAppService,
    IMediator mediator
    //IValidator<Input> validator
        )
    {
        _createPostAppService = createPostAppService;
        _mediator = mediator;
        //_validator = validator;
    }

    //[HttpPost]
    //public async Task<ActionResult> Create([FromBody] Input input)
    //{
    //    var validationResult = _validator.Validate(input);
    //    if (!validationResult.IsValid)
    //    {
    //        return BadRequest(validationResult.ToDictionary());
    //    }
    //    await _createPostAppService.CreatePostAsync(input);
    //    return Ok();
    //}

    [HttpPost]
    public async Task<ActionResult<int>> Make(Command command)
    {
        return await _mediator.Send(command);
    }
}
