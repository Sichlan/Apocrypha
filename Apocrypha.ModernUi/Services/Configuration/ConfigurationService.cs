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
        InitializeDesign(ApocryphaConfiguration.DesignConfiguration);
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