namespace SimpleBlog.Infrastructure;

public class BlogDbContextSeedData
{
    public static async Task SeedSampleDataAsync(BlogDbContext dbContext)
    {
        //Seed , id necessary !!!

        if (!dbContext.Tbl_Posts.Any())
        {
            await dbContext.Tbl_Posts.AddAsync(
                new Domain.Blogs.Post("Test Post", "My Lorem .... This project is trying to be implemented with \r\nvertical slice architecture and cqrs pattern ."));
        }
    }
}
