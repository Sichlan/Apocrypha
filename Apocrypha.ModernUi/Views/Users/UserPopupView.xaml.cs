using System;
using System.Windows;
using System.Windows.Controls;
using Apocrypha.ModernUi.ViewModels.Users;

namespace Apocrypha.ModernUi.Views.Users;

public partial class UserPopupView
{
    public event EventHandler LoginSuccessful;

    public UserPopupView()
    {
        InitializeComponent();
    }

    private void UserPopupView_OnLoaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is UserPopupViewModel popupViewModel)
        {
            popupViewModel.LoginSuccessful += () => LoginSuccessful?.Invoke(this, EventArgs.Empty);
            popupViewModel.RegistrationSuccessful += () => LoginTabControl.SelectedIndex = 0;
        }
    }

    private void Login_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is UserPopupViewModel popupViewModel
            && sender is PasswordBox box)
            popupViewModel.LoginPassword = box.Password;
    }

    private void Register_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is UserPopupViewModel popupViewModel
            && sender is PasswordBox box)
            popupViewModel.RegisterPassword = box.Password;
    }

    private void RegisterConfirm_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is UserPopupViewModel popupViewModel
            && sender is PasswordBox box)
            popupViewModel.RegisterConfirmPassword = box.Password;
    }
}