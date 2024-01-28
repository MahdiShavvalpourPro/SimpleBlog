using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SimpleBlog.Features.Comments.GetComments
{
    [ApiController]
    [Route("api/comments")]
    public class GetCommentByIds : ControllerBase
    {
        private readonly AppService _appService;
        public GetCommentByIds(AppService appService)
        {
            _appService = appService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetByCommentId([FromRoute] int commentId)
        {
            return Ok(await _appService.handler(commentId));
        }
    }
}
