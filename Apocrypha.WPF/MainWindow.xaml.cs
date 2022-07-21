using System.Windows;
using System.Windows.Input;
using Apocrypha.WPF.ViewModels;

namespace Apocrypha.WPF;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow(object dataContext)
    {
        InitializeComponent();

        DataContext = dataContext;
    }

    private void HeaderGrid_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
            DragMove();
    }

    private void HeaderGrid_OnMouseMove(object sender, MouseEventArgs e)
    {
        if (Mouse.LeftButton == MouseButtonState.Pressed && DataContext is MainViewModel {CurrentWindowState: WindowState.Maximized} mainViewModel)
        {
            mainViewModel.CurrentWindowState = WindowState.Normal;
        }
    }
}