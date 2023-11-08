using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Apocrypha.CommonObject.Models.Simulation.Layers;
using Apocrypha.ModernUi.Services.UserInformationService;
using Mars.Components.Layers;
using Mars.Interfaces.Data;
using Mars.Interfaces.Layers;
using NetTopologySuite.Geometries;
using Point = System.Windows.Point;

namespace Apocrypha.ModernUi.CustomControls;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class DrawVectorLayerFrameworkElement<T> : DrawLayerFrameworkElement where T : VectorLayer
{
    private T _gisLayer;

    private double _innerXMin;
    private double _innerXMax;
    private double _innerYMin;
    private double _innerYMax;

    public DrawVectorLayerFrameworkElement(T gisVectorLayer, double outerXMin, double outerXMax, double outerYMin, double outerYMax,
        Func<IVectorFeature, bool> vectorSkipPredicate, Func<IVectorFeature, Brush> vectorFillColourPredicate, Func<IVectorFeature, Pen> vectorPenPredicate,
        IUserInformationMessageService userInformationMessageService)
        : base(outerXMin, outerXMax, outerYMin, outerYMax, vectorSkipPredicate, vectorFillColourPredicate, vectorPenPredicate,
            userInformationMessageService)
    {
        _gisLayer = gisVectorLayer;
    }

    /// <summary>
    /// Renders the active layer.
    /// </summary>
    protected override async Task RenderGisLayerAsync()
    {
        // Well if there's no layer to render...
        if (_gisLayer == null)
            return;

        await Task.Yield();

        // the outer min / max fields are already set as base corner points for the canvas
        // calculate inner min / max:
        _innerXMin = _gisLayer.Features.Min(x => x.VectorStructured.Geometry.Coordinates.Min(y => y.X));
        _innerXMax = _gisLayer.Features.Max(x => x.VectorStructured.Geometry.Coordinates.Max(y => y.X));
        _innerYMin = _gisLayer.Features.Min(x => x.VectorStructured.Geometry.Coordinates.Min(y => y.Y));
        _innerYMax = _gisLayer.Features.Max(x => x.VectorStructured.Geometry.Coordinates.Max(y => y.Y));

        // calculate scale factor to properly align the canvas
        double scaleFactorX = ActualWidth / (OuterXMax - OuterXMin),
            scaleFactorY = ActualHeight / (OuterYMax - OuterYMin),
            scaleFactor = Math.Min(scaleFactorX, scaleFactorY);

        // calculate new origin point because gis files reach into negative values, while canvas only allows positives
        var xDifference = 0 - _innerXMin;
        var yDifference = 0 - _innerYMin;

        // iterate through all vector features in the current layer
        foreach (var vectorFeature in _gisLayer.Features)
        {
            // Invoke the skip predicate to see if the vector should be drawn or not.
            // A return value of true means the vector should be skipped
            if (VectorSkipPredicate.Invoke(vectorFeature))
                continue;

            // Instantiate a new VectorFeatureDrawingVisual that can provide a drawing context
            var vectorFeatureDrawingVisual = new VectorFeatureDrawingVisual(vectorFeature);
            var streamGeometry = new StreamGeometry();

            // Activate the drawing and geometry contexts to draw the vector
            using (var drawingContext = vectorFeatureDrawingVisual.RenderOpen())
            using (var geometryContext = streamGeometry.Open())
            {
                // Find the first coordinate to start the figure at:
                var firstCoordinate = vectorFeature.VectorStructured.Geometry.Coordinates.First();
                geometryContext.BeginFigure(CalculatePoint(firstCoordinate, xDifference, yDifference, scaleFactor), _gisLayer is GisCellsLayer,
                    _gisLayer is GisCellsLayer);

                // Add all other points into a drawable point collection.
                // Skip the first point, since it is already included in firstCoordinate
                var points = new PointCollection();

                foreach (var geometryCoordinate in vectorFeature.VectorStructured.Geometry.Coordinates.Skip(1))
                {
                    points.Add(CalculatePoint(geometryCoordinate, xDifference, yDifference, scaleFactor));
                }

                geometryContext.PolyLineTo(points, true, true);

                // Draw the streamGeometry on the drawingContext and invoke both VectorFillColourPredicate and VectorPenPredicate for the geometry's style
                drawingContext.DrawGeometry(VectorFillColourPredicate.Invoke(vectorFeature), VectorPenPredicate.Invoke(vectorFeature), streamGeometry);
            }

            _visualCollection.Add(vectorFeatureDrawingVisual);
        }

#if DEBUG
        // If the application is debugged, also draw a border around the min and max values and a border around the original origin of the layer.
        // The center point in this case should align wit all other center points across layers.
        // _visualCollection.Add(DrawDebugBorder(xDifference, yDifference, scaleFactor));
        // _visualCollection.Add(DrawDebugCenterPoint(xDifference, yDifference, scaleFactor));
#endif

        UpdateLayout();
    }

    /// <summary>
    /// Calculates where a point from a coordinate would be located on the canvas, factoring in 
    /// </summary>
    /// <param name="coordinate"></param>
    /// <param name="xDifference"></param>
    /// <param name="yDifference"></param>
    /// <param name="scaleFactor"></param>
    /// <returns></returns>
    private Point CalculatePoint(Coordinate coordinate, double xDifference, double yDifference, double scaleFactor)
    {
        // Calculate the X and Y center point from
        double xCenter = (OuterXMax - OuterXMin) / 2 + OuterXMin,
            yCenter = (OuterYMax - OuterYMin) / 2 + OuterYMin;

        // Calculates the offset from both axis that must be factored in to center all of this layer's points.
        // Done by calculating the canvas' center point, this layer's center point scaled up to the canvas, and then calculate the difference so it can be added to the point.
        double offsetX = ActualWidth / 2 - (xCenter - _innerXMin) * scaleFactor,
            offsetY = ActualHeight / 2 - (yCenter - _innerYMin) * scaleFactor;

        // So, order of operation is:
        // - normalize the coordinate by adding the calculated difference to it
        // - scale it up to match the dimensions of the canvas
        // - add the offset so the point is centered relatively to the canvas
        // in case of the y coordinate: due to the gis coordinates originating from bottom left,
        // but wpf renders originating from top left, which would result in the map being shown flipped upside down,
        // subtract the y value from the canvas' height to mirror the layer (again) so it is displayed normal again.
        double
            x = (coordinate.X + xDifference) * scaleFactor + offsetX,
            y = ActualHeight - ((coordinate.Y + yDifference) * scaleFactor + offsetY);

        return new Point(x, y);
    }

    /// <summary>
    /// Draws a square from (<paramref name="innerXMin"/> | <paramref name="innerYMin"/>) to (<paramref name="innerXMax"/> | <paramref name="innerYMax"/>),
    /// normalized through <paramref name="xDifference"/> / <paramref name="yDifference"/>, scaled with <paramref name="scaleFactor"/>
    /// and outlined in <paramref name="outlineColour"/>. 
    /// </summary>
    /// <param name="innerXMin">X coordinate for the first point. Doesn't necessarily have to be the min value contrary to it's name.</param>
    /// <param name="innerYMin">Y coordinate for the first point. Doesn't necessarily have to be the min value contrary to it's name.</param>
    /// <param name="innerXMax">X coordinate for the second point. Doesn't necessarily have to be the max value contrary to it's name.</param>
    /// <param name="innerYMax">Y coordinate for the second point. Doesn't necessarily have to be the max value contrary to it's name.</param>
    /// <param name="xDifference">Difference on the X axis to normalize the points, because gis coordinates can range from -infinite to infinite, but the canvas can only display positive values.</param>
    /// <param name="yDifference">Difference on the Y axis to normalize the points, because gis coordinates can range from -infinite to infinite, but the canvas can only display positive values.</param>
    /// <param name="scaleFactor">Scales the coordinates up relatively to the canvas.</param>
    /// <param name="outlineColour">The colour / brush with which the square should be outlined.</param>
    /// <returns>A <see cref="VectorFeatureDrawingVisual"/> that can be added to a canvas.</returns>
    private VectorFeatureDrawingVisual DrawSquare(double innerXMin, double innerYMin, double innerXMax, double innerYMax, double xDifference,
        double yDifference, double scaleFactor, Brush outlineColour)
    {
        var vectorFeatureDrawingVisual = new VectorFeatureDrawingVisual(new VectorFeature()
        {
            VectorStructured = new VectorStructuredData()
            {
                Geometry = new Polygon(new LinearRing(new[]
                {
                    new Coordinate(innerXMin, innerYMin),
                    new Coordinate(innerXMin, innerYMax),
                    new Coordinate(innerXMax, innerYMax),
                    new Coordinate(innerXMax, innerYMin),
                    new Coordinate(innerXMin, innerYMin),
                }))
            }
        });
        var streamGeometry = new StreamGeometry();

        using var drawingContext = vectorFeatureDrawingVisual.RenderOpen();
        using var geometryContext = streamGeometry.Open();

        // Top Left
        geometryContext.BeginFigure(CalculatePoint(new Coordinate(innerXMin, innerYMin), xDifference, yDifference, scaleFactor), true, true);

        var points = new PointCollection
        {
            // Bottom Left
            CalculatePoint(new Coordinate(innerXMin, innerYMax), xDifference, yDifference, scaleFactor),

            // Bottom Right
            CalculatePoint(new Coordinate(innerXMax, innerYMax), xDifference, yDifference, scaleFactor),

            // Top Right
            CalculatePoint(new Coordinate(innerXMax, innerYMin), xDifference, yDifference, scaleFactor),
        };

        geometryContext.PolyLineTo(points, true, true);

        drawingContext.DrawGeometry(Brushes.Transparent, new Pen(outlineColour, 5), streamGeometry);

        return vectorFeatureDrawingVisual;
    }

    /// <summary>
    /// Outlines the layer's original center point by drawing a border from (-5|-5) to (5|5). 
    /// </summary>
    /// <param name="xDifference">Difference on the X axis to normalize the points, because gis coordinates can range from -infinite to infinite, but the canvas can only display positive values.</param>
    /// <param name="yDifference">Difference on the Y axis to normalize the points, because gis coordinates can range from -infinite to infinite, but the canvas can only display positive values.</param>
    /// <param name="scaleFactor">Scales the coordinates up relatively to the canvas.</param>
    /// <returns>A <see cref="VectorFeatureDrawingVisual"/> that can be added to a canvas.</returns>
    private VectorFeatureDrawingVisual DrawDebugCenterPoint(double xDifference, double yDifference, double scaleFactor)
    {
        return DrawSquare(-1, -1, 1, 1, xDifference, yDifference, scaleFactor,
            _gisLayer is GisCellsLayer ? Brushes.Aqua : _gisLayer is GisRiverLayer ? Brushes.DeepPink : Brushes.DarkOrange);
    }

    /// <summary>
    /// Outlines the range of this layer's coordinates, from the lowest x & y to the highest x & y value.
    /// </summary>
    /// <param name="xDifference">Difference on the X axis to normalize the points, because gis coordinates can range from -infinite to infinite, but the canvas can only display positive values.</param>
    /// <param name="yDifference">Difference on the Y axis to normalize the points, because gis coordinates can range from -infinite to infinite, but the canvas can only display positive values.</param>
    /// <param name="scaleFactor">Scales the coordinates up relatively to the canvas.</param>
    /// <returns>A <see cref="VectorFeatureDrawingVisual"/> that can be added to a canvas.</returns>
    private VectorFeatureDrawingVisual DrawDebugBorder(double xDifference, double yDifference, double scaleFactor)
    {
        return DrawSquare(_innerXMin, _innerYMin, _innerXMax, _innerYMax, xDifference, yDifference, scaleFactor,
            _gisLayer is GisCellsLayer ? Brushes.Aqua : _gisLayer is GisRiverLayer ? Brushes.DeepPink : Brushes.DarkOrange);
    }
}