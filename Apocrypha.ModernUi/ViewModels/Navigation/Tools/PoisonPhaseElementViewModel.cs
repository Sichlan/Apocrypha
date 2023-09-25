using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.ModernUi.ViewModels.Common;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.ViewModels.Navigation.Tools;

public class PoisonPhaseElementViewModel : BaseViewModel
{
    public List<Condition> Conditions { get; set; }
    public List<PoisonDuration> PoisonDurations { get; set; }
    public List<PoisonDamageTarget> PoisonDamageTargets { get; set; }
    public List<PoisonSpecialEffect> PoisonSpecialEffects { get; set; }

    #region Model Properties

    private int? _damageDiceSize;
    private int? _damageDiceCount;
    private Condition _condition;
    private PoisonDuration _poisonDuration;
    private PoisonDamageTarget _poisonDamageTarget;
    private PoisonSpecialEffect _poisonSpecialEffect;

    public int Id { get; set; }

    public int? DamageDiceSize
    {
        get
        {
            return _damageDiceSize;
        }
        set
        {
            if (value == _damageDiceSize)
                return;

            _damageDiceSize = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(DamageCraftDcModifier));
            OnPropertyChanged(nameof(PhaseElementDescription));
        }
    }

    public int? DamageDiceCount
    {
        get
        {
            return _damageDiceCount;
        }
        set
        {
            if (value == _damageDiceCount)
                return;

            _damageDiceCount = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(DamageCraftDcModifier));
            OnPropertyChanged(nameof(PhaseElementDescription));
        }
    }

    public Condition Condition
    {
        get
        {
            return _condition;
        }
        set
        {
            if (Equals(value, _condition))
                return;

            _condition = value;
            OnPropertyChanged();
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

    public PoisonDamageTarget PoisonDamageTarget
    {
        get
        {
            return _poisonDamageTarget;
        }
        set
        {
            if (Equals(value, _poisonDamageTarget))
                return;

            _poisonDamageTarget = value;
            OnPropertyChanged();
        }
    }

    public PoisonSpecialEffect PoisonSpecialEffect
    {
        get
        {
            return _poisonSpecialEffect;
        }
        set
        {
            if (Equals(value, _poisonSpecialEffect))
                return;

            _poisonSpecialEffect = value;
            OnPropertyChanged();
        }
    }

    #endregion

    public PoisonPhaseElementViewModel(ICollection<Condition> conditions, ICollection<PoisonDuration> poisonDurations,
        ICollection<PoisonDamageTarget> poisonDamageTargets, ICollection<PoisonSpecialEffect> poisonSpecialEffects)
    {
        Conditions = conditions.ToList();
        PoisonDurations = poisonDurations.ToList();
        PoisonDamageTargets = poisonDamageTargets.ToList();
        PoisonSpecialEffects = poisonSpecialEffects.ToList();

        ResetDamageCommand = new RelayCommand(ExecuteResetDamageCommand);
        ResetConditionCommand = new RelayCommand(ExecuteResetConditionCommand);
        ResetEffectCommand = new RelayCommand(ExecuteResetEffectCommand);
    }

    private void ExecuteResetEffectCommand()
    {
        SelectedPoisonSpecialEffect = null;
    }

    private void ExecuteResetConditionCommand()
    {
        SelectedCondition = null;
        SelectedPoisonDuration = null;
    }

    private void ExecuteResetDamageCommand()
    {
        DamageDiceCount = null;
        DamageDiceSize = null;
        SelectedPoisonDamageTarget = null;
    }

    public Condition SelectedCondition
    {
        get
        {
            return Conditions?.FirstOrDefault(x => x?.Id == Condition?.Id);
        }
        set
        {
            Condition = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ConditionCraftDcModifier));
            OnPropertyChanged(nameof(CombinedCraftModifier));
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
            OnPropertyChanged(nameof(ConditionCraftDcModifier));
            OnPropertyChanged(nameof(CombinedCraftModifier));
        }
    }

    public PoisonDamageTarget SelectedPoisonDamageTarget
    {
        get
        {
            return PoisonDamageTargets?.FirstOrDefault(x => x?.Id == PoisonDamageTarget?.Id);
        }
        set
        {
            PoisonDamageTarget = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(DamageCraftDcModifier));
            OnPropertyChanged(nameof(CombinedCraftModifier));
            OnPropertyChanged(nameof(PhaseElementDescription));
        }
    }

    public PoisonSpecialEffect SelectedPoisonSpecialEffect
    {
        get
        {
            return PoisonSpecialEffects?.FirstOrDefault(x => x?.Id == PoisonSpecialEffect?.Id);
        }
        set
        {
            PoisonSpecialEffect = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(CombinedCraftModifier));
        }
    }

    public int DamageCraftDcModifier
    {
        get
        {
            if (DamageDiceCount != null && DamageDiceSize != null && SelectedPoisonDamageTarget != null)
                // Dice DC is calculated by (MAX DMG - MIN DMG) / 2
                return (int)Math.Floor((double)(DamageDiceCount.GetValueOrDefault(0) *
                                                DamageDiceSize.GetValueOrDefault(0) -
                                                DamageDiceCount.GetValueOrDefault(0)) / 2) + SelectedPoisonDamageTarget.CraftModifier;

            return 0;
        }
    }

    public string PhaseElementDescription
    {
        get
        {
            const char separator = ',';
            var damage = DamageDiceCount != null && DamageDiceSize != null && SelectedPoisonDamageTarget != null
                ? $"{DamageDiceCount}d{DamageDiceSize} {SelectedPoisonDamageTarget.Name}"
                : "";
            var condition = SelectedCondition != null && (SelectedCondition.WithoutDuration || SelectedPoisonDuration != null)
                ? $"{SelectedCondition.Name} {SelectedPoisonDuration?.AsString}"
                : "";
            var special = SelectedPoisonSpecialEffect != null ? SelectedPoisonSpecialEffect.Name : "";

            return
                $"{(string.IsNullOrEmpty(damage) ? "" : $"{separator}{damage}")}{(string.IsNullOrEmpty(condition) ? "" : $"{separator}{condition}")}{(string.IsNullOrEmpty(special) ? "" : $"{separator}{special}")}"
                    .Trim(separator);
        }
    }

    public int ConditionCraftDcModifier
    {
        get
        {
            return (SelectedCondition?.PoisonCraftModifier).GetValueOrDefault(0) +
                   (SelectedCondition?.WithoutDuration == true ? 0 : (SelectedPoisonDuration?.CraftModifier).GetValueOrDefault(0));
        }
    }

    public int CombinedCraftModifier
    {
        get
        {
            return DamageCraftDcModifier + ConditionCraftDcModifier + (SelectedPoisonSpecialEffect?.CraftModifier).GetValueOrDefault(0);
        }
    }

    public ICommand ResetDamageCommand { get; }
    public ICommand ResetConditionCommand { get; }
    public ICommand ResetEffectCommand { get; }
}