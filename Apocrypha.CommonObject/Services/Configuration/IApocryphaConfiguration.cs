namespace Apocrypha.CommonObject.Services.Configuration;

public interface IApocryphaConfiguration
{
    /// <summary>
    /// The AppData root folder.
    /// </summary>
    string AppDataRootDirectory { get; set; }

    string Language { get; set; }
    IDesignConfiguration DesignConfiguration { get; set; }
}