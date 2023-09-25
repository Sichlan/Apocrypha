using System;
using System.Collections.Generic;
using System.Globalization;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Services.State;
using Apocrypha.ModernUi.Services.ViewModelConverter;
using Apocrypha.ModernUi.ViewModels;
using Apocrypha.ModernUi.ViewModels.Navigation;
using Apocrypha.ModernUi.ViewModels.Navigation.Editor;
using Apocrypha.ModernUi.ViewModels.Navigation.Tools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.ModernUi.ExtensionMethods.HostBuilder;

public static class AddViewModelsExtensionMethod
{
    public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            // Add view models to dependency injection
            services.AddScoped<HomeViewModel>();
            services.AddScoped<TestViewModel>();

            // Editor
            services.AddScoped<EditorHomeViewModel>();
            services.AddScoped<RaceEditorListViewModel>();
            services.AddTransient<RaceEditorViewModel>(s => CreateRaceEditorViewModel(s, null));

            // Tools
            services.AddScoped<PoisonCrafterListViewModel>();
            services.AddTransient<PoisonCrafterViewModel>(s => CreatePoisonCrafterViewModel(s, null));

            services.AddScoped(s => new MainViewModel(s.GetRequiredService<NavigateBackwardsCommand>(),
                s.GetRequiredService<NavigateForwardsCommand>(),
                s.GetRequiredService<HomeViewModel>(),
                s.GetRequiredService<INavigationService>(),
                s.GetRequiredService<IHost>()));

            // Creator Delegates
            services.AddSingleton<CreateRaceEditorViewModel>(s => race => CreateRaceEditorViewModel(s, race));
            services.AddSingleton<CreatePoisonCrafterViewModel>(s => poison => CreatePoisonCrafterViewModel(s, poison));

            // Add main window so it can be resolved in App.xaml.cs
            services.AddScoped<MainWindow>();
        });

        return hostBuilder;
    }

    private static RaceEditorViewModel CreateRaceEditorViewModel(IServiceProvider serviceProvider, Race race)
    {
        return new RaceEditorViewModel(race,
            serviceProvider.GetRequiredService<NavigateToPageCommand>(),
            serviceProvider.GetRequiredService<IDataService<Race>>(),
            serviceProvider.GetRequiredService<IDataService<CreatureType>>(),
            serviceProvider.GetRequiredService<IDataService<CreatureSubType>>(),
            serviceProvider.GetRequiredService<IDataService<CreatureSizeCategory>>(),
            serviceProvider.GetRequiredService<IDataService<RuleBook>>(),
            serviceProvider.GetRequiredService<IEnumerable<CultureInfo>>(),
            serviceProvider.GetRequiredService<IDataService<RaceTranslation>>());
    }

    private static PoisonCrafterViewModel CreatePoisonCrafterViewModel(IServiceProvider serviceProvider, Poison poison)
    {
        return serviceProvider.GetRequiredService<IViewModelConverter<PoisonCrafterViewModel, Poison>>().ToViewModel(poison);
    }
}