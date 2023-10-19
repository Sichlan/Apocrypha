using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apocrypha.CommonObject.Exceptions;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services.AuthenticationServices;
using Apocrypha.ModernUi.Helpers;
using Apocrypha.ModernUi.Services.State.Authenticators;
using Apocrypha.ModernUi.Services.State.Users;
using Apocrypha.ModernUi.Services.UserInformationService;
using Apocrypha.ModernUi.ViewModels.Common;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.ViewModels.Users;

public class UserPopupViewModel : BaseViewModel
{
    private readonly IUserStore _userStore;
    private readonly IAuthenticator _authenticator;
    private readonly IUserInformationMessageService _userInformationMessageService;
    private string _loginUserName;
    private string _registerEmail;
    private string _registerUserName;
    private string _loginPassword;
    private string _registerPassword;
    private string _registerConfirmPassword;
    private bool _isBusy;

    public event Action RegistrationSuccessful;
    public event Action LoginSuccessful;

    public User CurrentUser =>
        _userStore.CurrentUser;

    public bool HasActiveUser =>
        CurrentUser != null;

    public string LoginUserName
    {
        get => _loginUserName;
        set
        {
            if (value == _loginUserName)
                return;

            _loginUserName = value;
            OnPropertyChanged();
            LoginCommand.NotifyCanExecuteChanged();
        }
    }

    public string RegisterEmail
    {
        get => _registerEmail;
        set
        {
            if (value == _registerEmail)
                return;

            _registerEmail = value;
            OnPropertyChanged();
            RegisterCommand.NotifyCanExecuteChanged();
        }
    }

    public string RegisterUserName
    {
        get => _registerUserName;
        set
        {
            if (value == _registerUserName)
                return;

            _registerUserName = value;
            OnPropertyChanged();
            RegisterCommand.NotifyCanExecuteChanged();
        }
    }

    public string LoginPassword
    {
        get => _loginPassword;
        set
        {
            if (value == _loginPassword)
                return;

            _loginPassword = value;
            OnPropertyChanged();
            LoginCommand.NotifyCanExecuteChanged();
        }
    }

    public string RegisterPassword
    {
        get => _registerPassword;
        set
        {
            if (value == _registerPassword)
                return;

            _registerPassword = value;
            OnPropertyChanged();
            RegisterCommand.NotifyCanExecuteChanged();
        }
    }

    public string RegisterConfirmPassword
    {
        get => _registerConfirmPassword;
        set
        {
            if (value == _registerConfirmPassword)
                return;

            _registerConfirmPassword = value;
            OnPropertyChanged();
            RegisterCommand.NotifyCanExecuteChanged();
        }
    }

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (value == _isBusy)
                return;

            _isBusy = value;
            OnPropertyChanged();
        }
    }

    public IRelayCommand LoginCommand { get; }
    public IRelayCommand RegisterCommand { get; }
    public IRelayCommand LogoutCommand { get; }

    public UserPopupViewModel(IUserStore userStore, IAuthenticator authenticator, IUserInformationMessageService userInformationMessageService)
    {
        _userStore = userStore;
        _authenticator = authenticator;
        _userInformationMessageService = userInformationMessageService;

        LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        RegisterCommand = new RelayCommand(ExecuteRegisterCommand, CanExecuteRegisterCommand);
        LogoutCommand = new RelayCommand(ExecuteLogoutCommand, CanExecuteLogoutCommand);

        _userStore.StateChange += () =>
        {
            OnPropertyChanged(nameof(CurrentUser));
            OnPropertyChanged(nameof(HasActiveUser));

            DispatcherHelper.RunOnMainThread(() =>
            {
                LogoutCommand.NotifyCanExecuteChanged();
            });
        };
    }

    private bool CanExecuteLogoutCommand()
    {
        return CurrentUser != null;
    }

    private void ExecuteLogoutCommand()
    {
        Task.Run(async () =>
        {
            IsBusy = true;

            await _authenticator.Logout();

            IsBusy = false;
        });
    }

    private bool CanExecuteRegisterCommand()
    {
        return !string.IsNullOrEmpty(RegisterEmail)
               && !string.IsNullOrEmpty(RegisterUserName)
               && RegisterPassword?.Length > 0
               && RegisterConfirmPassword?.Length > 0;
    }

    private void ExecuteRegisterCommand()
    {
        Task.Run(async () =>
        {
            IsBusy = true;

            try
            {
                var result = await _authenticator.Register(RegisterEmail, RegisterUserName, RegisterPassword, RegisterConfirmPassword);

                switch (result)
                {
                    case RegistrationResult.Success:
                        _userInformationMessageService.AddDisplayMessage("TODO REGISTRATION SUCCESSFUL", InformationType.Success, new TimeSpan(0, 0, 5));
                        RegistrationSuccessful?.Invoke();

                        break;
                    case RegistrationResult.PasswordsDoNotMatch:
                        _userInformationMessageService.AddDisplayMessage("TODO PASSWORDS DO NOT MATCH", InformationType.Error, new TimeSpan(0, 0, 15));

                        break;
                    case RegistrationResult.EmailAlreadyExists:
                        _userInformationMessageService.AddDisplayMessage("TODO EMAIL ALREADY IN USE", InformationType.Error, new TimeSpan(0, 0, 15));

                        break;
                    case RegistrationResult.UsernameAlreadyExists:
                        _userInformationMessageService.AddDisplayMessage("TODO USERNAME ALREADY EXISTS", InformationType.Error, new TimeSpan(0, 0, 15));

                        break;
                    case RegistrationResult.Failure:
                        _userInformationMessageService.AddDisplayMessage("TODO REGISTRATION FAILED", InformationType.Error, new TimeSpan(0, 0, 15));

                        break;
                }
            }
            catch (Exception ex)
            {
                _userInformationMessageService.AddDisplayMessage("TODO REGISTRATION FAILED", InformationType.Error, new TimeSpan(0, 0, 15));
            }

            IsBusy = false;
        });
    }

    private bool CanExecuteLoginCommand()
    {
        return !string.IsNullOrEmpty(LoginUserName)
               && LoginPassword?.Length > 0;
    }

    private void ExecuteLoginCommand()
    {
        Task.Run(async () =>
        {
            IsBusy = true;

            try
            {
                await _authenticator.Login(LoginUserName, LoginPassword);
                LoginSuccessful?.Invoke();
            }
            catch (UserNotFoundException)
            {
                _userInformationMessageService.AddDisplayMessage("TODO USER NOT FOUND", InformationType.Error);
            }
            catch (InvalidPasswordException)
            {
                _userInformationMessageService.AddDisplayMessage("TODO INVALID PASSWORD", InformationType.Error);
            }
            catch (Exception ex)
            {
                _userInformationMessageService.AddDisplayMessage("TODO LOGIN FAILED", InformationType.Error);
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
            }

            IsBusy = false;
        });
    }
}