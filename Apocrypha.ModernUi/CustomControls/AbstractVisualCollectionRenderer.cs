using System;
using System.Windows;
using System.Windows.Media;

namespace Apocrypha.ModernUi.CustomControls;

/// <inheritdoc />
public abstract class AbstractVisualCollectionRenderer : FrameworkElement
{
    protected VisualCollection _visualCollection;

    /// <inheritdoc />
    protected AbstractVisualCollectionRenderer()
    {
        _visualCollection = new VisualCollection(this);
    }

    /// <inheritdoc />
    protected override Visual GetVisualChild(int index)
    {
        if (index < 0 || index >= _visualCollection.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return _visualCollection[index];
    }

    /// <inheritdoc />
    protected override int VisualChildrenCount =>
        _visualCollection.Count;
}