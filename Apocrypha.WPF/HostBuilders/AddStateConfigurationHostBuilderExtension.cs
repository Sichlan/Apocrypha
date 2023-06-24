using Apocrypha.WPF.Services;
using Apocrypha.WPF.State.Authenticators;
using Apocrypha.WPF.State.Characters;
using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.State.Popups;
using Apocrypha.WPF.State.Races;
using Apocrypha.WPF.State.UserMessage;
using Apocrypha.WPF.State.Users;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Services;

namespace Apocrypha.WPF.HostBuilders;

public static class AddStateConfigurationHostBuilderExtension
{
    public static IHostBuilder AddStateConfiguration(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IUserStore, UserStore>();
            services.AddSingleton<ICharacterStore, CharacterStore>();
            services.AddSingleton<IRaceStore, RaceStore>();
            services.AddSingleton<IShowGlobalPopupService, ShowGlobalPopupService>();
            services.AddSingleton<IUserMessageService, MessageBoxUserMessageService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();
        });

        return hostBuilder;
    }
}