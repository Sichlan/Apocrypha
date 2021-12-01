using Apocrypha.WPF.State.Navigators.Authenticators;
using Apocrypha.WPF.State.Navigators.Navigators;
using System.Windows.Input;
using Apocrypha.WPF.Commands;

namespace Apocrypha.WPF.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Properties

        private string _username;
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        #endregion

        public ICommand LoginCommand { get; }
        public ICommand ChangeToRegistrationCommand { get; }

        public LoginViewModel(IAuthenticator authenticator, IRenavigator homeRenavigator, IRenavigator registerNavigator)
        {
            LoginCommand = new LoginCommand(authenticator, homeRenavigator, this);
            ChangeToRegistrationCommand = new RenavigateCommand(registerNavigator);

            ErrorMessageViewModel = new MessageViewModel() {MessageType = MessageType.Error};
        }
    }
}
