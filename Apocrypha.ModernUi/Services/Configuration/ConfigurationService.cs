using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using Apocrypha.CommonObject.Services.Configuration;
using Apocrypha.ModernUi.Helpers;
using Apocrypha.ModernUi.Themes.Presets;
using ModernWpf;

namespace Apocrypha.ModernUi.Services.Configuration;

/// <inheritdoc />
public class ConfigurationService : IConfigurationService
{
    /// <inheritdoc />
    public IApocryphaConfiguration ApocryphaConfiguration { get; set; }

    public ConfigurationService(IApocryphaConfiguration apocryphaConfiguration)
    {
        ApocryphaConfiguration = apocryphaConfiguration;
    }

    /// <inheritdoc />
    public void InitializeConfiguration()
    {
        if (string.IsNullOrEmpty(ApocryphaConfiguration.AppDataRootDirectory))
            ApocryphaConfiguration.AppDataRootDirectory = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Apocrypha\\";

        if (string.IsNullOrEmpty(ApocryphaConfiguration.Language))
            ApocryphaConfiguration.Language = "en";
        SetApplicationLanguage(ApocryphaConfiguration.Language);

        InitializeDesign(ApocryphaConfiguration.DesignConfiguration);
    }

    /// <inheritdoc />
    public string GetTempDirectoryPath()
    {
        var path = $"{ApocryphaConfiguration.AppDataRootDirectory}temp\\";

        Directory.CreateDirectory(path);

        return path;
    }

    /// <inheritdoc />
    public void DeleteTempDirectoryPath()
    {
        Directory.Delete(GetTempDirectoryPath(), true);
    }

    private static void SetApplicationLanguage(string language)
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
        Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
        FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
            new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(new CultureInfo(language).IetfLanguageTag)));
    }

    private static void InitializeDesign(IDesignConfiguration designConfiguration)
    {
        DispatcherHelper.RunOnMainThread(() =>
        {
            if (string.IsNullOrEmpty(designConfiguration.ColorPreset))
                designConfiguration.ColorPreset = "Default";

            PresetManager.Current.ColorPreset = designConfiguration.ColorPreset;
            ThemeManager.Current.ApplicationTheme = designConfiguration.ApplicationTheme;
        });
    }
}