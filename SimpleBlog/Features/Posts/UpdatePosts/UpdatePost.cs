using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Features.Posts.UpdatePosts
{
    [ApiController]
    [Route("api/posts")]
    public class UpdatePost : ControllerBase
    {
        private readonly AppService _appService;
        private readonly Validator _validator;

        public UpdatePost(
            AppService appService,
            Validator validator)
        {
            _appService = appService;
            _validator = validator;
        }

        [HttpPut]
        public async Task<ActionResult> Handler([FromBody] Input input, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(input);
            if (validationResult.IsValid is false)
            {
                return BadRequest(validationResult.ToDictionary());
            }
            await _appService.HandlerAsync(input, cancellationToken);
            return NoContent();
        }
    }
}
