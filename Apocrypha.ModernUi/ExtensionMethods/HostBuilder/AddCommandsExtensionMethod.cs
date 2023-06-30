using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.ModernUi.ExtensionMethods.HostBuilder;

public static class AddCommandsExtensionMethod
{
    public static IHostBuilder AddCommands(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddScoped<NavigateToPageCommand>();
            services.AddScoped<NavigateBackwardsCommand>();
            services.AddScoped<NavigateForwardsCommand>();
        });

        return hostBuilder;
    }
}