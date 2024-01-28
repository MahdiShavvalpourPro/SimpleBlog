using SimpleBlog.Domain.Blogs;
using SimpleBlog.Infrastructure;

namespace SimpleBlog.Features.Posts.CreatePosts;

public class AppService
{
    private readonly BlogDbContext _dbContext;

    public AppService(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> CreatePostAsync(Input input)
    {
        var post = new Post(input.Title, input.Content);
        _dbContext.Add(post);
        await _dbContext.SaveChangesAsync();
        return post.Id;
    }
}
