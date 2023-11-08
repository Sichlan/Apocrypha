using System.Windows.Media;
using Mars.Interfaces.Layers;

namespace Apocrypha.ModernUi.CustomControls;

public class VectorFeatureDrawingVisual : DrawingVisual
{
    public IVectorFeature VectorFeature { get; set; }

    public VectorFeatureDrawingVisual(IVectorFeature vectorFeature)
    {
        VectorFeature = vectorFeature;
    }
}