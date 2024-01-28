using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Blogs;
using SimpleBlog.Infrastructure.BlogDbContextConfiguration;
using System.Reflection;

namespace SimpleBlog.Infrastructure;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new PostConfiguration());
        //modelBuilder.ApplyConfiguration(new CommentConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Post> Tbl_Posts { get; set; }
    public DbSet<Comment> Tbl_Comments { get; set; }

}
