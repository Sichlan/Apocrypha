using System.Windows;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.CommonObject.Services.AuthenticationServices;
using Apocrypha.EntityFramework;
using Apocrypha.EntityFramework.Services;
using Apocrypha.WPF.State.Navigators.Authenticators;
using Apocrypha.WPF.State.Navigators.Navigators;
using Apocrypha.WPF.State.Navigators.Users;
using Apocrypha.WPF.ViewModels;
using Apocrypha.WPF.ViewModels.Factories;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.WPF
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(c =>
                {
                    c.AddJsonFile("appsettings.json");
                    c.AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) =>
                {
                    #region Database

                    var connectionString = context.Configuration.GetConnectionString("mariadb");
                    services.AddDbContext<ApocryphaDbContext>(x => x.UseMySQL(connectionString));
                    services.AddSingleton(o => new ApocryphaDbContextFactory(connectionString));

                    services.AddSingleton<IAuthenticationService, AuthenticationService>();
                    services.AddSingleton<IDataService<User>, UserDataService>();
                    services.AddSingleton<IUserService, UserDataService>();

                    #endregion

                    #region APIs

                    #endregion

                    #region ViewModelFactories

                    services.AddSingleton<MainViewModel>();

                    services.AddSingleton<IApocryphaViewModelFactory, ApocryphaViewModelFactory>();
                    services.AddSingleton<HomeViewModel>();
                    services.AddSingleton<CharacterSelectionViewModel>();

                    services.AddSingleton<CreateViewModel<HomeViewModel>>(s => s.GetRequiredService<HomeViewModel>);
                    services.AddSingleton<CreateViewModel<CharacterSelectionViewModel>>(s => s.GetRequiredService<CharacterSelectionViewModel>);

                    #endregion

                    #region Delegates

                    services.AddSingleton<IPasswordHasher, PasswordHasher>();
                    services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();

                    #endregion

                    #region State

                    services.AddSingleton<INavigator, Navigator>();
                    services.AddSingleton<IAuthenticator, Authenticator>();
                    services.AddSingleton<IUserStore, UserStore>();

                    #endregion

                    #region Misc

                    //Keep this as empty as possible, this is just temporary, try to move any of these to their corresponding region
                    services.AddScoped(o => new MainWindow(o.GetRequiredService<MainViewModel>()));

                    #endregion
                });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}