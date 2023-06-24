using Apocrypha.ModernUi.Services.State;
using Apocrypha.ModernUi.ViewModels;
using Apocrypha.ModernUi.ViewModels.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.ModernUi.ExtensionMethods.HostBuilder;

public static class AddViewModelsExtensionMethod
{
    public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            // Add view models to dependency injection
            services.AddScoped<HomeViewModel>();
            services.AddScoped<TestViewModel>();
            services.AddScoped(s => new MainViewModel(s.GetRequiredService<INavigationService>(),
                s.GetRequiredService<HomeViewModel>(),
                s.GetRequiredService<IHost>()));

            // Add main window so it can be resolved in App.xaml.cs
            services.AddScoped<MainWindow>();
        });

        return hostBuilder;
    }
}