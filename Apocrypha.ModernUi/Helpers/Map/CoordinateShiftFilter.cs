using NetTopologySuite.Geometries;

namespace Apocrypha.ModernUi.Helpers.Map;

/// <inheritdoc />
public class CoordinateShiftFilter : ICoordinateSequenceFilter
{
    private readonly double _innerXMin;
    private readonly double _innerYMin;

    public CoordinateShiftFilter(double innerXMin, double innerYMin)
    {
        _innerXMin = innerXMin;
        _innerYMin = innerYMin;
    }

    /// <inheritdoc />
    public void Filter(CoordinateSequence seq, int i)
    {
        seq.SetX(i, seq.GetX(i) - _innerXMin);
        seq.SetY(i, seq.GetY(i) - _innerYMin);
    }

    /// <inheritdoc />
    public bool Done { get; }

    /// <inheritdoc />
    public bool GeometryChanged { get; }
}