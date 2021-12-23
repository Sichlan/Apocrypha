using System;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Services.AuthenticationServices;
using Apocrypha.WPF.State.Navigators.Authenticators;
using Apocrypha.WPF.State.Navigators.Navigators;
using Apocrypha.WPF.ViewModels;

namespace Apocrypha.WPF.Commands
{
    public class RegistrationCommand : AsyncCommandBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _loginRenavigator;
        private readonly RegistrationViewModel _registerViewModel;

        public RegistrationCommand(RegistrationViewModel registerViewModel, IAuthenticator authenticator, IRenavigator loginRenavigator)
        {
            _registerViewModel = registerViewModel;
            _authenticator = authenticator;
            _loginRenavigator = loginRenavigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _registerViewModel.ErrorMessage = string.Empty;

            try
            {
                var result = await _authenticator.Register(_registerViewModel.Email, _registerViewModel.Username, _registerViewModel.Password,
                    _registerViewModel.ConfirmPassword);

                switch (result)
                {
                    case RegistrationResult.Success:
                        _loginRenavigator.Renavigate();

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
    }
}