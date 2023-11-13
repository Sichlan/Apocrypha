using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using Apocrypha.CommonObject.Models.Simulation.Layers;
using Apocrypha.ModernUi.Themes.CustomControls;
using CommunityToolkit.Mvvm.Input;
using Mars.Components.Layers;
using Mars.Interfaces.Layers;
using ModernWpf.Controls;

namespace Apocrypha.ModernUi.Helpers.Map;

public class MapLayerElementVectorFeature : VectorFeature, INotifyPropertyChanged
{
    private readonly Type _layerType;

    public Type LayerType =>
        _layerType;

    public double CanvasLeft
    {
        get
        {
            switch (LayerType.Name)
            {
                case nameof(GisCellsLayer):
                case nameof(GisRiverLayer):
                case nameof(GisRoutesLayer):
                    return VectorStructured.Geometry.Boundary.Centroid.X;
                case nameof(GisMarkersLayer):
                case nameof(GisSettlementLayer):
                    return VectorStructured.Geometry.Centroid.X;
            }

            return default;
        }
    }

    public double CanvasTop
    {
        get
        {
            switch (LayerType.Name)
            {
                case nameof(GisCellsLayer):
                case nameof(GisRiverLayer):
                case nameof(GisRoutesLayer):
                    return VectorStructured.Geometry.Boundary.Centroid.Y;
                case nameof(GisMarkersLayer):
                case nameof(GisSettlementLayer):
                    return VectorStructured.Geometry.Centroid.Y;
            }

            return default;
        }
    }

    #region AttributeData

    public int Id => GetAttributeOrDefault<int>();
    public double Height => GetAttributeOrDefault<double>();
    public int Biome => GetAttributeOrDefault<int>();
    public string Type => GetAttributeOrDefault<string>();
    public int Population => GetAttributeOrDefault<int>();
    public int State => GetAttributeOrDefault<int>();
    public int Province => GetAttributeOrDefault<int>();
    public int Culture => GetAttributeOrDefault<int>();
    public int Religion => GetAttributeOrDefault<int>();

    private T GetAttributeOrDefault<T>([CallerMemberName] string attribute = "")
    {
        if (!VectorStructured.Data.TryGetValue(attribute.ToLower(), out var value))
            return default;

        if (value is T t)
            return t;

        try
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
        catch (InvalidCastException)
        {
            return default;
        }
    }

    #endregion

    /// <inheritdoc />
    private MapLayerElementVectorFeature(Type layerType)
    {
        _layerType = layerType;

        DisplayDataCommand = new RelayCommand(ExecuteDisplayDataCommand);
    }

    /// <inheritdoc />
    public MapLayerElementVectorFeature(Type layerType, IVectorFeature vectorFeature, double innerXMin, double innerXMax, double innerYMin,
        double innerYMax)
        : this(layerType)
    {
        VectorStructured = vectorFeature.VectorStructured;

        VectorStructured.Geometry.Apply(new CoordinateShiftFilter(innerXMin, innerYMin));
        VectorStructured.Geometry.GeometryChanged();

        // OnPropertyChanged(nameof(VectorStructured));
        // OnPropertyChanged(nameof(Stroke));
        // OnPropertyChanged(nameof(StrokeThickness));
        // OnPropertyChanged(nameof(Fill));
    }

    private void ExecuteDisplayDataCommand()
    {
        var dialog = new ContentDialog()
        {
            Title = _layerType.Name,
            Content = string.Join(Environment.NewLine, VectorStructured.Data.Select(x => $"{x.Key}: {x.Value}")),
            CloseButtonText = "TODO OK"
        };

        dialog.ShowAsync();
    }

    private static Brush GetLandColour(double height)
    {
        return height switch
        {
            >= 6300 => MapResourceFetcher.MapLandHeightMapBrush14,
            >= 5850 and < 6300 => MapResourceFetcher.MapLandHeightMapBrush13,
            >= 5400 and < 5850 => MapResourceFetcher.MapLandHeightMapBrush12,
            >= 4950 and < 5400 => MapResourceFetcher.MapLandHeightMapBrush11,
            >= 4500 and < 4950 => MapResourceFetcher.MapLandHeightMapBrush10,
            >= 3600 and < 4500 => MapResourceFetcher.MapLandHeightMapBrush9,
            >= 3150 and < 3600 => MapResourceFetcher.MapLandHeightMapBrush8,
            >= 2700 and < 3150 => MapResourceFetcher.MapLandHeightMapBrush7,
            >= 2250 and < 2700 => MapResourceFetcher.MapLandHeightMapBrush6,
            >= 1800 and < 2250 => MapResourceFetcher.MapLandHeightMapBrush5,
            >= 1350 and < 1800 => MapResourceFetcher.MapLandHeightMapBrush4,
            >= 900 and < 1350 => MapResourceFetcher.MapLandHeightMapBrush3,
            >= 450 and < 900 => MapResourceFetcher.MapLandHeightMapBrush2,
            >= 0 and < 450 => MapResourceFetcher.MapLandHeightMapBrush1,
            _ => Brushes.Transparent
        };
    }

    public Brush Stroke
    {
        get
        {
            return LayerType.Name switch
            {
                nameof(GisCellsLayer) => Type == "island" ? GetLandColour(Height) : Brushes.Transparent,
                nameof(GisRiverLayer) => MapResourceFetcher.MapWaterFillBrush,
                nameof(GisRoutesLayer) => Type switch
                {
                    "searoutes" => MapResourceFetcher.MapSeaRoutesBrush,
                    "trails" => MapResourceFetcher.MapTrailsBrush,
                    "roads" => MapResourceFetcher.MapRoutesBrush,
                    _ => Brushes.Transparent
                },
                nameof(GisMarkersLayer) => MapResourceFetcher.MapMarkerBrush,
                nameof(GisSettlementLayer) => MapResourceFetcher.MapSettlementBrush,
                _ => Brushes.Transparent
            };
        }
    }

    public double StrokeThickness
    {
        get
        {
            return LayerType.Name switch
            {
                nameof(GisCellsLayer) => Type == "island" ? .05 : 0,
                nameof(GisRiverLayer) => .05,
                nameof(GisRoutesLayer) => .05,
                _ => 0
            };
        }
    }

    public Brush Fill
    {
        get
        {
            return LayerType.Name switch
            {
                nameof(GisCellsLayer) => Type == "island" ? GetLandColour(Height) : Brushes.Transparent,
                nameof(GisRiverLayer) => null,
                nameof(GisRoutesLayer) => null,
                nameof(GisMarkersLayer) => MapResourceFetcher.MapMarkerBrush,
                nameof(GisSettlementLayer) => MapResourceFetcher.MapSettlementBrush,
                _ => null
            };
        }
    }

    public ICommand DisplayDataCommand { get; }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}