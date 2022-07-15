using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.WPF.Commands;
using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.State.Races;

namespace Apocrypha.WPF.ViewModels
{
    public class RaceListViewModel : BaseViewModel
    {
        #region Services

        private readonly IDataService<Race> _raceDataService;
        private readonly IRaceStore _raceStore;
        private readonly IRenavigator _editRaceRenavigator;

        #endregion

        #region Fields

        private ObservableCollection<RaceListItemViewModel> _races = new ObservableCollection<RaceListItemViewModel>();
        private RaceListItemViewModel _selectedRaceListItemViewModel;

        #endregion

        #region Properties

        public ObservableCollection<RaceListItemViewModel> Races
        {
            get
            {
                return _races;
            }
            set
            {
                _races = value;
                OnPropertyChanged();
            }
        }
        public RaceListItemViewModel SelectedRaceListItemViewModel
        {
            get
            {
                return _selectedRaceListItemViewModel;
            }
            set
            {
                _selectedRaceListItemViewModel = value;
                OnPropertyChanged();
                EditRaceCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        public RaceListViewModel(IDataService<Race> raceDataService, IRaceStore raceStore, IRenavigator editRaceRenavigator)
        {
            _raceDataService = raceDataService;
            _raceStore = raceStore;
            _editRaceRenavigator = editRaceRenavigator;

            SetCommands();

            InitRaces();
        }

        private async void InitRaces()
        {
            Races = new ObservableCollection<RaceListItemViewModel>((await _raceDataService.GetAll()).Select(x => new RaceListItemViewModel(x)));
        }

        #region Commands

        public AsyncCommandBase NewRaceCommand { get; private set; }
        public AsyncCommandBase EditRaceCommand { get; private set; }
        
        
        private void SetCommands()
        {
            NewRaceCommand = new NewRaceCommand(_raceStore, _editRaceRenavigator);
            EditRaceCommand = new EditRaceCommand(_raceStore, _editRaceRenavigator);
        }

        #endregion
    }
}