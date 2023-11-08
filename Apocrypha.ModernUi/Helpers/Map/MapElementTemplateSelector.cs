using System.Windows;
using System.Windows.Controls;

namespace Apocrypha.ModernUi.Helpers.Map;

/// <inheritdoc />
public class MapElementTemplateSelector : DataTemplateSelector
{
    public DataTemplate LineTemplate { get; set; }
    public DataTemplate PointTemplate { get; set; }

    /// <inheritdoc />
    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        if (item is MapLayerElementVectorFeature mapLayerElementVectorFeature)
            return mapLayerElementVectorFeature.VectorStructured.Geometry.Coordinates.Length > 1 ? LineTemplate : PointTemplate;

        return base.SelectTemplate(item, container);
    }
}