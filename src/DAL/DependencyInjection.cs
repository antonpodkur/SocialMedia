using DAL.Abstractions.Repository;
using DAL.Abstractions.UnitOfWork;
using DAL.Context;
using DAL.Entities;
using DAL.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL;

public static class DependencyInjection
{
    public static void AddDal(this IServiceCollection services)
    {
        var config = new AppConfiguration();
        services.AddDbContext<TestContext>(options => options.UseMySql(config.SqlConnectionString ,ServerVersion.AutoDetect(config.SqlConnectionString)));
        services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<TestContext>().AddDefaultTokenProviders();
        services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IPostRepository, PostRepository>();
        services.AddTransient<ITopicRepository, TopicRepository>();
        services.AddTransient<IHashtagRepository, HashtagRepository>();
    }
}