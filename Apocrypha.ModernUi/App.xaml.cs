using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using System.Xml;
using Apocrypha.CommonObject.Services.Configuration;
using Apocrypha.ModernUi.ExtensionMethods.HostBuilder;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.ModernUi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private IHost _host;

        // ReSharper disable once MemberCanBePrivate.Global
        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddConfiguration(args)
                .AddDbContextConfiguration()
                .AddStaticValue()
                .AddViewModels()
                .AddCommands()
                .AddStateConfiguration();
        }

        /// <inheritdoc />
        protected override void OnStartup(StartupEventArgs e)
        {
            _host = CreateHostBuilder(e.Args).Build();
            _host.Start();

            LoadAvalonHighlighting();

            // Load initialization
            var configService = _host.Services.GetRequiredService<IConfigurationService>();
            configService.InitializeConfiguration();

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        /// <inheritdoc />
        protected override async void OnExit(ExitEventArgs e)
        {
            var configurationService = _host.Services.GetRequiredService<IConfigurationService>();
            configurationService.DeleteTempDirectoryPath();

            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }

        /// <summary>
        ///     Initiates highlighting grammars for AvalonEdit.
        ///     <a href="https://stackoverflow.com/questions/5057210/how-do-i-create-an-avalonedit-syntax-file-xshd-and-embed-it-into-my-assembly">
        ///         Source
        ///     </a>
        /// </summary>
        private static void LoadAvalonHighlighting()
        {
            LoadSyntaxFromFile("Resources/DiceRoll.xshd", "DiceRoll");
        }

        private static void LoadSyntaxFromFile(string path, string name)
        {
            var contents = File.ReadAllBytes(path);

            using var stream = new MemoryStream(contents);
            using var reader = new XmlTextReader(stream);

            HighlightingManager.Instance.RegisterHighlighting(name, Array.Empty<string>(), HighlightingLoader.Load(reader, HighlightingManager.Instance));
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
#if DEBUG
            Debugger.Break();
#endif
            // TODO: Add Logger
        }
    }
}