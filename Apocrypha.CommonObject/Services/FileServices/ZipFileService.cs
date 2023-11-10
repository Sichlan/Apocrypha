using System.IO.Compression;
using Microsoft.Extensions.Logging;

namespace Apocrypha.CommonObject.Services.FileServices;

public class ZipFileService : IZipFileService
{
    private readonly ILogger<ZipFileService> _logger;

    public ZipFileService(ILogger<ZipFileService> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc/>
    public void CreateZipFile(string fileName, IEnumerable<string> files)
    {
        // Create and open a new ZIP file
        var zip = ZipFile.Open(fileName, ZipArchiveMode.Create);

        foreach (var file in files)
        {
            // Add the entry for each file
            zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
        }

        // Dispose of the object when we are done
        zip.Dispose();
    }

    public async Task CreateSimulationConfigurationArchive(string fileName, string configJson, string cellsLayer, string riversLayer, string routesLayer,
        string markersLayer, string settlementsLayer)
    {
        var outputDirectory = Path.GetDirectoryName(fileName);

        if (string.IsNullOrEmpty(outputDirectory)
            || !File.Exists(cellsLayer)
            || !File.Exists(riversLayer)
            || !File.Exists(routesLayer)
            || !File.Exists(markersLayer))
            throw new ArgumentException();

        var basePath = Path.GetTempPath() + $"EconomySimulator\\{Guid.NewGuid()}";

        try
        {
            var cellsPath = basePath + "\\cells";
            var riversPath = basePath + "\\rivers";
            var routesPath = basePath + "\\routes";
            var markersPath = basePath + "\\markers";
            var settlementsPath = basePath + "\\settlements";

            Directory.CreateDirectory(cellsPath);
            Directory.CreateDirectory(riversPath);
            Directory.CreateDirectory(routesPath);
            Directory.CreateDirectory(markersPath);
            Directory.CreateDirectory(settlementsPath);

            var configPath = basePath + "\\config.json";
            await File.WriteAllTextAsync(configPath, configJson);

            File.Copy(cellsLayer, cellsPath + "\\cells.geojson");
            File.Copy(riversLayer, riversPath + "\\rivers.geojson");
            File.Copy(routesLayer, routesPath + "\\routes.geojson");
            File.Copy(markersLayer, markersPath + "\\markers.geojson");
            File.Copy(settlementsLayer, settlementsPath + "\\settlements.geojson");

            Directory.CreateDirectory(outputDirectory);
            File.Delete(fileName);
            ZipFile.CreateFromDirectory(basePath, fileName);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in {Method}", nameof(CreateSimulationConfigurationArchive));
        }
        finally
        {
            Directory.Delete(basePath, true);
        }
    }

    public async Task ReadSimulationConfigurationArchive(string fileName, string outputPath)
    {
        if (!File.Exists(fileName))
            throw new ArgumentException();

        await Task.Yield();

        try
        {
            if (Directory.Exists(outputPath))
                Directory.Delete(outputPath, true);

            Directory.CreateDirectory(outputPath);
            ZipFile.ExtractToDirectory(fileName, outputPath);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error in {Method}", nameof(ReadSimulationConfigurationArchive));
        }
    }
}