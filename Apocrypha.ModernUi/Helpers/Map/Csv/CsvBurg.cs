using System;
using System.Collections.Generic;
using NetTopologySuite.Features;

namespace Apocrypha.ModernUi.Helpers.Map.Csv;

public class CsvBurg
{
    public int Id { get; set; }
    public string Burg { get; set; }
    public string Province { get; set; }
    public string ProvinceFullName { get; set; }
    public string State { get; set; }
    public string StateFullName { get; set; }
    public string Culture { get; set; }
    public string Religion { get; set; }
    public int Population { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int Elevationm { get; set; }
    public string Capital { get; set; }
    public string Port { get; set; }
    public string Citadel { get; set; }
    public string Walls { get; set; }
    public string Plaza { get; set; }
    public string Temple { get; set; }
    public string ShantyTown { get; set; }
    public string CityGeneratorLink { get; set; }

    public AttributesTable GetAttributes()
    {
        var properties = typeof(CsvBurg).GetProperties();
        var attributes = new Dictionary<string, object>();

        foreach (var property in properties)
        {
            if (property.Name is nameof(Capital)
                or nameof(Port)
                or nameof(Citadel)
                or nameof(Walls)
                or nameof(Plaza)
                or nameof(Temple)
                or nameof(ShantyTown))
                attributes.Add(property.Name,
                    string.Equals((property.GetValue(this) ?? "").ToString(), property.Name, StringComparison.CurrentCultureIgnoreCase));
            else if (property.CanRead)
                attributes.Add(property.Name, property.GetValue(this));
        }

        return new AttributesTable(attributes);
    }
}