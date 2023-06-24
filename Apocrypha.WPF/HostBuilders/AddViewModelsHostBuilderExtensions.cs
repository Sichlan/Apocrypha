using System.Globalization;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.WPF.State.Authenticators;
using Apocrypha.WPF.State.Characters;
using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.State.Popups;
using Apocrypha.WPF.State.Races;
using Apocrypha.WPF.ViewModels;
using Apocrypha.WPF.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.WPF.HostBuilders;

public static class AddViewModelsHostBuilderExtensions
{
    public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddTransient(s => CreateMainViewModel(s));


            #region ViewModels

            // Important: Register viewmodels that have no explicit creation method like login or register viewmodel
            // These view models will be retrieved with s.GetRequiredService<VIEWMODEL>
            // Models retrieved via creation method MUST NOT BE ADDED HERE! 
            services.AddTransient<HomeViewModel>();
            services.AddTransient<CharacterSelectionViewModel>();
            services.AddTransient<CharacterProfileViewModel>();
            services.AddTransient<DiceRollerViewModel>();
            services.AddTransient<SpellCardEditorViewModel>();

            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegistrationViewModel>();

            #endregion

            #region Delegates

            services.AddSingleton<CreateViewModel<HomeViewModel>>(s => s.GetRequiredService<HomeViewModel>);
            services.AddSingleton<CreateViewModel<CharacterSelectionViewModel>>(s => s.GetRequiredService<CharacterSelectionViewModel>);
            services.AddSingleton<CreateViewModel<CharacterProfileViewModel>>(s => s.GetRequiredService<CharacterProfileViewModel>);
            services.AddSingleton<CreateViewModel<DiceRollerViewModel>>(s => s.GetRequiredService<DiceRollerViewModel>);
            services.AddSingleton<CreateViewModel<SpellCardEditorViewModel>>(s => s.GetRequiredService<SpellCardEditorViewModel>);

            services.AddSingleton<CreateViewModel<RaceEditorViewModel>>(s => () => CreateRaceEditorViewModel(s));
            services.AddSingleton<CreateViewModel<RaceListViewModel>>(s => () => CreateRaceListViewModel(s));
            services.AddSingleton<CreateViewModel<LoginViewModel>>(s => () => s.GetRequiredService<LoginViewModel>());
            services.AddSingleton<CreateViewModel<RegistrationViewModel>>(s => () => s.GetRequiredService<RegistrationViewModel>());

            #endregion

            services.AddSingleton<IApocryphaViewModelFactory, ApocryphaViewModelFactory>();

            #region IRenavigators

            services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<CharacterSelectionViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<CharacterProfileViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<RegistrationViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<DiceRollerViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<RaceEditorViewModel>>();
            services.AddSingleton<ViewModelDelegateRenavigator<RaceListViewModel>>();

            #endregion
        });

        return hostBuilder;
    }

    private static MainViewModel CreateMainViewModel(IServiceProvider service)
    {
        return new MainViewModel(service.GetRequiredService<IAuthenticator>(),
            service.GetRequiredService<INavigator>(),
            service.GetRequiredService<IApocryphaViewModelFactory>(),
            service.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
            service.GetRequiredService<ICharacterStore>(),
            service.GetRequiredService<IShowGlobalPopupService>());
    }

    private static RaceEditorViewModel CreateRaceEditorViewModel(IServiceProvider service)
    {
        return new RaceEditorViewModel(service.GetRequiredService<IRaceStore>(),
            service.GetRequiredService<ViewModelDelegateRenavigator<RaceListViewModel>>(),
            service.GetRequiredService<IDataService<Race>>(),
            service.GetRequiredService<IDataService<CreatureType>>(),
            service.GetRequiredService<IDataService<CreatureSubType>>(),
            service.GetRequiredService<IDataService<CreatureSizeCategory>>(),
            service.GetRequiredService<IDataService<RuleBook>>(),
            service.GetRequiredService<IShowGlobalPopupService>(),
            service.GetRequiredService<IEnumerable<CultureInfo>>(),
            service.GetRequiredService<IDataService<RaceTranslation>>());
    }

    private static RaceListViewModel CreateRaceListViewModel(IServiceProvider service)
    {
        return new RaceListViewModel(service.GetRequiredService<IDataService<Race>>(),
            service.GetRequiredService<IRaceStore>(),
            service.GetRequiredService<ViewModelDelegateRenavigator<RaceEditorViewModel>>());
    }
}