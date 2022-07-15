using System;
using Apocrypha.CommonObject.Services.DiceRollerServices;
using Apocrypha.WPF.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.WPF.HostBuilders
{
    public static class AddMiscellaneousConfigurationHostBuilderExtension
    {
        public static IHostBuilder AddMiscellaneousConfiguration(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                //Keep this as empty as possible, this is just temporary, try to move any of these to their corresponding extension
                services.AddSingleton<IPasswordHasher, PasswordHasher>();
                services.AddSingleton<Random>();
                services.AddSingleton<IDiceRollerService, DiceRollerService>();
                services.AddSingleton(o => new MainWindow(o.GetRequiredService<MainViewModel>()));
            });

            return hostBuilder;
        }
    }
}