using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AdminSSO.EntityFrameworkCore;

public class AdminSSOHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<AdminSSOHttpApiHostMigrationsDbContext>
{
    public AdminSSOHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AdminSSOHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("AdminSSO"));

        return new AdminSSOHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
