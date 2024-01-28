using FluentValidation;

namespace SimpleBlog.Features.Posts.UpdatePosts
{
    public class Validator : AbstractValidator<Input>
    {
        public Validator()
        {
            //RuleFor(post => post.Id)
            //    .NotEmpty()
            //    .WithMessage("Id Is Required .. ");

            RuleFor(post => post.Title)
                       .NotEmpty()
                       .WithMessage("Title Of Post Is Required ... ")
                       .Length(3, 100)
                       .WithMessage("should be count of characters title between 3 to 100 ");

            RuleFor(post => post.Content)
                .NotEmpty()
                .WithMessage("")
                .MaximumLength(500)
                .WithMessage("Title Of Post Is Required ... ");
        }
    }
}
