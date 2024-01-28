using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace SimpleBlog.Features.Posts.RemovePost
{
    [ApiController]
    [Route("api/posts")]
    public class RemovePost : ControllerBase
    {
        private readonly AppService _appService;

        public RemovePost(AppService appService)
        {
            _appService = appService;
        }

        [HttpDelete("{/id}")]
        public async Task<Response> Delete(int id, CancellationToken cancellationToken)
        {
            return await _appService.handler(id, cancellationToken);
        }
    }
}
