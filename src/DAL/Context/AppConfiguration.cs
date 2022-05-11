using Microsoft.Extensions.Configuration;

namespace DAL.Context;

public class AppConfiguration
{
    public string SqlConnectionString { get;}
    
    public AppConfiguration()
    {
        var configBuilder = new ConfigurationBuilder();
        var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
        configBuilder.AddJsonFile(path, false);
        var root = configBuilder.Build();
        var appsettings = root.GetSection("ConnectionStrings:Default");
        SqlConnectionString = appsettings.Value;
    }
}