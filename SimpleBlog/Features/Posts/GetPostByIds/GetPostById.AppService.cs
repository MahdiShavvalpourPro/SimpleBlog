using Dapper;
using System.Data;

namespace SimpleBlog.Features.Posts.GetPostByIds;
public class AppService
{
    private readonly IDbConnection _connection;
    private readonly ILogger<AppService> _logger;

    public AppService(
        IDbConnection connection, ILogger<AppService> logger)
    {
        _connection = connection;
        _logger = logger;
    }

    public async Task<Response> Handler(int id)
    {
        var result = await _connection.QueryFirstAsync<Response>(
            "SELECT Id, Title, Content FROM Tbl_Posts");
        if (result is null)
        {
            _logger.LogInformation($"post with id {id} not found" + typeof(AppService).Namespace);
            return new Response()
            {
                Id = 0,
                Title = "",
                Content = ""
            };
        }
        return result;
        //var post = await _dbContext.Posts.FindAsync(id)
        //	?? throw new Exception("Not Found");
        //return new Response
        //{
        //	Id = post.Id,
        //	Title = post.Title,
        //	Content = post.Content,
        //};
    }
}
