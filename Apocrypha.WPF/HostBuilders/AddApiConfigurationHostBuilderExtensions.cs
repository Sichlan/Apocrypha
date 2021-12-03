using Microsoft.Extensions.Hosting;

namespace Apocrypha.WPF.HostBuilders
{
    public static class AddApiConfigurationHostBuilderExtensions
    {
        public static IHostBuilder AddApiConfiguration(this IHostBuilder hostBuilder)
        {
            // Currently empty because no APIs are being used so far...

            return hostBuilder;
        }
    }
}