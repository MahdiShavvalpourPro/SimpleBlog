using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBlog.Domain.Blogs;

namespace SimpleBlog.Infrastructure.BlogDbContextConfiguration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Content).HasMaxLength(500);

            builder.Property(x => x.CreationDate).HasMaxLength(12);
            builder.Property(x => x.ModificationDate).HasMaxLength(12);
        }
    }
}
