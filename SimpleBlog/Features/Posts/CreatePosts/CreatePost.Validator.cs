using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Infrastructure;

namespace SimpleBlog.Features.Posts.CreatePosts;

public class Validator : AbstractValidator<Command>
{
    private readonly BlogDbContext _context;
    public Validator(BlogDbContext context)
    {
        _context = context;

        RuleFor(post => post.Title)
            .NotEmpty()
            .WithMessage("Title Is Required.")
            .MaximumLength(200)
            .WithMessage("Title must not exceed 200 characters.")
            .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");

        RuleFor(post => post.Content)
            .NotEmpty()
            .WithMessage("content Is Required.")
            .MaximumLength(500)
            .WithMessage("content must not exceed 500 characters.");
    }

    private async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return await _context.Tbl_Posts
            .AllAsync(t => t.Title != title, cancellationToken);
    }
}
