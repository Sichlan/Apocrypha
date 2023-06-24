using System;
using Apocrypha.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.ModernUi.ExtensionMethods.HostBuilder;

public static class AddDbContextConfigurationExtensionMethod
{
    public static IHostBuilder AddDbContextConfiguration(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices((context, services) =>
        {
            var connectionStringName = "ApocryphaDb";
            var connectionString = context.Configuration.GetConnectionString(connectionStringName);

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException($"Could not resolve a connection string for '{connectionStringName}' from appsettings!");

            void ConfigureDbContext(DbContextOptionsBuilder o)
            {
                o.UseMySql(connectionString!, new MySqlServerVersion(new Version(8, 0, 29)));
            }

            // Configure DB service for migrations
            services.AddDbContext<ApocryphaDbContext>(ConfigureDbContext);

            // Configure DB service for runtime
            services.AddSingleton(_ => new ApocryphaDbContextFactory(ConfigureDbContext));

            // TODO: Add database services
        });

        return hostBuilder;
    }
}