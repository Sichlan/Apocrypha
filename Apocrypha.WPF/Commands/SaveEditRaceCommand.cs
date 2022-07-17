using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.State.Races;

namespace Apocrypha.WPF.Commands
{
    public class SaveEditRaceCommand : AsyncCommandBase
    {
        private readonly IRaceStore _raceStore;
        private readonly IDataService<Race> _raceDataService;
        private readonly IRenavigator _raceListRenavigator;

        public SaveEditRaceCommand(IRaceStore raceStore, IDataService<Race> raceDataService, IRenavigator raceListRenavigator)
        {
            _raceStore = raceStore;
            _raceDataService = raceDataService;
            _raceListRenavigator = raceListRenavigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (_raceDataService.GetById(_raceStore.ActiveRace.Id) != null)
                await _raceDataService.Update(_raceStore.ActiveRace.Id, _raceStore.ActiveRace);
            else
                await _raceDataService.Create(_raceStore.ActiveRace);

            _raceStore.ActiveRace = null;
            _raceListRenavigator.Renavigate();
        }

        public override bool CanExecuteAsync(object parameter)
        {
            return _raceStore.HasActiveRace;
        }
    }
}