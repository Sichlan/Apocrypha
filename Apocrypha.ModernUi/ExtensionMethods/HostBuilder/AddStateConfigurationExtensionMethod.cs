using Apocrypha.CommonObject.Services.AuthenticationServices;
using Apocrypha.ModernUi.Services;
using Apocrypha.ModernUi.Services.State.Authenticators;
using Apocrypha.ModernUi.Services.State.Navigation;
using Apocrypha.ModernUi.Services.State.Users;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.ModernUi.ExtensionMethods.HostBuilder;

public static class AddStateConfigurationExtensionMethod
{
    public static IHostBuilder AddStateConfiguration(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IUserStore, UserStore>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IUserInformationMessageService, DebugUserInformationMessageService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IAuthenticator, Authenticator>();
        });

        return hostBuilder;
    }
}