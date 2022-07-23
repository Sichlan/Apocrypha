using System.Collections.ObjectModel;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.WPF.Commands;
using Apocrypha.WPF.Commands.RaceCommands;
using Apocrypha.WPF.Commands.TranslationCommands;
using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.State.Popups;
using Apocrypha.WPF.State.Races;

namespace Apocrypha.WPF.ViewModels;

public class RaceEditorViewModel : BaseViewModel
{
    #region Services

    private readonly IDataService<Race> _raceDataService;
    private readonly IDataService<CreatureType> _creatureTypeDataService;
    private readonly IDataService<CreatureSubType> _creatureSubTypeDataService;
    private readonly IDataService<CreatureSizeCategory> _creatureSizeCategoryDataService;
    private readonly IDataService<RuleBook> _ruleBookDataService;
    private readonly IShowGlobalPopupService _showGlobalPopupService;
    private readonly IRaceStore _raceStore;
    private readonly IRenavigator _raceListRenavigator;

    #endregion

    #region Fields

    private ObservableCollection<CreatureType> _creatureTypes;
    private ObservableCollection<CreatureSubType> _creatureSubTypes;
    private ObservableCollection<CreatureSizeCategory> _creatureSizeCategories;
    private ObservableCollection<RuleBook> _ruleBooks;

    #endregion

    #region Properties

    public Race ActiveRace
    {
        get
        {
            return _raceStore.ActiveRace;
        }
    }

    public CreatureType SelectedCreatureType
    {
        get
        {
            return CreatureTypes?.FirstOrDefault(x => x.Id == ActiveRace.CreatureType?.Id);
        }
        set
        {
            ActiveRace.CreatureType = value;
        }
    }

    public ObservableCollection<CreatureType> CreatureTypes
    {
        get
        {
            return _creatureTypes;
        }
        private set
        {
            _creatureTypes = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SelectedCreatureType));
        }
    }

    public CreatureSubType SelectedCreatureSubType
    {
        get
        {
            return CreatureSubTypes?.FirstOrDefault(x => x.Id == ActiveRace.CreatureSubType?.Id);
        }
        set
        {
            ActiveRace.CreatureSubType = value;
        }
    }

    public ObservableCollection<CreatureSubType> CreatureSubTypes
    {
        get
        {
            return _creatureSubTypes;
        }
        private set
        {
            _creatureSubTypes = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SelectedCreatureSubType));
        }
    }

    public CreatureSizeCategory SelectedCreatureSizeCategory
    {
        get
        {
            return CreatureSizeCategories?.FirstOrDefault(x => x.Id == ActiveRace.CreatureSizeCategory?.Id);
        }
        set
        {
            ActiveRace.CreatureSizeCategory = value;
        }
    }

    public ObservableCollection<CreatureSizeCategory> CreatureSizeCategories
    {
        get
        {
            return _creatureSizeCategories;
        }
        private set
        {
            _creatureSizeCategories = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SelectedCreatureSizeCategory));
        }
    }

    public RuleBook SelectedRuleBook
    {
        get
        {
            return RuleBooks?.FirstOrDefault(x => x.Id == ActiveRace.RuleBook?.Id);
        }
        set
        {
            ActiveRace.RuleBook = value;
        }
    }

    public ObservableCollection<RuleBook> RuleBooks
    {
        get
        {
            return _ruleBooks;
        }
        private set
        {
            _ruleBooks = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SelectedRuleBook));
        }
    }

    #endregion

    [Obsolete("This is only used for creating a design time instance.")]
    public RaceEditorViewModel()
    {
    }

    public RaceEditorViewModel(IRaceStore raceStore, IRenavigator raceListRenavigator, IDataService<Race> raceDataService,
        IDataService<CreatureType> creatureTypeDataService, IDataService<CreatureSubType> creatureSubTypeDataService,
        IDataService<CreatureSizeCategory> creatureSizeCategoryDataService, IDataService<RuleBook> ruleBookDataService,
        IShowGlobalPopupService showGlobalPopupService)
    {
        _raceStore = raceStore;
        _raceListRenavigator = raceListRenavigator;
        _raceDataService = raceDataService;
        _creatureTypeDataService = creatureTypeDataService;
        _creatureSubTypeDataService = creatureSubTypeDataService;
        _creatureSizeCategoryDataService = creatureSizeCategoryDataService;
        _ruleBookDataService = ruleBookDataService;
        _showGlobalPopupService = showGlobalPopupService;

        _raceStore.StateChange += RaceStoreOnStateChange;

        SetCommands();
        InitData();
    }

    private async void InitData()
    {
        CreatureTypes = new ObservableCollection<CreatureType>(await _creatureTypeDataService.GetAll());
        CreatureSubTypes = new ObservableCollection<CreatureSubType>(await _creatureSubTypeDataService.GetAll());
        CreatureSizeCategories = new ObservableCollection<CreatureSizeCategory>(await _creatureSizeCategoryDataService.GetAll());
        RuleBooks = new ObservableCollection<RuleBook>(await _ruleBookDataService.GetAll());
    }

    private static void RaceStoreOnStateChange()
    {
        // TODO: Fill with fields that change or check if this is needed
    }

    #region Commands

    public AsyncCommandBase SaveEditRaceCommand { get; private set; }
    public AsyncCommandBase CancelEditRaceCommand { get; private set; }
    public AsyncCommandBase TranslateRaceCommand { get; private set; }

    private void SetCommands()
    {
        SaveEditRaceCommand = new SaveEditRaceCommand(_raceStore, _raceDataService, _raceListRenavigator);
        CancelEditRaceCommand = new CancelEditRaceCommand(_raceStore, _raceListRenavigator);
        TranslateRaceCommand = new TranslateRaceCommand(_raceStore.ActiveRace, _showGlobalPopupService);
    }

    #endregion
}