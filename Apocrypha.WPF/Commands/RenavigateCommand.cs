using System.Threading.Tasks;
using Apocrypha.WPF.State.Navigators;

namespace Apocrypha.WPF.Commands
{
    public class RenavigateCommand : AsyncCommandBase
    {
        private readonly IRenavigator _renavigator;

        public RenavigateCommand(IRenavigator renavigator)
        {
            _renavigator = renavigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _renavigator.Renavigate();
        }

        public override bool CanExecuteAsync(object parameter)
        {
            return true;
        }
    }
}