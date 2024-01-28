namespace SimpleBlog.Domain.Blogs;

public class Post : Base
{
    public Post(string title, string content)
    {
        Title = title;
        Content = content;
    }


    public string Title { get; private set; }
    public string Content { get; private set; }
    public List<Comment> Comments { get; private set; } = new();

    public void Update(string title, string content)
    {
        Title = title;
        Content = content;
    }
}
