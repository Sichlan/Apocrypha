﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Common.Translation;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.Helpers;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Helpers.Commands.SaveData;
using Apocrypha.ModernUi.Helpers.Validation;
using Apocrypha.ModernUi.Resources.Localization;
using Apocrypha.ModernUi.Services.State.Navigation;
using Apocrypha.ModernUi.Services.State.Users;
using Apocrypha.ModernUi.Services.UserInformationService;
using Apocrypha.ModernUi.Services.ViewModelConverter;
using Apocrypha.ModernUi.ViewModels.Navigation;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.ViewModels.Tools;

public delegate PoisonCrafterViewModel CreatePoisonCrafterViewModel(Poison poison);

public class PoisonCrafterViewModel : NavigableViewModel
{
    private ObservableCollection<PoisonDeliveryMethod> _poisonDeliveryMethods;
    private readonly IDataService<PoisonPhase> _poisonPhaseDataService;
    private readonly IUserStore _userStore;


    private readonly List<Tuple<int?, int?, int>> _marketPriceMultipliers = new()
    {
        new(null, 11, 1),
        new(11, 13, 3),
        new(14, 17, 8),
        new(18, 21, 15),
        new(22, 25, 25),
        new(26, 29, 35),
        new(30, 33, 50),
        new(34, 37, 70),
        new(38, 41, 90),
        new(42, 45, 120),
        new(46, 49, 150),
        new(50, null, 200)
    };


    #region Model Properties

    private int _id;
    private string _name;
    private string _description;
    private int? _selectedDeliveryMethodId;
    private int _toxicity;
    private ObservableCollection<PoisonPhaseViewModel> _poisonPhases;

    private ICollection<Condition> _conditions;
    private ICollection<PoisonDuration> _poisonDurations;
    private ICollection<PoisonDamageTarget> _poisonDamageTargets;
    private ICollection<PoisonSpecialEffect> _poisonSpecialEffects;
    private int? _creatorId;

    public int Id
    {
        get => _id;
        set
        {
            if (value == _id)
                return;

            _id = value;
            OnPropertyChanged();
        }
    }

    [Required]
    public string Name
    {
        get => _name;
        set
        {
            if (value == _name)
                return;

            _name = value;
            Validate(value);
            OnPropertyChanged();
            OnPropertyChanged(nameof(CraftDc));
            OnPropertyChanged(nameof(Summary));
        }
    }

    public string Description
    {
        get => _description;
        set
        {
            if (value == _description)
                return;

            _description = value;
            OnPropertyChanged();
        }
    }

    public int? DeliveryMethodId
    {
        get => _selectedDeliveryMethodId;
        set
        {
            if (Equals(value, _selectedDeliveryMethodId))
                return;

            _selectedDeliveryMethodId = value;

            Validate(value);
            OnPropertyChanged();
        }
    }

    public int? CreatorId
    {
        get => _creatorId;
        set
        {
            if (value == _creatorId)
                return;

            _creatorId = value;
            OnPropertyChanged();
        }
    }

    [GreaterThan(0)]
    public int Toxicity
    {
        get => _toxicity;
        set
        {
            if (value == _toxicity)
                return;

            _toxicity = value;
            Validate(value);
            OnPropertyChanged();
            OnPropertyChanged(nameof(ToxicityDifficultyClass));
            OnPropertyChanged(nameof(CraftDc));
            OnPropertyChanged(nameof(Summary));
        }
    }

    [RequireElements]
    public ObservableCollection<PoisonPhaseViewModel> PoisonPhases
    {
        get => _poisonPhases;
        set
        {
            if (Equals(value, _poisonPhases))
                return;

            _poisonPhases = value;
            Validate(value);
            OnPropertyChanged();
        }
    }

    public TranslationCollection<PoisonTranslation> PoisonTranslations { get; set; }

    #endregion

    public override string ViewModelTitle => Localization.PoisonCrafterViewModelTitle;

    [Required]
    public PoisonDeliveryMethod SelectedDeliveryMethod
    {
        get
        {
            return PoisonDeliveryMethods?.FirstOrDefault(x => x.Id == DeliveryMethodId);
        }
        set
        {
            DeliveryMethodId = value.Id;
            Validate(value);
            OnPropertyChanged();
            OnPropertyChanged(nameof(CraftDc));
            OnPropertyChanged(nameof(Summary));
        }
    }

    public ObservableCollection<PoisonDeliveryMethod> PoisonDeliveryMethods
    {
        get => _poisonDeliveryMethods;
        private set
        {
            _poisonDeliveryMethods = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SelectedDeliveryMethod));
        }
    }

    public int? ToxicityDifficultyClass =>
        Toxicity - 10;

    public ISaveDataCommand SavePoisonCommand { get; }
    public ICommand CancelPoisonCommand { get; }
    public ICommand AddPoisonPhaseCommand { get; }

    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public ICommand DeletePoisonPhaseCommand { get; }

    public string Summary
    {
        get
        {
            return $@"{Name ?? "-"}: {SelectedDeliveryMethod?.Name ?? "-"} DC {Toxicity}
Phases:
{(string.Join("\n", PoisonPhases.Select(x => x.PhaseDescription)))}

Craft DC: {CraftDc} ({CraftDc + 5} if unknown)
Market Price: {MarketPrice:N2} GP ({CraftingCost:N2} GP to craft)";
        }
    }

    public int CraftDc
    {
        get
        {
            return 10
                   + (SelectedDeliveryMethod?.CraftDifficultyClassModifier).GetValueOrDefault(0)
                   + ToxicityDifficultyClass.GetValueOrDefault(0)
                   + PoisonPhases.Sum(x => x.CraftModifier);
        }
    }

    private int MarketPrice
    {
        get
        {
            int multiplier =
                (_marketPriceMultipliers.FirstOrDefault(x => (x.Item1 == null || CraftDc >= x.Item1) && (x.Item2 == null || CraftDc <= x.Item2))?.Item3)
                .GetValueOrDefault(1);

            return CraftDc * multiplier;
        }
    }

    private double CraftingCost =>
        MarketPrice * 0.75;

    public bool CanUserEditPoison =>
        CreatorId == null || (_userStore.CurrentUser?.Id == CreatorId);

    public PoisonCrafterViewModel(NavigateToPageCommand navigateToPageCommand,
        IDataService<Poison> poisonDataService,
        IViewModelConverter<PoisonCrafterViewModel, Poison> viewModelConverter,
        IDataService<PoisonDeliveryMethod> poisonDeliveryMethodDataService,
        IDataService<Condition> conditionDataService,
        IDataService<PoisonDuration> durationDataService,
        IDataService<PoisonDamageTarget> damageTargetDataService,
        IDataService<PoisonSpecialEffect> specialEffectDataService,
        IDataService<PoisonPhase> poisonPhaseDataService,
        INavigationService navigationService,
        IUserStore userStore,
        NavigateBackwardsCommand navigateBackwardsCommand,
        IUserInformationMessageService userInformationMessageService,
        IDataService<PoisonPhaseElement> poisonPhaseElementDataService)
        : base(navigateToPageCommand)
    {
        _poisonPhaseDataService = poisonPhaseDataService;
        _userStore = userStore;

        SavePoisonCommand = new SaveDataCommand<PoisonCrafterViewModel, Poison>(poisonDataService, viewModelConverter, userInformationMessageService,
            CanExecuteSavePoisonCommand);
        CancelPoisonCommand = navigateBackwardsCommand;
        AddPoisonPhaseCommand = new RelayCommand(ExecuteAddPoisonPhaseCommand, CanExecuteAddPoisonPhaseCommand);
        DeletePoisonPhaseCommand = new RelayCommand<PoisonPhaseViewModel>(ExecuteDeletePoisonPhaseCommand, CanExecuteDeletePoisonPhaseCommand);

        PoisonPhases ??= new ObservableCollection<PoisonPhaseViewModel>();
        PoisonTranslations ??= new TranslationCollection<PoisonTranslation>();

        // This will be set to true in OnNavigateTo()
        ValidationEnabled = false;

        _userStore.StateChange += () =>
        {
            DispatcherHelper.RunOnMainThread(() =>
            {
                OnPropertyChanged(nameof(CanUserEditPoison));
                SavePoisonCommand.NotifyCanExecuteChanged();
            });
        };

        if (Id == 0)
            SavePoisonCommand.StagePreExecutionAction(() =>
            {
                ValidateAll();

                if (HasErrors)
                    SavePoisonCommand.CancelExecution(false, string.Join("\n", GetAllErrors().Select(x => $"-{x}")));

                if (_userStore.CurrentUser != null)
                    CreatorId = _userStore.CurrentUser.Id;
            });

        SavePoisonCommand.StagePostExecutionAction(() => navigationService.TryGoBack());

        Task.Run(async () =>
        {
            PoisonDeliveryMethods = new ObservableCollection<PoisonDeliveryMethod>(await poisonDeliveryMethodDataService.GetAll());

            Validate(SelectedDeliveryMethod, nameof(SelectedDeliveryMethod));

            _conditions = (await conditionDataService.GetAll()).ToList();
            _poisonDurations = (await durationDataService.GetAll()).ToList();
            _poisonDamageTargets = (await damageTargetDataService.GetAll()).ToList();
            _poisonSpecialEffects = (await specialEffectDataService.GetAll()).ToList();

            PoisonPhases.CollectionChanged += (_, _) =>
            {
                foreach (var poisonPhase in PoisonPhases)
                {
                    poisonPhase.PhaseNumber = PoisonPhases.IndexOf(poisonPhase) + 1;
                    poisonPhase.PropertyChanged -= PoisonPhaseOnPropertyChanged;
                    poisonPhase.PropertyChanged += PoisonPhaseOnPropertyChanged;
                    poisonPhase.PhaseElementRemoved += list =>
                    {
                        SavePoisonCommand.StagePreExecutionAction(() =>
                        {
                            foreach (var poisonPhaseElementViewModel in list.Where(x => x.Id > 0))
                            {
                                poisonPhaseElementDataService.Delete(poisonPhaseElementViewModel.Id);
                            }
                        });
                    };
                }

                OnPropertyChanged(nameof(CraftDc));
                OnPropertyChanged(nameof(Summary));
                Validate(PoisonPhases, nameof(PoisonPhases));
            };
        });
    }

    public override void OnNavigateTo()
    {
        base.OnNavigateTo();
        ValidationEnabled = true;
    }

    public override void OnNavigateFrom()
    {
        base.OnNavigateFrom();
        ValidationEnabled = false;
    }

    private bool CanExecuteSavePoisonCommand()
    {
        return (CreatorId == null
                || Id == 0
                || _userStore.CurrentUser?.Id == CreatorId);
    }

    private void PoisonPhaseOnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        OnPropertyChanged(nameof(CraftDc));
        OnPropertyChanged(nameof(Summary));
    }

    private bool CanExecuteDeletePoisonPhaseCommand(object parameter)
    {
        return true;
    }

    private void ExecuteDeletePoisonPhaseCommand(object parameter)
    {
        if (parameter is PoisonPhaseViewModel phase
            && PoisonPhases.Contains(phase))
        {
            if (phase.Id > 0
                && _poisonPhaseDataService.GetById(phase.Id) != null)
                SavePoisonCommand.StagePreExecutionAction(() => _poisonPhaseDataService.Delete(phase.Id));

            PoisonPhases.Remove(phase);
        }
    }

    private bool CanExecuteAddPoisonPhaseCommand()
    {
        return true;
    }

    private void ExecuteAddPoisonPhaseCommand()
    {
        PoisonPhases ??= new ObservableCollection<PoisonPhaseViewModel>();

        PoisonPhases.Add(new PoisonPhaseViewModel(_conditions, _poisonDurations, _poisonDamageTargets, _poisonSpecialEffects)
        {
            PhaseNumber = PoisonPhases.Any() ? PoisonPhases.Max(x => x.PhaseNumber) + 1 : 1
        });
    }
}