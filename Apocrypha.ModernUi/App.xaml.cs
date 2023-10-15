using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Xml;
using Apocrypha.ModernUi.ExtensionMethods.HostBuilder;
using Apocrypha.ModernUi.Services.Configuration;
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

        protected override void OnStartup(StartupEventArgs e)
        {
            _host = CreateHostBuilder(e.Args).Build();
            _host.Start();

            LoadAvalonHighlighting();
            // SetApplicationLanguage(_host.Services.GetRequiredService<IConfiguration>().GetSection("UserSettings:language").Value);
            SetApplicationLanguage("en");

            // Load initialization
            var configService = _host.Services.GetRequiredService<IConfigurationService>();
            // configService.ApocryphaConfiguration.DesignConfiguration.ColorPreset = "LAVENDER";
            configService.InitializeConfiguration();

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        private void SetApplicationLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(new CultureInfo(language).IetfLanguageTag)));
        }

        protected override async void OnExit(ExitEventArgs e)
        {
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
        private void LoadAvalonHighlighting()
        {
            LoadSyntaxFromFile("Resources/DiceRoll.xshd", "DiceRoll");
        }

        private void LoadSyntaxFromFile(string path, string name)
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