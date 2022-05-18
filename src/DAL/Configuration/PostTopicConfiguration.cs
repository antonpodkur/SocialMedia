using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration;

public class PostTopicConfiguration: IEntityTypeConfiguration<PostTopic>
{
    public void Configure(EntityTypeBuilder<PostTopic> builder)
    {
        builder.ToTable("PostTopic");
    }
}