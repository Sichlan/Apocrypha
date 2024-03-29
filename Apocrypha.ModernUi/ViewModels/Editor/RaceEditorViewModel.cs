﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Resources.Localization;
using Apocrypha.ModernUi.ViewModels.Navigation;

namespace Apocrypha.ModernUi.ViewModels.Editor;

public delegate RaceEditorViewModel CreateRaceEditorViewModel(Race race);

public class RaceEditorViewModel : NavigableViewModel
{
    #region Services

    private readonly IDataService<Race> _raceDataService;

    #endregion

    #region Fields

    private ObservableCollection<CreatureType> _creatureTypes;
    private ObservableCollection<CreatureSubType> _creatureSubTypes;
    private ObservableCollection<CreatureSizeCategory> _creatureSizeCategories;
    private ObservableCollection<RuleBook> _ruleBooks;
    private readonly IEnumerable<CultureInfo> _cultureInfos;
    private readonly IDataService<RaceTranslation> _raceTranslationDataService;

    #endregion

    #region Properties

    public override string ViewModelTitle { get; } = Localization.RaceEditorViewModel;
    public Race Race { get; }
    public ICommand SaveEditRaceCommand { get; }
    public ICommand CancelEditRaceCommand { get; }


    public CreatureType SelectedCreatureType
    {
        get
        {
            return CreatureTypes?.FirstOrDefault(x => x.Id == Race.CreatureType?.Id);
        }
        set => Race.CreatureType = value;
    }

    public ObservableCollection<CreatureType> CreatureTypes
    {
        get => _creatureTypes;
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
            return CreatureSubTypes?.FirstOrDefault(x => x.Id == Race.CreatureSubType?.Id);
        }
        set => Race.CreatureSubType = value;
    }

    public ObservableCollection<CreatureSubType> CreatureSubTypes
    {
        get => _creatureSubTypes;
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
            return CreatureSizeCategories?.FirstOrDefault(x => x.Id == Race.CreatureSizeCategory?.Id);
        }
        set => Race.CreatureSizeCategory = value;
    }

    public ObservableCollection<CreatureSizeCategory> CreatureSizeCategories
    {
        get => _creatureSizeCategories;
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
            return RuleBooks?.FirstOrDefault(x => x.Id == Race.RuleBook?.Id);
        }
        set => Race.RuleBook = value;
    }

    public ObservableCollection<RuleBook> RuleBooks
    {
        get => _ruleBooks;
        private set
        {
            _ruleBooks = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SelectedRuleBook));
        }
    }

    #endregion

    public RaceEditorViewModel(Race race, NavigateToPageCommand navigateToPageCommand, IDataService<Race> raceDataService,
        IDataService<CreatureType> creatureTypeDataService, IDataService<CreatureSubType> creatureSubTypeDataService,
        IDataService<CreatureSizeCategory> creatureSizeCategoryDataService, IDataService<RuleBook> ruleBookDataService,
        IEnumerable<CultureInfo> cultureInfos, IDataService<RaceTranslation> raceTranslationDataService)
        : base(navigateToPageCommand)
    {
        Race = race;
        _raceDataService = raceDataService;
        _cultureInfos = cultureInfos;
        _raceTranslationDataService = raceTranslationDataService;

        Task.Run(async () =>
        {
            CreatureTypes = new ObservableCollection<CreatureType>(await creatureTypeDataService.GetAll());
            CreatureSubTypes = new ObservableCollection<CreatureSubType>(await creatureSubTypeDataService.GetAll());
            CreatureSizeCategories = new ObservableCollection<CreatureSizeCategory>(await creatureSizeCategoryDataService.GetAll());
            RuleBooks = new ObservableCollection<RuleBook>(await ruleBookDataService.GetAll());
        });
    }
}