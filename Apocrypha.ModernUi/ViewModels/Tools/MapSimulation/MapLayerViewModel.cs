using System.Collections.Generic;
using System.Linq;
using Apocrypha.ModernUi.Helpers.Map;
using Apocrypha.ModernUi.ViewModels.Common;
using Mars.Components.Layers;

namespace Apocrypha.ModernUi.ViewModels.Tools.MapSimulation;

public class MapLayerViewModel : BaseViewModel
{
    private double _innerXMin;
    private double _innerXMax;
    private double _innerYMin;
    private double _innerYMax;
    private bool _isVisible;
    private VectorLayer _gisLayer;

    /// <summary>
    /// Determines whether this layer should be visible on the map or not.
    /// </summary>
    public bool IsVisible
    {
        get => _isVisible;
        set
        {
            if (value == _isVisible)
                return;

            _isVisible = value;
            OnPropertyChanged();
        }
    }

    public double Width => -_innerXMin + _innerXMax;
    public double Height => -_innerYMin + _innerYMax;

    /// <summary>
    /// The name of this layer.
    /// </summary>
    public virtual string LayerName => GisLayer.GetType().Name;

    public VectorLayer GisLayer
    {
        get => _gisLayer;
        set
        {
            if (Equals(value, _gisLayer))
                return;

            _gisLayer = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(LayerName));
            OnPropertyChanged(nameof(Elements));
        }
    }

    public List<MapLayerElementVectorFeature> Elements => GetElements();

    /// <inheritdoc />
    public MapLayerViewModel(VectorLayer gisLayer, double innerXMin, double innerXMax, double innerYMin, double innerYMax)
    {
        GisLayer = gisLayer;

        _innerXMin = innerXMin;
        _innerXMax = innerXMax;
        _innerYMin = innerYMin;
        _innerYMax = innerYMax;

        IsVisible = true;
    }

    private List<MapLayerElementVectorFeature> GetElements()
    {
        return GisLayer.Features.Select(x => new MapLayerElementVectorFeature(GisLayer.GetType(), x, _innerXMin, _innerXMax, _innerYMin, _innerYMax))
            .ToList();
    }
}