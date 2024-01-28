using MediatR;
using SimpleBlog.Domain.Blogs;
using SimpleBlog.Infrastructure;

namespace SimpleBlog.Features.Posts.CreatePosts
{
    public class CommandHandler : IRequestHandler<Command, int>
    {
        private readonly BlogDbContext _dbContext;
        public CommandHandler(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(Command request, CancellationToken cancellationToken)
        {
            var post = new Post(request.Title, request.Content);

            _dbContext.Add(post);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return post.Id;
        }
    }
}
