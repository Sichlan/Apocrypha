using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Apocrypha.WPF.Views;

namespace Apocrypha.WPF;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INavigationWindow
{
    public MainWindow(object dataContext, IPageService pageService, INavigationService navigationService)
    {
        DataContext = dataContext;

        InitializeComponent();
        SetPageService(pageService);

        navigationService.SetNavigationControl(RootNavigation);
    }

    private void PopupBorder_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        e.Handled = true;
    }

    public Frame GetFrame()
        => RootFrame;

    public INavigation GetNavigation()
        => RootNavigation;

    public bool Navigate(Type pageType)
        => RootNavigation.Navigate(pageType);

    public void SetPageService(IPageService pageService)
        => RootNavigation.PageService = pageService;

    public void ShowWindow()
        => Show();

    public void CloseWindow()
        => Close();

    private void MainWindow_OnClosed(object sender, EventArgs e)
    {
        base.OnClosed(e);

        Application.Current.Shutdown();
    }

    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        Navigate(typeof(LoginView));
    }
}