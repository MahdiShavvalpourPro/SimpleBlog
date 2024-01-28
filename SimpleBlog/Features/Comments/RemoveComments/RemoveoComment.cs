using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Features.Comments.RemoveComments
{
    [ApiController]
    [Route("api/comment")]
    public class RemoveoComment : ControllerBase
    {
        private readonly IMediator _mediator;

        public RemoveoComment(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _mediator.Send(new Command() { Id = id });

            return NoContent();
        }
    }
}
