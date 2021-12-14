using System;
using System.IO;
using System.Windows;
using System.Xml;
using Apocrypha.WPF.HostBuilders;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
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
            LoadAvalonHighlighting();
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddConfiguration()
                .AddDbContextConfiguration()
                .AddApiConfiguration()
                .AddViewModels()
                .AddStateConfiguration()
                .AddMiscelaneousConfiguration();
        }

        /// <summary>
        /// Initiates highlighting grammars for AvalonEdit.
        /// <a href="https://stackoverflow.com/questions/5057210/how-do-i-create-an-avalonedit-syntax-file-xshd-and-embed-it-into-my-assembly">Source</a>
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