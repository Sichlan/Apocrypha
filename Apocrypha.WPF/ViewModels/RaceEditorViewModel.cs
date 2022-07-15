using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.WPF.Commands;
using Apocrypha.WPF.State.Races;

namespace Apocrypha.WPF.ViewModels
{
    public class RaceEditorViewModel : BaseViewModel
    {
        private readonly IDataService<Race> _raceDataService;
        private readonly IRaceStore _raceStore;

        public RaceEditorViewModel(IDataService<Race> raceDataService, IRaceStore raceStore)
        {
            _raceDataService = raceDataService;
            _raceStore = raceStore;

            _raceStore.StateChange += RaceStoreOnStateChange;
            
            SetCommands();
        }

        private void RaceStoreOnStateChange()
        {
            // TODO: Fill with fields that change
        }

        public AsyncCommandBase SearchRaceCommand { get; set; }
        public AsyncCommandBase SaveEditRaceCommand { get; set; }
        public AsyncCommandBase CancelEditRaceCommand { get; set; }
        
        private void SetCommands()
        {
            // SearchRaceCommand = new Rel
            // SaveEditRaceCommand = new Rel
            // CancelEditRaceCommand = new Rel
        }
    }
}