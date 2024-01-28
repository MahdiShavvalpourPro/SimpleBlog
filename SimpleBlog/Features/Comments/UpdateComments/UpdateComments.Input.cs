using SimpleBlog.Domain.Blogs;

namespace SimpleBlog.Features.Comments.UpdateComments
{
    public class Input
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Post Post { get; set; }
    }
}
