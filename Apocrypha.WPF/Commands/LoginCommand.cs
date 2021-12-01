using Apocrypha.WPF.State.Navigators.Authenticators;
using System;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Exceptions;
using Apocrypha.WPF.State.Navigators.Navigators;
using Apocrypha.WPF.ViewModels;

namespace Apocrypha.WPF.Commands
{
    public class LoginCommand : AsyncCommandBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;
        private readonly LoginViewModel _loginViewModel;

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
            catch (UserNotFoundException ex)
            {
                _loginViewModel.ErrorMessage = "Username does not exist.";
            }
            catch (InvalidPasswordException ex)
            {
                _loginViewModel.ErrorMessage = "Incorrect Password.";
            }
            catch (Exception ex)
            {
                _loginViewModel.ErrorMessage = "Login failed.";
            }
        }
    }
}
