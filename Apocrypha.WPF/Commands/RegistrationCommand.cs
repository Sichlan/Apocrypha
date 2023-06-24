using Apocrypha.CommonObject.Services.AuthenticationServices;
using Apocrypha.WPF.State.Authenticators;
using Apocrypha.WPF.ViewModels;
using Apocrypha.WPF.Views;

namespace Apocrypha.WPF.Commands;

public class RegistrationCommand : AsyncCommandBase
{
    private readonly IAuthenticator _authenticator;
    private readonly INavigationService _navigationService;
    private readonly RegistrationViewModel _registerViewModel;

    public RegistrationCommand(RegistrationViewModel registerViewModel, IAuthenticator authenticator, INavigationService navigationService)
    {
        _registerViewModel = registerViewModel;
        _authenticator = authenticator;
        _navigationService = navigationService;
    }

    protected override async Task ExecuteAsync(object parameter)
    {
        _registerViewModel.ErrorMessage = string.Empty;

        try
        {
            var result = await _authenticator.Register(_registerViewModel.Email, _registerViewModel.Username, _registerViewModel.Password,
                _registerViewModel.ConfirmPassword);

            switch (result)
            {
                case RegistrationResult.Success:
                    _navigationService.Navigate(typeof(LoginView));

                    break;
                case RegistrationResult.PasswordsDoNotMatch:
                    _registerViewModel.ErrorMessage = Resources.Localization.Localization.ErrorRegistrationPasswordsDoNotMatch;

                    break;
                case RegistrationResult.EmailAlreadyExists:
                    _registerViewModel.ErrorMessage = Resources.Localization.Localization.ErrorRegistrationEmailAlreadyInUse;

                    break;
                case RegistrationResult.UsernameAlreadyExists:
                    _registerViewModel.ErrorMessage = Resources.Localization.Localization.ErrorRegistrationUsernameAlreadyExists;

                    break;
                case RegistrationResult.Failure:
                    _registerViewModel.ErrorMessage = Resources.Localization.Localization.ErrorRegistrationFailed;

                    break;
            }
        }
        catch (Exception)
        {
            _registerViewModel.ErrorMessage = Resources.Localization.Localization.ErrorRegistrationFailed;

            throw;
        }
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return true;
    }
}