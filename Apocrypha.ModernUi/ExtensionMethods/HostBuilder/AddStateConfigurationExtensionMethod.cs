using Apocrypha.ModernUi.Services.State;
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
        });

        return hostBuilder;
    }
}