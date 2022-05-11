using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasMany(u => u.Posts).WithOne(p => p.Author)
            .HasForeignKey(p => p.AuthorId).HasPrincipalKey(u => u.Id);
    }
}