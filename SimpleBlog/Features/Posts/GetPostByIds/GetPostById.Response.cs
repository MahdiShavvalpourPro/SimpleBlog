namespace SimpleBlog.Features.Posts.GetPostByIds;

public record Response
{
    public int Id { get; init; }
    public string Title { get; init; } = default!;
    public string Content { get; init; } = default!;
}
