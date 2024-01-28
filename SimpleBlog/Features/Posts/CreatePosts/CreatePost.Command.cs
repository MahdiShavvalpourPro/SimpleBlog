using MediatR;

namespace SimpleBlog.Features.Posts.CreatePosts
{
    public class Command : IRequest<int>
    {
        public string Title { get; init; } = default!;
        public string Content { get; init; } = default!;
    }
}
