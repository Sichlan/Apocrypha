using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Services.Configuration;
using Apocrypha.ModernUi.Helpers.Map.Csv;
using CsvHelper;
using NetTopologySuite.Features;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json;

namespace Apocrypha.ModernUi.Services.Map;

/// <inheritdoc />
public class ExportCsvToGeoJsonsService : IExportCsvToGeoJsonsService
{
    private readonly IConfigurationService _configurationService;

    public ExportCsvToGeoJsonsService(IConfigurationService configurationService)
    {
        _configurationService = configurationService;
    }

    /// <inheritdoc />
    public async Task<string> ConvertFile(string path)
    {
        if (!File.Exists(path))
            throw new ArgumentException();

        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        using var stringWriter = new StringWriter();
        using var jsonWriter = new JsonTextWriter(stringWriter);

        csv.Context.RegisterClassMap<CsvBurgClassMap>();
        var burgs = csv.GetRecords<CsvBurg>();

        var gf = new GeometryFactory();
        var features = new FeatureCollection();

        foreach (var burg in burgs)
        {
            var geometry = gf.CreatePoint(new Coordinate(burg.Longitude, burg.Latitude));
            var feature = new Feature(geometry, burg.GetAttributes());
            features.Add(feature);
        }

        var serializer = GeoJsonSerializer.Create();
        serializer.Serialize(jsonWriter, features);
        var geoJson = stringWriter.ToString();

        var filePath = $"{_configurationService.GetTempDirectoryPath()}burg{DateTime.Now:yyyy-MM-dd-hh-mm-ss-fff}.geojson";
        await File.WriteAllTextAsync(filePath, geoJson);

        return filePath;
    }
}