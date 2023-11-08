namespace Apocrypha.CommonObject.Services.Configuration;

/// <summary>
/// Manages local user configuration, mostly user settings from <see cref="SettingsViewModel"/>.
/// </summary>
/// <remarks>Uses <a href="https://github.com/aloneguid/config">Config.net</a> to read, store and write settings.</remarks>
public interface IConfigurationService
{
    /// <summary>
    /// The ConfigurationTreeRoot.
    /// </summary>
    IApocryphaConfiguration ApocryphaConfiguration { get; set; }

    /// <summary>
    /// Method called to apply all settings to the application. Automatically called at startup in <see cref="App.OnStartup"/>.
    /// </summary>
    void InitializeConfiguration();
}