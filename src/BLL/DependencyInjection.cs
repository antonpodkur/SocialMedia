using BLL.Abstractions;
using BLL.AutoMapperProfiles;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL;

public static class DependencyInjection
{
    public static void AddBll(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(HashtagProfile), typeof(PostProfile), typeof(TopicProfile), typeof(UserProfile));
        services.AddTransient<IHashtagService, HashtagService>();
        services.AddTransient<IPostService, PostService>();
        services.AddTransient<ITopicService, TopicService>();
        services.AddTransient<IUserService, UserService>();
    }
}