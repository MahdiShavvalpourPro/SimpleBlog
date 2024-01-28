using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Infrastructure;

namespace SimpleBlog.Features.Comments.RemoveComments
{
    public class Command : IRequest
    {
        public int Id { get; set; }
    }

    public class CommandHandler : IRequestHandler<Command>
    {
        private readonly BlogDbContext _context;

        public CommandHandler(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var entity = await _context
                .Tbl_Comments
                .Where(x => x.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken) ?? throw new Exception("Error ... ");

            _context.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
