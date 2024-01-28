using SimpleBlog.Domain.Blogs;
using SimpleBlog.Infrastructure;

namespace SimpleBlog.Features.Comments.UpdateComments
{
    public class AppService
    {
        private readonly BlogDbContext _context;

        public AppService(BlogDbContext context)
        {
            _context = context;
        }

        public async Task handler(Input input, CancellationToken cancellationToken)
        {
            var comment = await FindCommentAsync(input.Id, cancellationToken);
            comment.Update(input.Content, new Post(input.Post.Title, input.Post.Content));
        }

        private async Task<Comment> FindCommentAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Tbl_Comments
                .FindAsync(id, cancellationToken)
                .ConfigureAwait(false) ?? throw new ArgumentNullException(nameof(Post));
        }
    }
}
