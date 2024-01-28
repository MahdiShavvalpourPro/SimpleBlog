namespace SimpleBlog.Features.Posts.UpdatePosts;
public record Input
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}