using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Services.State.Navigation;
using Apocrypha.ModernUi.Services.ViewModelConverter;
using Apocrypha.ModernUi.ViewModels;
using Apocrypha.ModernUi.ViewModels.Editor;
using Apocrypha.ModernUi.ViewModels.Navigation;
using Apocrypha.ModernUi.ViewModels.Tools;
using Apocrypha.ModernUi.ViewModels.Users;
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

            // Popups
            services.AddScoped<UserPopupViewModel>();

            // Editor
            services.AddScoped<EditorHomeViewModel>();
            services.AddScoped<RaceEditorListViewModel>();
            services.AddTransient(s => CreateRaceEditorViewModel(s, null));

            // Tools
            services.AddScoped<PoisonCrafterListViewModel>();
            services.AddTransient(s => CreatePoisonCrafterViewModel(s, null));

            services.AddScoped(s => new MainViewModel(s.GetRequiredService<NavigateBackwardsCommand>(),
                s.GetRequiredService<NavigateForwardsCommand>(),
                s.GetRequiredService<HomeViewModel>(),
                s.GetRequiredService<INavigationService>(),
                s.GetRequiredService<IHost>(),
                s.GetRequiredService<UserPopupViewModel>()));

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
        PoisonCrafterViewModel viewModel = null;

        Task.WaitAll(Task.Run(async () =>
            viewModel = await serviceProvider.GetRequiredService<IViewModelConverter<PoisonCrafterViewModel, Poison>>()
                .ToViewModel(poison)));

        return viewModel;
    }
}