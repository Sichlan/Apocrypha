using System.Windows;
using Apocrypha.CommonObject.Exceptions;
using Apocrypha.WPF.State.Authenticators;
using Apocrypha.WPF.ViewModels;
using Apocrypha.WPF.Views;

namespace Apocrypha.WPF.Commands;

public class LoginCommand : AsyncCommandBase
{
    private readonly IAuthenticator _authenticator;
    private readonly LoginViewModel _loginViewModel;
    private readonly INavigationService _navigationService;

    public LoginCommand(IAuthenticator authenticator, INavigationService navigationService, LoginViewModel loginViewModel)
    {
        _authenticator = authenticator;
        _navigationService = navigationService;
        _loginViewModel = loginViewModel;
    }

    protected override async Task ExecuteAsync(object parameter)
    {
        try
        {
            await _authenticator.Login(_loginViewModel.Username, _loginViewModel.Password);
            _navigationService.Navigate(typeof(HomeView));
        }
        catch (UserNotFoundException)
        {
            _loginViewModel.ErrorMessage = Resources.Localization.Localization.ErrorLoginUsernameDoesNotExist;
        }
        catch (InvalidPasswordException)
        {
            _loginViewModel.ErrorMessage = Resources.Localization.Localization.ErrorLoginIncorrectPassword;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            _loginViewModel.ErrorMessage = Resources.Localization.Localization.ErrorLoginFailed;
        }
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return true;
    }
}