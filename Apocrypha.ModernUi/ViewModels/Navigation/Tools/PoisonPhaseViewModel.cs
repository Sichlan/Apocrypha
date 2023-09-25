using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.ModernUi.ViewModels.Common;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.ViewModels.Navigation.Tools;

public class PoisonPhaseViewModel : BaseViewModel
{
    #region Model Properties

    private int _id;
    private int _phaseNumber;
    private ObservableCollection<PoisonPhaseElementViewModel> _phaseElements;
    private PoisonDuration _poisonDuration;

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
        }
    }

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
            OnPropertyChanged();
        }
    }

    public PoisonDuration SelectedPoisonDuration
    {
        get
        {
            return PoisonDurations?.FirstOrDefault(x => x?.Id == PoisonDuration?.Id);
        }
        set
        {
            PoisonDuration = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CraftModifier));
        }
    }

    public PoisonDuration PoisonDuration
    {
        get
        {
            return _poisonDuration;
        }
        set
        {
            if (Equals(value, _poisonDuration))
                return;

            _poisonDuration = value;
            OnPropertyChanged();
        }
    }

    #endregion

    private ICollection<Condition> _conditions;
    private ICollection<PoisonDuration> _poisonDurations;
    private ICollection<PoisonDamageTarget> _poisonDamageTargets;
    private ICollection<PoisonSpecialEffect> _poisonSpecialEffects;

    public PoisonPhaseViewModel(ICollection<Condition> conditions, ICollection<PoisonDuration> poisonDurations,
        ICollection<PoisonDamageTarget> poisonDamageTargets, ICollection<PoisonSpecialEffect> poisonSpecialEffects)
    {
        _conditions = conditions;
        _poisonDurations = poisonDurations;
        _poisonDamageTargets = poisonDamageTargets;
        _poisonSpecialEffects = poisonSpecialEffects;

        AddPoisonPhaseElement = new RelayCommand(ExecuteAddPoisonPhaseElement, CanExecuteAddPoisonPhaseElement);

        SetupPhaseElementUpdateEventHandler();
    }

    public void SetupPhaseElementUpdateEventHandler()
    {
        PhaseElements ??= new ObservableCollection<PoisonPhaseElementViewModel>();
        PhaseElements.CollectionChanged += (_, _) =>
        {
            foreach (var element in PhaseElements)
            {
                element.PropertyChanged -= ResetPhaseElementUpdateHandler;
                element.PropertyChanged += ResetPhaseElementUpdateHandler;
            }
        };
    }

    private void ResetPhaseElementUpdateHandler(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(PoisonPhaseElementViewModel.CombinedCraftModifier))
            OnPropertyChanged(nameof(CraftModifier));
    }

    public ICommand AddPoisonPhaseElement { get; }

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
}