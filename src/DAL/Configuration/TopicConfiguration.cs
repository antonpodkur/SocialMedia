using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class TopicConfiguration: IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.ToTable("Topics");

        builder.Property(t => t.Id).IsRequired();
        builder.Property(t => t.Name).IsRequired();
    }
}