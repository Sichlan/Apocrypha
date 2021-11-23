using Apocrypha.WPF.State.Navigators.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apocrypha.WPF.Commands
{
    public class LogoutCommand : AsyncCommandBase
    {
        private readonly IAuthenticator _authenticator
        public override Task ExecuteAsync(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
