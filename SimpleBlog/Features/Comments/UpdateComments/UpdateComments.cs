using Microsoft.AspNetCore.Mvc;

namespace SimpleBlog.Features.Comments.UpdateComments
{
    [ApiController]
    [Route("api/posts/comments")]
    public class UpdateComments : ControllerBase
    {
        private readonly AppService _appService;
        private readonly Validator _Validator;
        public UpdateComments(AppService appService, Validator validator)
        {
            _appService = appService;
            _Validator = validator;
        }

        [HttpPut("")]
        public async Task<ActionResult> Update(Input input, CancellationToken cancellationToken)
        {
            var validationResult = _Validator.Validate(input);
            if (validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }
            await _appService.handler(input, cancellationToken);
            return Ok();
        }
    }
}
