using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Blogs;
using SimpleBlog.Features.Posts.GetPostByIds;
using SimpleBlog.Infrastructure;

namespace SimpleBlog.Features.Posts.RemovePost
{
    public class AppService
    {
        private readonly BlogDbContext _context;
        private readonly ILogger<AppService> _logger;

        public AppService
            (
            BlogDbContext context,
            ILogger<AppService> logger
            )
        {
            _context = context;
            _logger = logger;
        }

        private async Task<Post> FindPostAsync(int postId, CancellationToken cancellationToken)
        {
            return await _context.Tbl_Posts
                .FindAsync(postId, cancellationToken)
                .ConfigureAwait(false) ?? throw new ArgumentNullException(nameof(Post));
        }

        public async Task<Response> handler(int id, CancellationToken cancellationToken)
        {
            var post = await FindPostAsync(id, cancellationToken);
            _context.Tbl_Posts.Remove(post);
            return await _context.SaveChangesAsync() > 0 ? new Response() { Success = true }
            : new Response() { Success = true };
        }
    }
}
