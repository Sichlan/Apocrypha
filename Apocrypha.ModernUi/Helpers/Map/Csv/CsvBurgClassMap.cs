using CsvHelper.Configuration;

namespace Apocrypha.ModernUi.Helpers.Map.Csv;

/// <inheritdoc />
public class CsvBurgClassMap : ClassMap<CsvBurg>
{
    /// <inheritdoc />
    public CsvBurgClassMap()
    {
        Map(m => m.Id).Name("Id");
        Map(m => m.Burg).Name("Burg");
        Map(m => m.Province).Name("Province");
        Map(m => m.ProvinceFullName).Name("Province Full Name");
        Map(m => m.State).Name("State");
        Map(m => m.StateFullName).Name("State Full Name");
        Map(m => m.Culture).Name("Culture");
        Map(m => m.Religion).Name("Religion");
        Map(m => m.Population).Name("Population");
        Map(m => m.X).Name("X");
        Map(m => m.Y).Name("Y");
        Map(m => m.Latitude).Name("Latitude");
        Map(m => m.Longitude).Name("Longitude");
        Map(m => m.Elevationm).Name("Elevation (m)");
        Map(m => m.Capital).Name("Capital");
        Map(m => m.Port).Name("Port");
        Map(m => m.Citadel).Name("Citadel");
        Map(m => m.Walls).Name("Walls");
        Map(m => m.Plaza).Name("Plaza");
        Map(m => m.Temple).Name("Temple");
        Map(m => m.ShantyTown).Name("Shanty Town");
        Map(m => m.CityGeneratorLink).Name("City Generator Link");
    }
}