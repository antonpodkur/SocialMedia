using DAL.Configuration;
using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public class TestContext: IdentityDbContext<User>
{
    public class OptionsBuild
    {
        public OptionsBuild()
        {
            Settings = new AppConfiguration();
            OpsBuilder = new DbContextOptionsBuilder<TestContext>();
            OpsBuilder.UseMySql(ServerVersion.AutoDetect(Settings.SqlConnectionString));
            DbOptions = OpsBuilder.Options;
        }
            
            
        public DbContextOptionsBuilder<TestContext> OpsBuilder { get; set; }
        public DbContextOptions<TestContext> DbOptions { get; set; }
        public AppConfiguration Settings { get; set; }
    }
    
    public TestContext(DbContextOptions<TestContext> options) : base(options) {}
    
    public static OptionsBuild ops = new OptionsBuild();

    public DbSet<Post> Posts { get; set; }
    public DbSet<Hashtag> Hashtags { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<PostHashtag> PostHashtags { get; set; }
    public DbSet<PostTopic> PostTopics { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new PostConfiguration());
        builder.ApplyConfiguration(new TopicConfiguration());
        builder.ApplyConfiguration(new HashtagConfiguration());
        builder.ApplyConfiguration(new PostTopicConfiguration());
        builder.ApplyConfiguration(new PostHashtagConfiguration());
    }
}