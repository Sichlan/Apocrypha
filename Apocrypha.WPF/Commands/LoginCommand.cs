using System;
using System.Threading.Tasks;
using System.Windows;
using Apocrypha.CommonObject.Exceptions;
using Apocrypha.WPF.State.Authenticators;
using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.ViewModels;

namespace Apocrypha.WPF.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly LoginViewModel _loginViewModel;
        private readonly IRenavigator _renavigator;

        public LoginCommand(IAuthenticator authenticator, IRenavigator renavigator, LoginViewModel loginViewModel)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
            _loginViewModel = loginViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _authenticator.Login(_loginViewModel.Username, _loginViewModel.Password);
                _renavigator.Renavigate();
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

        public override bool CanExecuteAsync(object parameter)
        {
            return true;
        }
    }
}