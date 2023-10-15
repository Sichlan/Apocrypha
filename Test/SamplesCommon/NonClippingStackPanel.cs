using System.Windows;
using System.Windows.Media;
using ModernWpf.Controls;

namespace SamplesCommon
{
    public class NonClippingStackPanel : SimpleStackPanel
    {
        protected override Geometry GetLayoutClip(Size layoutSlotSize)
        {
            return null;
        }
    }
}