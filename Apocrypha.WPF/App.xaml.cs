using System.Windows;
using Apocrypha.WPF.HostBuilders;
using Apocrypha.WPF.State.Navigators.Authenticators;
using Apocrypha.WPF.State.Navigators.Navigators;
using Apocrypha.WPF.State.Navigators.Users;
using Apocrypha.WPF.ViewModels;
using Apocrypha.WPF.ViewModels.Factories;
using Microsoft.AspNet.Identity;
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
                .AddConfiguration()
                .AddDbContextConfiguration()
                .AddApiConfiguration()
                .AddViewModels()
                .ConfigureServices((services) =>
                {
                    #region Delegates

                    #endregion

                    #region State

                    services.AddSingleton<INavigator, Navigator>();
                    services.AddSingleton<IAuthenticator, Authenticator>();
                    services.AddSingleton<IUserStore, UserStore>();

                    #endregion

                    #region Misc

                    //Keep this as empty as possible, this is just temporary, try to move any of these to their corresponding region
                    services.AddSingleton<IPasswordHasher, PasswordHasher>();
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