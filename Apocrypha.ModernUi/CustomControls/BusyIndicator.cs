using System.Windows;
using System.Windows.Controls;

namespace Apocrypha.ModernUi.CustomControls;

public class BusyIndicator : ContentControl
{
    public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register(nameof(IsBusy), typeof(bool), typeof(BusyIndicator));

    public bool IsBusy
    {
        get => (bool)GetValue(IsBusyProperty);
        set => SetValue(IsBusyProperty, value);
    }

    static BusyIndicator()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(BusyIndicator),
            new FrameworkPropertyMetadata(typeof(BusyIndicator)));
    }
}