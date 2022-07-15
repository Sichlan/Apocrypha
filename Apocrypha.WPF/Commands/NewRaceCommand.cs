using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.State.Races;

namespace Apocrypha.WPF.Commands
{
    public class NewRaceCommand : AsyncCommandBase
    {
        private readonly IRaceStore _raceStore;
        private readonly IRenavigator _editRaceRenavigator;

        public NewRaceCommand(IRaceStore raceStore, IRenavigator editRaceRenavigator)
        {
            _raceStore = raceStore;
            _editRaceRenavigator = editRaceRenavigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _raceStore.ActiveRace = new Race();
            _editRaceRenavigator.Renavigate();
        }

        public override bool CanExecuteAsync(object parameter)
        {
            return true;
        }
    }
}