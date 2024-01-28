using MediatR;
using SimpleBlog.Domain.Blogs;
using SimpleBlog.Infrastructure;

namespace SimpleBlog.Features.Comments.CreateComments
{
    public class CommandHandler : IRequestHandler<Command, int>
    {
        private readonly BlogDbContext _Context;

        public CommandHandler(BlogDbContext context)
        {
            _Context = context;
        }

        public async Task<int> Handle(Command request, CancellationToken cancellationToken)
        {
            Comment comment = new(request.Content, new Post(request.Post.Title, request.Post.Content));
            await _Context.Tbl_Comments.AddAsync(comment);
            await _Context.SaveChangesAsync();
            return comment.Id;

        }
    }
}
