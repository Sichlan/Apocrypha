using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;
using NetTopologySuite.Geometries;

namespace Apocrypha.ModernUi.Helpers.Converters;

public class CoordinatesToGeometryConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is IEnumerable<Coordinate> coordinatesArray)
        {
            var points = coordinatesArray.Select(x => new System.Windows.Point(x.X, x.Y)).ToList();
            // var firstPoint = points.First();
            // var pathFigure = new PathFigure(firstPoint, new[] {new PolyLineSegment(points.Skip(1), false)}, true);
            // var geometry = new PathGeometry(new []{pathFigure});
            //
            // return geometry;

            var pointCollection = new PointCollection(points);

            return pointCollection;
        }
        else if (value is Coordinate coordinate)
        {
            return new System.Windows.Point(coordinate.X, coordinate.Y);
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}