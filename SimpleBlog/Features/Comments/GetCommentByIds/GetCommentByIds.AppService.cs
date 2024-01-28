using Dapper;
using System.Data;

namespace SimpleBlog.Features.Comments.GetComments
{
    public class AppService
    {
        //private readonly BlogDbContext _Context;
        private readonly IDbConnection _connection;
        private readonly ILogger<AppService> _logger;
        public AppService(
            //BlogDbContext context,
            IDbConnection Connection,
            ILogger<AppService> logger
            )
        {
            //_Context = context;
            _connection = Connection;
            _logger = logger;
        }

        public async Task<Response> handler(int id)
        {
            var result = await _connection.QueryFirstAsync<Response>(
                "SELECT Context FROM Tbl_Comments");
            if (result is null)
            {
                _logger.LogInformation($"comment with id {id} not found");
                return null;
            }
            return result;
        }

    }
}
