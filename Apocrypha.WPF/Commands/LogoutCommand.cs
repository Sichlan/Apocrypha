using System.Threading.Tasks;
using Apocrypha.WPF.State.Navigators.Authenticators;
using Apocrypha.WPF.State.Navigators.Navigators;

namespace Apocrypha.WPF.Commands
{
    public class LogoutCommand : AsyncCommandBase
    {
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LogoutCommand(IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _authenticator.Logout();
            _renavigator.Renavigate();
        }
    }
}