using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Features.Comments.CreateComments
{
    [ApiController]
    [Route("api/posts/comments")]
    public class CreateComments : ControllerBase
    {
        private readonly IMediator _mediator;

        public CreateComments(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(Command command)
        {
            return await _mediator.Send(command);
        }

        //private readonly Validator _validator;
        //private readonly AppService _context;
        //public CreateComments(AppService context, Validator validator)
        //{
        //    _context = context;
        //    _validator = validator;
        //}
        //[HttpPost]
        //public async Task<ActionResult> Create(Input input)
        //{
        //    var validationResult = _validator.Validate(input);
        //    if (validationResult.IsValid is false)
        //    {
        //        return BadRequest(validationResult.ToDictionary());
        //    }
        //    await _context.Handler(input);
        //    return Ok();
        //}
    }
}
