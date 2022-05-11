using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.Context;

public class TestContextFactory: IDesignTimeDbContextFactory<TestContext>
{
    public TestContext CreateDbContext(string[] args)
    {
        AppConfiguration appConfiguration = new AppConfiguration();
        var opsBuilder = new DbContextOptionsBuilder<TestContext>();
        opsBuilder.UseMySql(appConfiguration.SqlConnectionString, ServerVersion.AutoDetect(appConfiguration.SqlConnectionString));
        Console.WriteLine(appConfiguration.SqlConnectionString);
        return new TestContext(opsBuilder.Options);
    }
}