using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class PostConfiguration: IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");

        builder.Property(p => p.Id).IsRequired();
        builder.HasIndex(p => p.Id).IsUnique();

        builder.Property(p => p.Title).IsRequired().HasMaxLength(400);
        builder.Property(p => p.Body).IsRequired().HasMaxLength(40000);

        builder.Property(p => p.Date).IsRequired();

        builder.HasMany(p => p.Topics);
        builder.HasMany(p => p.Hashtags);
    }
}