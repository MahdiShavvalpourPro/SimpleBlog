namespace SimpleBlog.Domain.Blogs;

public class Comment : Base
{
    public Comment(string content, Post post)
    {
        Content = content;
        Post = post;
    }
    public string Content { get; private set; }
    public Post Post { get; private set; }

    public void Update(string content, Post post)
    {
        Content = content;
        Post = post;
    }
}
