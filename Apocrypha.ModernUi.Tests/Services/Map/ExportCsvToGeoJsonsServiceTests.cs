using Apocrypha.CommonObject.Services.Configuration;
using Apocrypha.ModernUi.Services.Map;
using Moq;
using NUnit.Framework;

namespace Apocrypha.ModernUi.Tests.Services.Map;

public class ExportCsvToGeoJsonsServiceTests
{
    private IExportCsvToGeoJsonsService _service;

    [SetUp]
    public void Setup()
    {
        var serviceMock = new Mock<IConfigurationService>();
        serviceMock.Setup(x => x.GetTempDirectoryPath()).Returns($"{Directory.GetCurrentDirectory()}\\TestData\\Config\\temp\\");

        _service = new ExportCsvToGeoJsonsService(serviceMock.Object);
    }

    [Test]
    [Ignore("Used for test driven development")]
    public async Task TestDrivenDevelopment()
    {
        var path = await _service.ConvertFile("TestData\\burgs.csv");
    }
}