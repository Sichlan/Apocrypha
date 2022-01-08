using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.CommonObject.Services.AuthenticationServices;
using Apocrypha.EntityFramework;
using Apocrypha.EntityFramework.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.WPF.HostBuilders
{
    public static class AddDbContextConfigurationHostBuilderExtension
    {
        public static IHostBuilder AddDbContextConfiguration(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                // Retrieve the DB connection string from appsettings.json
                var connectionString = context.HostingEnvironment.EnvironmentName switch
                {
                    "Test" => context.Configuration.GetConnectionString("mariadb-test"),
                    _ => context.Configuration.GetConnectionString("mariadb-live")
                };

                void ConfigureDbContext(DbContextOptionsBuilder o)
                {
                    o.UseMySQL(connectionString);
                }

                // Configure DB service for migrations
                services.AddDbContext<ApocryphaDbContext>(ConfigureDbContext);

                // Configure DB service for runtime
                services.AddSingleton(o => new ApocryphaDbContextFactory(ConfigureDbContext));

                services.AddSingleton<IAuthenticationService, AuthenticationService>();
                services.AddSingleton<IDataService<Allignment>, AllignmentDataService>();
                services.AddSingleton<IDataService<Character>, CharacterDataService>();
                services.AddSingleton<IDataService<User>, UserDataService>();
                services.AddSingleton<IUserService, UserDataService>();
            });

            return hostBuilder;
        }
    }
}