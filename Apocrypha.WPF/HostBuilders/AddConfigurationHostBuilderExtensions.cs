using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.WPF.HostBuilders
{
    public static class AddConfigurationHostBuilderExtensions
    {
        public static IHostBuilder AddConfiguration(this IHostBuilder hostBuilder, string[] args)
        {
            hostBuilder
                .ConfigureHostConfiguration(builder =>
                {
                    builder.AddCommandLine(args);
                })
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", true, true);
                    //config.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", true, true);
                    config.AddEnvironmentVariables();
                });

            return hostBuilder;
        }
    }
}