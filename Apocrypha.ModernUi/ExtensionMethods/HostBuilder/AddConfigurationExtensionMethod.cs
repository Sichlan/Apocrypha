using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.ModernUi.ExtensionMethods.HostBuilder;

public static class AddConfigurationExtensionMethod
{
    public static IHostBuilder AddConfiguration(this IHostBuilder hostBuilder, string[] args)
    {
        hostBuilder.ConfigureHostConfiguration(builder =>
            {
                if (args != null)
                {
                    builder.AddCommandLine(args);
                }
            })
            .ConfigureAppConfiguration((builder, config) =>
            {
                // config.AddJsonFile("appsettings.json", false, true);
                config.AddJsonFile($"appsettings.{builder.HostingEnvironment.EnvironmentName}.json", true, true);

                config.AddEnvironmentVariables();
            });

        return hostBuilder;
    }
}