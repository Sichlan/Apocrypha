using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Common.Translation;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.Helpers.Commands;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Services.ViewModelConverter;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.ViewModels.Navigation.Tools;

public delegate PoisonCrafterViewModel CreatePoisonCrafterViewModel(Poison poison);

public class PoisonCrafterViewModel : NavigableViewModel
{
    private ObservableCollection<PoisonDeliveryMethod> _poisonDeliveryMethods;


    private List<Tuple<int?, int?, int>> _marketPriceMultipliers = new()
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
    private PoisonDeliveryMethod _selectedDeliveryMethod;
    private int _toxicity;
    private ObservableCollection<PoisonPhaseViewModel> _poisonPhases;

    private ICollection<Condition> _conditions;
    private ICollection<PoisonDuration> _poisonDurations;
    private ICollection<PoisonDamageTarget> _poisonDamageTargets;
    private ICollection<PoisonSpecialEffect> _poisonSpecialEffects;

    public int Id
    {
        get
        {
            return _id;
        }
        set
        {
            if (value == _id)
                return;

            _id = value;
            OnPropertyChanged();
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value == _name)
                return;

            _name = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CraftDc));
            OnPropertyChanged(nameof(Summary));
        }
    }

    public string Description
    {
        get
        {
            return _description;
        }
        set
        {
            if (value == _description)
                return;

            _description = value;
            OnPropertyChanged();
        }
    }

    public PoisonDeliveryMethod DeliveryMethod
    {
        get
        {
            return _selectedDeliveryMethod;
        }
        set
        {
            if (Equals(value, _selectedDeliveryMethod))
                return;

            _selectedDeliveryMethod = value;
            OnPropertyChanged();
        }
    }

    public int Toxicity
    {
        get
        {
            return _toxicity;
        }
        set
        {
            if (value == _toxicity)
                return;

            _toxicity = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ToxicityDifficultyClass));
            OnPropertyChanged(nameof(CraftDc));
            OnPropertyChanged(nameof(Summary));
        }
    }

    public ObservableCollection<PoisonPhaseViewModel> PoisonPhases
    {
        get
        {
            return _poisonPhases;
        }
        set
        {
            if (Equals(value, _poisonPhases))
                return;

            _poisonPhases = value;
            OnPropertyChanged();
        }
    }

    public TranslationCollection<PoisonTranslation> PoisonTranslations { get; init; }

    #endregion

    public PoisonDeliveryMethod SelectedDeliveryMethod
    {
        get
        {
            return PoisonDeliveryMethods?.FirstOrDefault(x => x.Id == DeliveryMethod?.Id);
        }
        set
        {
            DeliveryMethod = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CraftDc));
            OnPropertyChanged(nameof(Summary));
        }
    }

    public ObservableCollection<PoisonDeliveryMethod> PoisonDeliveryMethods
    {
        get
        {
            return _poisonDeliveryMethods;
        }
        private set
        {
            _poisonDeliveryMethods = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SelectedDeliveryMethod));
        }
    }

    public int? ToxicityDifficultyClass
    {
        get
        {
            return Toxicity - 10;
        }
    }

    public IRelayCommand SavePoisonCommand { get; set; }
    public ICommand AddPoisonPhaseCommand { get; }
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

    public int MarketPrice
    {
        get
        {
            int multiplier =
                (_marketPriceMultipliers.FirstOrDefault(x => (x.Item1 == null || CraftDc >= x.Item1) && (x.Item2 == null || CraftDc <= x.Item2))?.Item3)
                .GetValueOrDefault(1);

            return CraftDc * multiplier;
        }
    }

    public double CraftingCost
    {
        get
        {
            return MarketPrice * 0.75;
        }
    }

    public PoisonCrafterViewModel(NavigateToPageCommand navigateToPageCommand,
        IDataService<Poison> poisonDataService,
        IViewModelConverter<PoisonCrafterViewModel, Poison> viewModelConverter,
        IDataService<PoisonDeliveryMethod> poisonDeliveryMethodDataService,
        IDataService<Condition> conditionDataService,
        IDataService<PoisonDuration> durationDataService,
        IDataService<PoisonDamageTarget> damageTargetDataService,
        IDataService<PoisonSpecialEffect> specialEffectDataService)
        : base(navigateToPageCommand)
    {
        SavePoisonCommand = new SaveDataCommand<PoisonCrafterViewModel, Poison>(poisonDataService, viewModelConverter);
        AddPoisonPhaseCommand = new RelayCommand(ExecuteAddPoisonPhaseCommand, CanExecuteAddPoisonPhaseCommand);
        DeletePoisonPhaseCommand = new RelayCommand<PoisonPhaseViewModel>(ExecuteDeletePoisonPhaseCommand, CanExecuteDeletePoisonPhaseCommand);

        PoisonPhases = new ObservableCollection<PoisonPhaseViewModel>();

        Task.Run(async () =>
        {
            PoisonDeliveryMethods = new ObservableCollection<PoisonDeliveryMethod>(await poisonDeliveryMethodDataService.GetAll());

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
                }
            };
        });
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
            PoisonPhases.Remove(phase);
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