using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Apocrypha.ModernUi.ViewModels;
using Apocrypha.ModernUi.ViewModels.Users;
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

                case nameof(MainViewModel.UserPopupViewModel):
                    UpdateUserPopupFlyout();

                    break;
            }
        }

        private void UpdateUserPopupFlyout()
        {
            Dispatcher.Invoke(() =>
            {
                FlyoutContent.DataContext = _mainViewModel.UserPopupViewModel;
            });
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

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                //TODO: Fix this
                Navigate(typeof(SettingsViewModel));
            }
            else
            {
                Navigate(args.InvokedItemContainer);
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

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateUserPopupFlyout();
        }

        private void UserPopupView_OnLoginSuccessful(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                UserFlyout.Hide();
            });
        }

        private void UserFlyout_OnOpened(object sender, object e)
        {
            if (_mainViewModel.UserPopupViewModel.HasActiveUser)
            {
                //TODO: Focus first control for active user
            }
            else
            {
                // TODO: Fix this :)
                FlyoutContent.LoginTextBox.Focus();
                Keyboard.Focus(FlyoutContent.LoginTextBox);
            }
        }
    }
}