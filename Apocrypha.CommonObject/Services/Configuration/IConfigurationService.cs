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

    /// <summary>
    /// Creates and returns the path to the app's temp directory based on <see cref="ApocryphaConfiguration"/>'s <see cref="IApocryphaConfiguration.AppDataRootDirectory"/>.
    /// </summary>
    /// <returns>The temp directory followed by '\' (example: "C:\Users\test\AppData\Roaming\Apocrypha\temp\")</returns>
    string GetTempDirectoryPath();

    /// <summary>
    /// Deletes the temporary directory if it exists.
    /// </summary>
    void DeleteTempDirectoryPath();
}