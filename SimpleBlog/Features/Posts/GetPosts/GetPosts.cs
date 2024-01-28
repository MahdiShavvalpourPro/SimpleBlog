using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Features.Posts.GetPosts
{
    [ApiController]
    [Route("/api/posts")]
    public class GetPosts : ControllerBase
    {
        private readonly AppService _appService;

        public GetPosts(AppService appService)
        {
            _appService = appService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Response>>> GetAllPost()
        {
            return Ok(await _appService.Handler());
        }
    }
}
