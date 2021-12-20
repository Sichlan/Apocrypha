using System;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Exceptions;
using Apocrypha.WPF.State.Navigators.Authenticators;
using Apocrypha.WPF.State.Navigators.Navigators;
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
                _loginViewModel.ErrorMessage = "Username does not exist.";
            }
            catch (InvalidPasswordException)
            {
                _loginViewModel.ErrorMessage = "Incorrect Password.";
            }
            catch (Exception)
            {
                _loginViewModel.ErrorMessage = "Login failed.";
            }
        }
    }
}