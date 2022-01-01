using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using System.Xml;
using Apocrypha.WPF.HostBuilders;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apocrypha.WPF
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    // ReSharper disable once RedundantExtendsListEntry
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddConfiguration(args)
                .AddDbContextConfiguration()
                .AddApiConfiguration()
                .AddViewModels()
                .AddStateConfiguration()
                .AddMiscelaneousConfiguration();
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

        protected override void OnStartup(StartupEventArgs e)
        {
            _host = CreateHostBuilder(e.Args).Build();
            _host.Start();
            
            LoadAvalonHighlighting();
            SetApplicationLanguage(_host.Services.GetRequiredService<IConfiguration>().GetSection("UserSettings:language").Value);

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
    }
}