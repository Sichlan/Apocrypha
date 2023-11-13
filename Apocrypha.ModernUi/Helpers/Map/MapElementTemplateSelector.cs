using System.Windows;
using System.Windows.Controls;
using Apocrypha.CommonObject.Models.Simulation.Layers;

namespace Apocrypha.ModernUi.Helpers.Map;

/// <inheritdoc />
public class MapElementTemplateSelector : DataTemplateSelector
{
    public DataTemplate PolygonTemplate { get; set; }
    public DataTemplate LineTemplate { get; set; }
    public DataTemplate PointTemplate { get; set; }

    /// <inheritdoc />
    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        if (item is MapLayerElementVectorFeature mapLayerElementVectorFeature)
            return mapLayerElementVectorFeature.LayerType == typeof(GisCellsLayer) ? PolygonTemplate :
                mapLayerElementVectorFeature.VectorStructured.Geometry.Coordinates.Length > 1 ? LineTemplate : PointTemplate;

        return base.SelectTemplate(item, container);
    }
}