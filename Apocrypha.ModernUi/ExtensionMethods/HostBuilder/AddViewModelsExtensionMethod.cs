using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.CommonObject.Services.SimulationServices;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Services.State.Navigation;
using Apocrypha.ModernUi.Services.State.Users;
using Apocrypha.ModernUi.Services.UserInformationService;
using Apocrypha.ModernUi.Services.ViewModelConverter;
using Apocrypha.ModernUi.ViewModels;
using Apocrypha.ModernUi.ViewModels.Common;
using Apocrypha.ModernUi.ViewModels.Editor;
using Apocrypha.ModernUi.ViewModels.Navigation;
using Apocrypha.ModernUi.ViewModels.Tools;
using Apocrypha.ModernUi.ViewModels.Tools.MapSimulation;
using Apocrypha.ModernUi.ViewModels.Tools.PoisonCrafter;
using Apocrypha.ModernUi.ViewModels.Users;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.ModernUi.ExtensionMethods.HostBuilder;

public static class AddViewModelsExtensionMethod
{
    /// <summary>
    /// Extension Method that adds all navigable view models to the host builder.
    /// </summary>
    /// <param name="hostBuilder">The <see cref="IHostBuilder"/> to add the models to.</param>
    /// <returns>The <see cref="IHostBuilder"/> with the registered view models.</returns>
    public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            // Add view models to dependency injection
            services.AddScoped<HomeViewModel>();
            services.AddScoped<TestViewModel>();

            // Popups
            services.AddScoped<UserPopupViewModel>();

            // Settings
            services.AddScoped<SettingsViewModel>();

            // Editor
            services.AddScoped<EditorHomeViewModel>();
            services.AddScoped<RaceEditorListViewModel>();
            services.AddTransient(s => CreateRaceEditorViewModel(s, null));

            // Tools
            services.AddScoped<DiceRollerViewModel>();
            services.AddScoped<PoisonCrafterListViewModel>();
            services.AddScoped<MapSimulationMainViewModel>();
            services.AddTransient(s => CreatePoisonCrafterViewModel(s, null));

            services.AddScoped(s => new MainViewModel(s.GetRequiredService<NavigateBackwardsCommand>(),
                s.GetRequiredService<NavigateForwardsCommand>(),
                s.GetRequiredService<HomeViewModel>(),
                s.GetRequiredService<INavigationService>(),
                s.GetRequiredService<IHost>(),
                s.GetRequiredService<UserPopupViewModel>(),
                s.GetRequiredService<IUserInformationMessageService>()));

            // Creator Delegates
            services.AddSingleton<CreateViewModel<PoisonCrafterViewModel>>(s => () => CreatePoisonCrafterViewModel(s));
            services.AddSingleton<CreateViewModel<MapMainViewModel>>(s => () => CreateMapMainViewModel(s));

            services.AddSingleton<CreateRaceEditorViewModel>(s => race => CreateRaceEditorViewModel(s, race));
            services.AddSingleton<CreatePoisonCrafterViewModel>(s => poison => CreatePoisonCrafterViewModel(s, poison));
            services.AddSingleton<CreateUserMessageViewModel>(s =>
                (message, type, after, details) => CreateUserMessageViewModel(s, message, type, after, details));

            // Add main window so it can be resolved in App.xaml.cs
            services.AddScoped<MainWindow>();
        });

        return hostBuilder;
    }

    private static MapMainViewModel CreateMapMainViewModel(IServiceProvider serviceProvider)
    {
        return new MapMainViewModel(serviceProvider.GetRequiredService<ISimulationContainerService>(),
            serviceProvider.GetRequiredService<IUserInformationMessageService>());
    }

    private static PoisonCrafterViewModel CreatePoisonCrafterViewModel(IServiceProvider serviceProvider)
    {
        return new PoisonCrafterViewModel(serviceProvider.GetRequiredService<NavigateToPageCommand>(),
            serviceProvider.GetRequiredService<IDataService<Poison>>(),
            serviceProvider.GetRequiredService<IViewModelConverter<PoisonCrafterViewModel, Poison>>(),
            serviceProvider.GetRequiredService<IDataService<PoisonDeliveryMethod>>(),
            serviceProvider.GetRequiredService<IDataService<Condition>>(),
            serviceProvider.GetRequiredService<IDataService<PoisonDuration>>(),
            serviceProvider.GetRequiredService<IDataService<PoisonDamageTarget>>(),
            serviceProvider.GetRequiredService<IDataService<PoisonSpecialEffect>>(),
            serviceProvider.GetRequiredService<IDataService<PoisonPhase>>(),
            serviceProvider.GetRequiredService<INavigationService>(),
            serviceProvider.GetRequiredService<IUserStore>(),
            serviceProvider.GetRequiredService<NavigateBackwardsCommand>(),
            serviceProvider.GetRequiredService<IUserInformationMessageService>(),
            serviceProvider.GetRequiredService<IDataService<PoisonPhaseElement>>());
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

    private static UserMessageViewModel CreateUserMessageViewModel(IServiceProvider s, string message, InformationType type, int? after, string details)
    {
        return new UserMessageViewModel(message, type, after, details,
            s.GetRequiredService<IUserInformationMessageService>());
    }
}