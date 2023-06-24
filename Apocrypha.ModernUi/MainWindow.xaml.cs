using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Apocrypha.ModernUi.ViewModels;
using ModernWpf;
using ModernWpf.Controls;

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

            _mainViewModel = dataContext;
            _mainViewModel.PropertyChanged += MainViewModelPropertyChanged;

            DataContext = _mainViewModel;

            UpdateSelectedNavItem();
        }

        private void MainViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(MainViewModel.ActiveViewModel):
                    UpdateSelectedNavItem();

                    break;
            }
        }

        private void UpdateSelectedNavItem()
        {
            var type = _mainViewModel.ActiveViewModel.GetType();
            NavView.SelectedItem = NavView.MenuItems.OfType<NavigationViewItem>().FirstOrDefault(x => GetPageType(x) == type);
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

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                //TODO: Fix this
                // Navigate(typeof(SettingsPage));
            }
            else
            {
                Navigate(args.InvokedItemContainer);
            }
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
        }

        private void Navigate(Type sourcePageType)
        {
            if (ContentFrame.Content.GetType() != sourcePageType)
            {
                _mainViewModel.NavigateToPage(sourcePageType);
            }
        }

        private void Navigate(object item)
        {
            if (item is NavigationViewItem menuItem)
            {
                Type pageType = GetPageType(menuItem);
                Navigate(pageType);
            }
        }

        private Type GetPageType(NavigationViewItem item)
        {
            return item.Tag as Type;
        }
    }
}