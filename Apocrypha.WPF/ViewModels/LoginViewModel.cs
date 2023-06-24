using System.Windows.Input;
using Apocrypha.WPF.Commands;
using Apocrypha.WPF.State.Authenticators;
using Apocrypha.WPF.Views;

namespace Apocrypha.WPF.ViewModels;

public class LoginViewModel : BaseViewModel, INavigationAware
{
    public LoginViewModel(IAuthenticator authenticator, INavigationService navigationService)
    {
        LoginCommand = new LoginCommand(authenticator, navigationService, this);
        ChangeToRegistrationCommand = new RenavigateCommand(navigationService, typeof(RegistrationView));

        ErrorMessageViewModel = new MessageViewModel
            {MessageType = MessageType.Error};
    }

    public ICommand LoginCommand { get; }
    public ICommand ChangeToRegistrationCommand { get; }

    #region Properties

    private string _username;

    public string Username
    {
        get
        {
            return _username;
        }
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
        }
    }

    private string _password;

    public string Password
    {
        get
        {
            return _password;
        }
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public MessageViewModel ErrorMessageViewModel { get; }

    public string ErrorMessage
    {
        set
        {
            ErrorMessageViewModel.Message = value;
        }
    }

    #endregion

    #region INavigationAware

    public void OnNavigatedTo()
    {
    }

    public void OnNavigatedFrom()
    {
    }

    #endregion
}