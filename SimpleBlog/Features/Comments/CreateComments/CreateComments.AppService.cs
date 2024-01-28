using SimpleBlog.Domain.Blogs;
using SimpleBlog.Infrastructure;

namespace SimpleBlog.Features.Comments.CreateComments
{
    public class AppService
    {
        private readonly BlogDbContext _context;
        private readonly ILogger _logger;

        public AppService(BlogDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> Handler(Input input)
        {
            var post = new Post(input.Post.Title, input.Post.Content);
            var content = new Comment(input.Content, post);
            await _context.Tbl_Comments.AddAsync(content);
            if (await _context.SaveChangesAsync() > 0)
                return content.Id;

            _logger.LogInformation("Error ... " + typeof(AppService).Namespace);
            return 0;
        }

    }
}
