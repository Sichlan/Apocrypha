using System;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.EntityFramework;
using Apocrypha.EntityFramework.Services;
using Apocrypha.EntityFramework.Services.Poisons;
using Apocrypha.ModernUi.Services.ViewModelConverter;
using Apocrypha.ModernUi.ViewModels.Navigation.Tools;
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
            services.AddScoped(_ => new ApocryphaDbContextFactory(ConfigureDbContext));

            // TODO: Add database services
            services.AddScoped<IDataService<Condition>, ConditionDataService>();
            services.AddScoped<IDataService<Race>, RaceDataService>();
            services.AddScoped<IDataService<RaceTranslation>, RaceTranslationDataService>();
            services.AddScoped<IDataService<CreatureType>, CreatureTypeDataService>();
            services.AddScoped<IDataService<CreatureSubType>, CreatureSubTypeDataService>();
            services.AddScoped<IDataService<CreatureSizeCategory>, CreatureSizeCategoryDataService>();
            services.AddScoped<IDataService<RuleBook>, RuleBookDataService>();
            services.AddScoped<IDataService<Poison>, PoisonDataService>();
            services.AddScoped<IDataService<PoisonPhase>, PoisonPhaseDataService>();
            services.AddScoped<IDataService<PoisonPhaseElement>, PoisonPhaseElementDataService>();
            services.AddScoped<IDataService<PoisonDeliveryMethod>, PoisonDeliveryMethodDataService>();
            services.AddScoped<IDataService<PoisonDuration>, PoisonDurationDataService>();
            services.AddScoped<IDataService<PoisonDamageTarget>, PoisonDamageTargetDataService>();
            services.AddScoped<IDataService<PoisonSpecialEffect>, PoisonSpecialEffectDataService>();

            // TODO: Add model converter
            services.AddScoped<IViewModelConverter<PoisonCrafterViewModel, Poison>, PoisonCrafterViewModelConverter>();
            services.AddScoped<IViewModelConverter<PoisonPhaseViewModel, PoisonPhase>, PoisonPhaseViewModelConverter>();
            services.AddScoped<IViewModelConverter<PoisonPhaseElementViewModel, PoisonPhaseElement>, PoisonPhaseElementViewModelConverter>();
        });

        return hostBuilder;
    }
}