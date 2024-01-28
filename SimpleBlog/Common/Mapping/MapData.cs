using AutoMapper;
using SimpleBlog.Domain.Blogs;

namespace SimpleBlog.Common.Mapping
{
    public class MapData : Profile
    {
        public MapData()
        {
            CreateMap<Post, Features.Posts.GetPosts.Response>().ReverseMap();
        }
    }
}
