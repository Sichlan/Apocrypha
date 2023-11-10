namespace Apocrypha.CommonObject.Services.FileServices;

public interface IZipFileService
{
    /// <summary>
    /// Create a ZIP file of the files provided.
    /// </summary>
    /// <param name="fileName">The full path and name to store the ZIP file at.</param>
    /// <param name="files">The list of files to be added.</param>
    public void CreateZipFile(string fileName, IEnumerable<string> files);

    public Task CreateSimulationConfigurationArchive(string fileName, string configJson, string cellsLayer, string riversLayer, string routesLayer,
        string markersLayer, string settlementsLayer);

    public Task ReadSimulationConfigurationArchive(string fileName, string outputPath);
}