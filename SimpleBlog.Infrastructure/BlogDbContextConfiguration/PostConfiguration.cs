using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBlog.Domain.Blogs;

namespace SimpleBlog.Infrastructure.BlogDbContextConfiguration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(200);

            builder.Property(x => x.CreationDate).HasMaxLength(12);
            builder.Property(x => x.ModificationDate).HasMaxLength(12);

            //Relation
            builder.HasMany(x => x.Comments)
                .WithOne(x => x.Post);

        }
    }
}
