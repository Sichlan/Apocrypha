using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Apocrypha.ModernUi.Views.Tools.MapSimulation;

public partial class MapMainView : INotifyPropertyChanged
{
    private Point _scrollMousePoint;
    private double _transformX;
    private double _transformY;

    public double TransformX
    {
        get => _transformX;
        set
        {
            if (value.Equals(_transformX))
                return;

            _transformX = value;
            OnPropertyChanged();
        }
    }

    public double TransformY
    {
        get => _transformY;
        set
        {
            if (value.Equals(_transformY))
                return;

            _transformY = value;
            OnPropertyChanged();
        }
    }

    public MapMainView()
    {
        InitializeComponent();
    }

    private void OnPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        _scrollMousePoint = e.GetPosition(this);
        _scrollMousePoint.X -= TransformX;
        _scrollMousePoint.Y -= TransformY;

        CaptureMouse();
    }

    private void OnPreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
        ReleaseMouseCapture();
    }

    private void OnPreviewMouseMove(object sender, MouseEventArgs e)
    {
        if (!IsMouseCaptured)
            return;

        var mousePoint = e.GetPosition(this);
        TransformX = mousePoint.X - _scrollMousePoint.X;
        TransformY = mousePoint.Y - _scrollMousePoint.Y;

        // TODO: Fix this to restrain panning within the area of the canvas 
        // if (TransformX < 0)
        // {
        //     TransformX = 0;
        //     _scrollMousePoint.X = mousePoint.X;
        // }
        // else if (TransformX + ActualWidth > MapViewBox.ActualWidth * ZoomSlider.Value)
        // {
        //     TransformX = MapViewBox.ActualWidth * ZoomSlider.Value - ActualWidth;
        //     _scrollMousePoint.X = mousePoint.X;
        // }
    }

    private void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        ZoomSlider.Value = e.Delta > 0
            ? Math.Min(ZoomSlider.Value + ZoomSlider.LargeChange, ZoomSlider.Maximum)
            : Math.Max(ZoomSlider.Value - ZoomSlider.LargeChange, ZoomSlider.Minimum);
    }

    /// <inheritdoc />
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}