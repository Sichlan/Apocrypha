using Apocrypha.WPF.State.Navigators.Authenticators;
using System.Threading.Tasks;

namespace Apocrypha.WPF.Commands
{
    public class LogoutCommand : AsyncCommandBase
    {
        private readonly IAuthenticator _authenticator;

        public LogoutCommand(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _authenticator.Logout();
        }
    }
}
