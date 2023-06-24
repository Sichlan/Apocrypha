using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using Apocrypha.ModernUi.ViewModels;
using ModernWpf;
using ModernWpf.Controls;
using ModernWpf.Navigation;

namespace Apocrypha.ModernUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly MainViewModel _mainViewModel;

        public MainWindow(MainViewModel dataContext)
        {
            InitializeComponent();

            DataContext = _mainViewModel = dataContext;
        }

        private void Window_ActualThemeChanged(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(ThemeManager.GetActualTheme(this));
        }

        private void ToggleTheme(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ApplicationTheme =
                ThemeManager.Current.ActualApplicationTheme == ApplicationTheme.Dark ? ApplicationTheme.Light : ApplicationTheme.Dark;
        }

        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            throw new System.NotImplementedException();
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                // Navigate(typeof(SettingsPage));
            }
            else
            {
                Navigate(args.InvokedItemContainer);
            }
        }

        private void NavView_PaneOpening(NavigationView sender, object args)
        {
            UpdateAppTitleMargin(sender);
        }

        private void NavView_PaneClosing(NavigationView sender, NavigationViewPaneClosingEventArgs args)
        {
            UpdateAppTitleMargin(sender);
        }

        private void NavView_DisplayModeChanged(NavigationView sender, NavigationViewDisplayModeChangedEventArgs args)
        {
            Thickness currMargin = AppTitleBar.Margin;

            if (sender.DisplayMode == NavigationViewDisplayMode.Minimal)
            {
                AppTitleBar.Margin = new Thickness((sender.CompactPaneLength * 2), currMargin.Top, currMargin.Right, currMargin.Bottom);
            }
            else
            {
                AppTitleBar.Margin = new Thickness(sender.CompactPaneLength, currMargin.Top, currMargin.Right, currMargin.Bottom);
            }

            UpdateAppTitleMargin(sender);
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            NavView.SelectedItem = NavView.MenuItems.OfType<NavigationViewItem>().FirstOrDefault(x => GetPageType(x) == e.SourcePageType());
        }

        private void UpdateAppTitleMargin(NavigationView sender)
        {
            const int smallLeftIndent = 4, largeLeftIndent = 24;

            Thickness currMargin = AppTitle.Margin;

            if ((sender.DisplayMode == NavigationViewDisplayMode.Expanded && sender.IsPaneOpen) ||
                sender.DisplayMode == NavigationViewDisplayMode.Minimal)
            {
                AppTitle.Margin = new Thickness(smallLeftIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
            }
            else
            {
                AppTitle.Margin = new Thickness(largeLeftIndent, currMargin.Top, currMargin.Right, currMargin.Bottom);
            }
        }

        private void Navigate(Type sourcePageType)
        {
            //TODO: Fix this
        }

        private void Navigate(object item)
        {
            //TODO: Fix this
            // if (item is NavigationViewItem menuItem)
            // {
            //     Type pageType = GetPageType(menuItem);
            //     if (ContentFrame.CurrentSourcePageType != pageType)
            //     {
            //         ContentFrame.Navigate(pageType);
            //     }
            // }
        }

        private Type GetPageType(NavigationViewItem item)
        {
            return item.Tag as Type;
        }
    }
}