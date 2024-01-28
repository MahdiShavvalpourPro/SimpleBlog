using SimpleBlog.Domain.Blogs;

namespace SimpleBlog.Features.Comments.CreateComments
{
    public class Input
    {
        public string Content { get; set; }
        public Post Post { get; set; }
    }
}
