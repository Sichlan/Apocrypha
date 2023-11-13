using System.Windows;
using System.Windows.Input;
using Apocrypha.ModernUi.Helpers.Map;

namespace Apocrypha.ModernUi.Themes.CustomControls;

/// <inheritdoc cref="ResourceDictionary"/>
public partial class MapStyle
{
    /// <inheritdoc />
    public MapStyle()
    {
        InitializeComponent();
    }

    private void Element_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (sender is not FrameworkElement {DataContext: MapLayerElementVectorFeature feature})
            return;

        feature.DisplayDataCommand.Execute(null);
    }
}