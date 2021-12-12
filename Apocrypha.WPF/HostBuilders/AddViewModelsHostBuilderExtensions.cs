using System;
using Apocrypha.CommonObject.Services.DiceRollerServices;
using Apocrypha.WPF.State.Navigators.Authenticators;
using Apocrypha.WPF.State.Navigators.Navigators;
using Apocrypha.WPF.ViewModels;
using Apocrypha.WPF.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<MainViewModel>(s => CreateMainViewModel(s));

                services.AddSingleton<IApocryphaViewModelFactory, ApocryphaViewModelFactory>();
                services.AddSingleton<HomeViewModel>();
                services.AddSingleton<CharacterSelectionViewModel>();
                services.AddSingleton<LoginViewModel>();
                services.AddSingleton<RegistrationViewModel>();
                services.AddSingleton<DiceRollerViewModel>();

                services.AddSingleton<CreateViewModel<HomeViewModel>>(s => s.GetRequiredService<HomeViewModel>);
                services.AddSingleton<CreateViewModel<CharacterSelectionViewModel>>(s => s.GetRequiredService<CharacterSelectionViewModel>);
                services.AddSingleton<CreateViewModel<LoginViewModel>>(s => () => CreateLoginViewModel(s));
                services.AddSingleton<CreateViewModel<RegistrationViewModel>>(s => () => CreateRegistrationViewModel(s));
                services.AddSingleton<CreateViewModel<DiceRollerViewModel>>(s => () => CreateDiceRollerViewModel(s));

                services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<CharacterSelectionViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<RegistrationViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<DiceRollerViewModel>>();
            });

            return hostBuilder;
        }

        private static DiceRollerViewModel CreateDiceRollerViewModel(IServiceProvider service)
        {
            return new DiceRollerViewModel(service.GetRequiredService<IDiceRollerService>());
        }

        private static MainViewModel CreateMainViewModel(IServiceProvider service)
        {
            return new MainViewModel(service.GetRequiredService<IAuthenticator>(),
                service.GetRequiredService<INavigator>(),
                service.GetRequiredService<IApocryphaViewModelFactory>(),
                service.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>());
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider service)
        {
            return new LoginViewModel(service.GetRequiredService<IAuthenticator>(),
                service.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
                service.GetRequiredService<ViewModelDelegateRenavigator<RegistrationViewModel>>());
        }

        private static RegistrationViewModel CreateRegistrationViewModel(IServiceProvider s)
        {
            return new RegistrationViewModel(s.GetRequiredService<IAuthenticator>(),
                s.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                s.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>());
        }
    }
}