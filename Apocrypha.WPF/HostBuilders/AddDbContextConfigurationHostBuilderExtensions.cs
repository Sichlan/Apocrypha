using System;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Spells;
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
                    "Development" => context.Configuration.GetConnectionString("mysql_development"),
                    "Staging" => context.Configuration.GetConnectionString("mysql_staging"),
                    _ => context.Configuration.GetConnectionString("mysql_productive")
                };

                void ConfigureDbContext(DbContextOptionsBuilder o)
                {
                    o.UseMySql(connectionString, new MySqlServerVersion(new Version(8,0,29)));
                }

                // Configure DB service for migrations
                services.AddDbContext<ApocryphaDbContext>(ConfigureDbContext);

                // Configure DB service for runtime
                services.AddSingleton(o => new ApocryphaDbContextFactory(ConfigureDbContext));

                services.AddSingleton<IAuthenticationService, AuthenticationService>();
                services.AddSingleton<IDataService<Allignment>, AllignmentDataService>();
                services.AddSingleton<IDataService<Character>, CharacterDataService>();
                services.AddSingleton<IDataService<User>, UserDataService>();
                services.AddSingleton<IDataService<Race>, RaceDataService>();
                services.AddSingleton<IUserService, UserDataService>();
                
                #region Spells

                services.AddSingleton<IDataService<SpellSchool>, SpellSchoolDataService>();

                #endregion
            });

            return hostBuilder;
        }
    }
}