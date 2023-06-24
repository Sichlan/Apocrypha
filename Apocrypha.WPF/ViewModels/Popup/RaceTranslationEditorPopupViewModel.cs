using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.WPF.Commands;
using Apocrypha.WPF.Commands.TranslationCommands;
using Apocrypha.WPF.State.Popups;

namespace Apocrypha.WPF.ViewModels.Popup;

public class RaceTranslationEditorPopupViewModel : BaseViewModel, IPopupViewModel
{
    private readonly Race _race;
    private readonly IShowGlobalPopupService _showGlobalPopupService;
    private readonly IEnumerable<CultureInfo> _cultureInfos;
    private readonly ObservableCollection<RaceTranslation> _newTranslationCollection;
    private readonly IDataService<RaceTranslation> _raceTranslationDataService;

    public RaceTranslationEditorPopupViewModel(Race race, IShowGlobalPopupService showGlobalPopupService, IEnumerable<CultureInfo> cultureInfos,
        IDataService<RaceTranslation> raceTranslationDataService)
    {
        _race = race;
        _showGlobalPopupService = showGlobalPopupService;
        _cultureInfos = cultureInfos;
        _raceTranslationDataService = raceTranslationDataService;
        _newTranslationCollection = new ObservableCollection<RaceTranslation>(_race.Translations.Copy());

        SetCommands();
        UpdateTranslations();
    }

    private void UpdateTranslations()
    {
        OnPropertyChanged(nameof(NewTranslationCollection));
    }

    private void SetCommands()
    {
        CancelCommand = new CancelTranslateObjectCommand(_showGlobalPopupService);
        SaveRaceTranslationCommand = new SaveRaceTranslationCommand(_race, _newTranslationCollection, _showGlobalPopupService, _raceTranslationDataService,
            TranslationIdsToDelete);
        AddNewRaceTranslationEntryCommand = new AddNewTranslationEntryCommand<RaceTranslation>(_newTranslationCollection);
        DeleteRaceTranslationCommand = new DeleteRaceTranslationCommand(_newTranslationCollection, TranslationIdsToDelete);
    }

    public ICommand CancelCommand { get; set; }
    public ICommand SaveRaceTranslationCommand { get; set; }
    public AsyncCommandBase AddNewRaceTranslationEntryCommand { get; set; }
    public AsyncCommandBase DeleteRaceTranslationCommand { get; set; }

    public event Action ClosePopup;


    public ObservableCollection<RaceTranslation> NewTranslationCollection
    {
        get
        {
            return _newTranslationCollection;
        }
    }

    public Race Race
    {
        get
        {
            return _race;
        }
    }

    public IEnumerable<CultureInfo> CultureInfos
    {
        get
        {
            return _cultureInfos;
        }
    }

    public List<int> TranslationIdsToDelete { get; private set; } = new List<int>();
}