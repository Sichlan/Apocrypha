using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Apocrypha.CommonObject.Models;
using Apocrypha.EntityFramework;
using Apocrypha.WPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
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
                    services.AddSingleton<ApocryphaDbContextFactory>(o => new ApocryphaDbContextFactory(connectionString));

                    #endregion

                    #region APIs

                    

                    #endregion

                    #region ViewModelFactories

                    services.AddSingleton<MainViewModel>();

                    #endregion

                    #region Delegates

                    

                    #endregion

                    #region State

                    

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