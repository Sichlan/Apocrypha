using System.Windows.Input;
using Apocrypha.WPF.Commands;
using Apocrypha.WPF.State.Authenticators;
using Apocrypha.WPF.Views;
using Wpf.Ui.Mvvm.Contracts;

namespace Apocrypha.WPF.ViewModels;

public class RegistrationViewModel : BaseViewModel
{
    public RegistrationViewModel(IAuthenticator authenticator, INavigationService navigationService)
    {
        RegistrationCommand = new RegistrationCommand(this, authenticator, navigationService);
        ChangeToLoginCommand = new RenavigateCommand(navigationService, typeof(LoginView));

        ErrorMessageViewModel = new MessageViewModel
            {MessageType = MessageType.Error};
    }

    public ICommand RegistrationCommand { get; }
    public ICommand ChangeToLoginCommand { get; }

    #region Properties

    private string _email;

    public string Email
    {
        get
        {
            return _email;
        }
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }

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
            OnPropertyChanged();
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
            OnPropertyChanged();
        }
    }

    private string _confirmPassword;

    public string ConfirmPassword
    {
        get
        {
            return _confirmPassword;
        }
        set
        {
            _confirmPassword = value;
            OnPropertyChanged();
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
}