using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Input;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.ModernUi.Helpers.Validation;
using Apocrypha.ModernUi.ViewModels.Common;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.ViewModels.Tools;

public class PoisonPhaseViewModel : BaseViewModel
{
    public event Action<List<PoisonPhaseElementViewModel>> PhaseElementRemoved;

    #region Model Properties

    private int _id;
    private int _phaseNumber;
    private int? _poisonDurationId;
    private ObservableCollection<PoisonPhaseElementViewModel> _phaseElements;

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

    public int PhaseNumber
    {
        get
        {
            return _phaseNumber;
        }
        set
        {
            if (value == _phaseNumber)
                return;

            _phaseNumber = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CraftModifier));
            Validate(SelectedPoisonDuration, nameof(SelectedPoisonDuration));
        }
    }

    [RequireElements]
    public ObservableCollection<PoisonPhaseElementViewModel> PhaseElements
    {
        get
        {
            return _phaseElements;
        }
        set
        {
            if (Equals(value, _phaseElements))
                return;

            _phaseElements = value;

            Validate(PhaseElements);
            OnPropertyChanged();
        }
    }

    [CustomValidation(typeof(PoisonPhaseViewModel), nameof(ValidatePoisonPhaseDuration))]
    public PoisonDuration SelectedPoisonDuration
    {
        get
        {
            return PoisonDurations?.FirstOrDefault(x => x?.Id == PoisonDurationId);
        }
        set
        {
            PoisonDurationId = value.Id;
            Validate(value);
            OnPropertyChanged();
            OnPropertyChanged(nameof(CraftModifier));
        }
    }

    public int? PoisonDurationId
    {
        get
        {
            return _poisonDurationId;
        }
        set
        {
            if (Equals(value, _poisonDurationId))
                return;

            _poisonDurationId = value;
            OnPropertyChanged();
            Validate(SelectedPoisonDuration, nameof(SelectedPoisonDuration));
        }
    }

    #endregion

    private readonly ICollection<Condition> _conditions;
    private readonly ICollection<PoisonDuration> _poisonDurations;
    private readonly ICollection<PoisonDamageTarget> _poisonDamageTargets;
    private readonly ICollection<PoisonSpecialEffect> _poisonSpecialEffects;

    public PoisonPhaseViewModel(ICollection<Condition> conditions, ICollection<PoisonDuration> poisonDurations,
        ICollection<PoisonDamageTarget> poisonDamageTargets, ICollection<PoisonSpecialEffect> poisonSpecialEffects)
    {
        _conditions = conditions;
        _poisonDurations = poisonDurations;
        _poisonDamageTargets = poisonDamageTargets;
        _poisonSpecialEffects = poisonSpecialEffects;

        AddPoisonPhaseElement = new RelayCommand(ExecuteAddPoisonPhaseElement, CanExecuteAddPoisonPhaseElement);
        DeletePhaseElementCommand = new RelayCommand<PoisonPhaseElementViewModel>(ExecuteDeletePhaseElementCommand, CanExecuteDeletePhaseElementCommand);

        SetupPhaseElementUpdateEventHandler();
    }

    private bool CanExecuteDeletePhaseElementCommand(PoisonPhaseElementViewModel obj)
    {
        return true;
    }

    private void ExecuteDeletePhaseElementCommand(PoisonPhaseElementViewModel obj)
    {
        PhaseElements.Remove(obj);
    }

    public void SetupPhaseElementUpdateEventHandler()
    {
        PhaseElements ??= new ObservableCollection<PoisonPhaseElementViewModel>();
        PhaseElements.CollectionChanged += (a, b) =>
        {
            foreach (var element in PhaseElements)
            {
                element.PropertyChanged -= ResetPhaseElementUpdateHandler;
                element.PropertyChanged += ResetPhaseElementUpdateHandler;
            }

            if (b.Action is NotifyCollectionChangedAction.Remove or NotifyCollectionChangedAction.Replace
                && b.OldItems != null)
            {
                var items = b.OldItems.OfType<PoisonPhaseElementViewModel>().ToList();

                if (items.Any())
                    PhaseElementRemoved?.Invoke(items);
            }

            Validate(PhaseElements, nameof(PhaseElements));
        };
    }

    private void ResetPhaseElementUpdateHandler(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(PoisonPhaseElementViewModel.CombinedCraftModifier))
            OnPropertyChanged(nameof(CraftModifier));
    }

    public ICommand AddPoisonPhaseElement { get; }
    public ICommand DeletePhaseElementCommand { get; }

    public int CraftModifier
    {
        get
        {
            // For every phase the DC is cumulatively lowered by 1, but can't get less than 1 
            return Math.Max(
                (PhaseElements?.Sum(x => x.CombinedCraftModifier)).GetValueOrDefault() - PhaseNumber + 1 -
                (PhaseNumber == 1 ? 0 : (SelectedPoisonDuration?.CraftModifier).GetValueOrDefault(0)), 1);
        }
    }

    public string PhaseDescription
    {
        get
        {
            return $@"- Phase {PhaseNumber}{(PhaseNumber == 1 ? "" : $" (after {SelectedPoisonDuration?.AsString}):")}
{(string.Join("\n", PhaseElements.Select(x => "\t- " + x.PhaseElementDescription)))}";
        }
    }

    public ICollection<PoisonDuration> PoisonDurations
    {
        get
        {
            return _poisonDurations;
        }
    }

    private bool CanExecuteAddPoisonPhaseElement()
    {
        return true;
    }

    private void ExecuteAddPoisonPhaseElement()
    {
        PhaseElements.Add(new PoisonPhaseElementViewModel(_conditions, PoisonDurations, _poisonDamageTargets, _poisonSpecialEffects));
    }

    public static ValidationResult ValidatePoisonPhaseDuration(object value, ValidationContext c)
    {
        if (c.ObjectInstance is PoisonPhaseViewModel {PhaseNumber: > 1, SelectedPoisonDuration: null} viewModel)
            return new ValidationResult("TODO PHASE DURATION OF SECONDARY PHASES MAY NOT BE NULL", new[] {nameof(viewModel.SelectedPoisonDuration)});

        return ValidationResult.Success;
    }
}