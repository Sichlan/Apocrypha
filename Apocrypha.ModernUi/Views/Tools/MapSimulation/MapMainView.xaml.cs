using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Apocrypha.ModernUi.Views.Tools.MapSimulation;

public partial class MapMainView : INotifyPropertyChanged
{
    private Point _scrollMousePoint;
    private double _horizontalOffset;
    private double _verticalOffset;
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

        Debug.WriteLine($"Mouse down ({_scrollMousePoint.X}/{_scrollMousePoint.Y};{_horizontalOffset};{_verticalOffset})");
    }

    private void OnPreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
        ReleaseMouseCapture();

        Debug.WriteLine("Mouse up");
    }

    private void OnPreviewMouseMove(object sender, MouseEventArgs e)
    {
        if (!IsMouseCaptured)
            return;

        var mousePoint = e.GetPosition(this);
        TransformX = mousePoint.X - _scrollMousePoint.X;
        TransformY = mousePoint.Y - _scrollMousePoint.Y;

        Debug.WriteLine($"Mouse moved ({mousePoint.X}/{mousePoint.Y};{TransformX};{TransformY})");
    }

    /// <inheritdoc />
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}