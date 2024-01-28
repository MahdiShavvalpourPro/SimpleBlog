using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Blogs;
using SimpleBlog.Infrastructure;

namespace SimpleBlog.Features.Comments.CreateComments
{
    public class Validator : AbstractValidator<Input>
    {
        private readonly BlogDbContext _context;
        public Validator(BlogDbContext context)
        {
            _context = context;

            RuleFor(x => x.Post)
                .NotEmpty()
                .WithMessage("Post Is Required")
                .MustAsync(PostIsExist)
                .WithMessage("This post does not exist at all");

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Content is required")
                .MaximumLength(400)
                .WithMessage("content must not exceed 400 characters.");
        }

        private async Task<bool> PostIsExist(Post post, CancellationToken cancellationToken)
        {
            return await _context
                .Tbl_Posts
                .AnyAsync(post => post.Id == post.Id, cancellationToken);
        }
    }
}
