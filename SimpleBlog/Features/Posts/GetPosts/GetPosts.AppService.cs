using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Infrastructure;
using System.Data;
using System.Runtime.CompilerServices;

namespace SimpleBlog.Features.Posts.GetPosts
{
    public class AppService
    {
        //private readonly BlogDbContext _context;
        //private readonly IMapper _mapper;
        private readonly IDbConnection _connection;
        private readonly ILogger<AppService> _logger;
        public AppService(
            //BlogDbContext context,
            //IMapper mapper,
            IDbConnection connection
            , ILogger<AppService> logger
            )
        {
            //_context = context;
            //_mapper = mapper;
            _connection = connection;
            _logger = logger;
        }

        public async Task<IEnumerable<Response>> Handler()
        {
            var posts = await _connection
               .QueryAsync<Response>("SELECT title,content FROM Tbl_Posts");
            if (posts is null)
            {
                _logger.LogInformation("Post table is empty");
            }
            return posts!;
        }

    }
}
