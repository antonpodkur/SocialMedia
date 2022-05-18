using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class HashtagConfiguration: IEntityTypeConfiguration<Hashtag>
{
    public void Configure(EntityTypeBuilder<Hashtag> builder)
    {
        builder.ToTable("Hashtags");

        builder.Property(h => h.Id).IsRequired();
        builder.Property(h => h.Name).IsRequired();
        
        builder.HasMany(h => h.Posts)
            .WithOne(ph => ph.Hashtag)
            .HasForeignKey(ph => ph.HashtagId)
            .HasPrincipalKey(h => h.Id);
    }
}