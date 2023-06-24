using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.ModernUi.ExtensionMethods.HostBuilder;

public static class AddStaticValuesExtensionMethod
{
    public static IHostBuilder AddStaticValue(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<IEnumerable<CultureInfo>>(_ => new List<CultureInfo>(CultureInfo.GetCultures(CultureTypes.NeutralCultures)
                .Where(x => !Equals(x, CultureInfo.InvariantCulture))
                .OrderBy(x => x.EnglishName)));
        });

        return hostBuilder;
    }
}