using MediatR;
using SimpleBlog.Domain.Blogs;

namespace SimpleBlog.Features.Comments.CreateComments
{
    public class Command : IRequest<int>
    {
        public string Content { get; set; }
        public Post Post { get; set; }
    }
}
