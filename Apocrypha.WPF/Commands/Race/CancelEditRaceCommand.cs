using System.Threading.Tasks;
using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.State.Races;

namespace Apocrypha.WPF.Commands.Race
{
    public class CancelEditRaceCommand : AsyncCommandBase
    {
        private readonly IRaceStore _raceStore;
        private readonly IRenavigator _raceListRenavigator;

        public CancelEditRaceCommand(IRaceStore raceStore, IRenavigator raceListRenavigator)
        {
            _raceStore = raceStore;
            _raceListRenavigator = raceListRenavigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _raceStore.ActiveRace = null;
            _raceListRenavigator.Renavigate();
        }

        public override bool CanExecuteAsync(object parameter)
        {
            return true;
        }
    }
}