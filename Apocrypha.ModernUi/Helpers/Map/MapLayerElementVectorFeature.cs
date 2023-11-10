using System;
using System.Windows.Media;
using Apocrypha.CommonObject.Models.Simulation.Layers;
using Apocrypha.ModernUi.Themes.CustomControls;
using Mars.Components.Layers;
using Mars.Interfaces.Layers;

namespace Apocrypha.ModernUi.Helpers.Map;

public class MapLayerElementVectorFeature : VectorFeature
{
    private readonly Type _layerType;

    public double CanvasLeft
    {
        get
        {
            switch (_layerType.Name)
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
            switch (_layerType.Name)
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

    /// <inheritdoc />
    public MapLayerElementVectorFeature(Type layerType)
    {
        _layerType = layerType;
    }

    /// <inheritdoc />
    public MapLayerElementVectorFeature(Type layerType, IVectorFeature vectorFeature, double innerXMin, double innerXMax, double innerYMin,
        double innerYMax)
        : this(layerType)
    {
        VectorStructured = vectorFeature.VectorStructured;

        VectorStructured.Geometry.Apply(new CoordinateShiftFilter(innerXMin, innerYMin));
        VectorStructured.Geometry.GeometryChanged();
    }

    public Brush Stroke
    {
        get
        {
            switch (_layerType.Name)
            {
                case nameof(GisCellsLayer):
                    if (VectorStructured.Data.TryGetValue("type", out var value) && value.ToString() == "island")
                        return MapResourceFetcher.MapLandFillBrush;

                    return Brushes.Transparent;

                case nameof(GisRiverLayer):
                    return MapResourceFetcher.MapWaterFillBrush;

                case nameof(GisRoutesLayer):
                    if (!VectorStructured.Data.TryGetValue("type", out var type))
                        return Brushes.Transparent;

                    switch (type)
                    {
                        case "searoutes":
                            return MapResourceFetcher.MapSeaRoutesBrush;
                        case "trails":
                            return MapResourceFetcher.MapTrailsBrush;
                        case "roads":
                            return MapResourceFetcher.MapRoutesBrush;
                    }

                    return Brushes.Transparent;

                case nameof(GisMarkersLayer):
                    return MapResourceFetcher.MapMarkerBrush;

                case nameof(GisSettlementLayer):
                    return MapResourceFetcher.MapSettlementBrush;
            }

            return Brushes.Transparent;
        }
    }

    public Brush Fill
    {
        get
        {
            switch (_layerType.Name)
            {
                case nameof(GisCellsLayer):
                    if (VectorStructured.Data.TryGetValue("type", out var value) && value.ToString() == "island")
                        return MapResourceFetcher.MapLandFillBrush;

                    return Brushes.Transparent;

                case nameof(GisRiverLayer):
                    return Brushes.Transparent;

                case nameof(GisRoutesLayer):
                    return Brushes.Transparent;

                case nameof(GisMarkersLayer):
                    return MapResourceFetcher.MapMarkerBrush;

                case nameof(GisSettlementLayer):
                    return MapResourceFetcher.MapSettlementBrush;
            }

            return Brushes.Transparent;
        }
    }

    public double StrokeThickness
    {
        get
        {
            switch (_layerType.Name)
            {
                case nameof(GisCellsLayer):
                    if (VectorStructured.Data.TryGetValue("type", out var value) && value.ToString() == "island")
                        return 0;

                    return 0;

                case nameof(GisRiverLayer):
                    return .05;

                case nameof(GisRoutesLayer):
                    return .05;
            }

            return 0;
        }
    }
}