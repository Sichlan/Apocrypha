using Apocrypha.WPF.State.Authenticators;
using Apocrypha.WPF.State.Characters;
using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.State.PopupService;
using Apocrypha.WPF.State.Races;
using Apocrypha.WPF.State.Users;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.WPF.HostBuilders
{
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
            });

            return hostBuilder;
        }
    }
}