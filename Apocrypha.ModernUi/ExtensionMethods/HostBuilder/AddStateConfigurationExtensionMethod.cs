using System;
using System.IO;
using Apocrypha.CommonObject.Services.AuthenticationServices;
using Apocrypha.CommonObject.Services.Configuration;
using Apocrypha.CommonObject.Services.DiceRollerServices;
using Apocrypha.CommonObject.Services.FileServices;
using Apocrypha.CommonObject.Services.SimulationServices;
using Apocrypha.ModernUi.Services.Configuration;
using Apocrypha.ModernUi.Services.Randomizer;
using Apocrypha.ModernUi.Services.State.Authenticators;
using Apocrypha.ModernUi.Services.State.Navigation;
using Apocrypha.ModernUi.Services.State.Users;
using Apocrypha.ModernUi.Services.UserInformationService;
using Config.Net;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.ModernUi.ExtensionMethods.HostBuilder;

public static class AddStateConfigurationExtensionMethod
{
    public static IHostBuilder AddStateConfiguration(this IHostBuilder hostBuilder)
    {
        string configPath = $"{Directory.GetCurrentDirectory()}\\config.json";

        Directory.CreateDirectory(Path.GetDirectoryName(configPath) ?? throw new NullReferenceException($"Cannot get path from {configPath}"));

        if (!File.Exists(configPath))
            using (var file = File.CreateText(configPath))
            {
                file.WriteLine("{}");
            }

        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IUserStore, UserStore>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IUserInformationMessageService, ViewModelUserInformationMessageService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddSingleton<IZipFileService, ZipFileService>();
            services.AddSingleton<ISimulationContainerService, SimulationContainerService>();

            services.AddSingleton<Random>();
            services.AddSingleton<IDiceRollerService, DiceRollerService>();
            services.AddSingleton<IPoisonRandomizerService, PoisonRandomizerService>();

            services.AddSingleton(_ => new ConfigurationBuilder<IApocryphaConfiguration>().UseJsonFile(configPath).Build());
            services.AddSingleton<IConfigurationService, ConfigurationService>();
        });

        return hostBuilder;
    }
}