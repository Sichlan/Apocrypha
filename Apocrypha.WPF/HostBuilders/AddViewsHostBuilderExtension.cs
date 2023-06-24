using Apocrypha.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.WPF.HostBuilders;

public static class AddViewsHostBuilderExtension
{
    public static IHostBuilder AddViews(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddTransient<LoginView>();
            services.AddTransient<RegistrationView>();
            services.AddTransient<HomeView>();
            services.AddTransient<CharacterSelectionView>();
        });

        return hostBuilder;
    }
}