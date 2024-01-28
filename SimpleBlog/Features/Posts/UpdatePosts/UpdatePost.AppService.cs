using SimpleBlog.Domain.Blogs;
using SimpleBlog.Infrastructure;

namespace SimpleBlog.Features.Posts.UpdatePosts
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
        private async Task<Post> FindPostAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Tbl_Posts
                .FindAsync(id, cancellationToken)
                .ConfigureAwait(false) ?? throw new ArgumentNullException(nameof(Post));
        }
        public async Task HandlerAsync(Input input, CancellationToken cancellationToken)
        {
            var entity = await FindPostAsync(input.Id, cancellationToken);
            entity.Update(input.Title, input.Content);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
