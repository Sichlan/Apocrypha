using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.ModernUi.ViewModels.Common;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.ViewModels.Tools;

public class PoisonPhaseElementViewModel : BaseViewModel
{
    public List<Condition> Conditions { get; set; }
    public List<PoisonDuration> PoisonDurations { get; set; }
    public List<PoisonDamageTarget> PoisonDamageTargets { get; set; }
    public List<PoisonSpecialEffect> PoisonSpecialEffects { get; set; }

    #region Model Properties

    private int? _damageDiceSize;
    private int? _damageDiceCount;
    private int? _conditionId;
    private int? _poisonDurationId;
    private int? _poisonDamageTargetId;
    private int? _poisonSpecialEffectId;

    public int Id { get; init; }

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

    public int? ConditionId
    {
        get
        {
            return _conditionId;
        }
        set
        {
            if (Equals(value, _conditionId))
                return;

            _conditionId = value;
            OnPropertyChanged();
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
        }
    }

    public int? PoisonDamageTargetId
    {
        get
        {
            return _poisonDamageTargetId;
        }
        set
        {
            if (Equals(value, _poisonDamageTargetId))
                return;

            _poisonDamageTargetId = value;
            OnPropertyChanged();
        }
    }

    public int? PoisonSpecialEffectId
    {
        get
        {
            return _poisonSpecialEffectId;
        }
        set
        {
            if (Equals(value, _poisonSpecialEffectId))
                return;

            _poisonSpecialEffectId = value;
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
            return Conditions?.FirstOrDefault(x => x?.Id == ConditionId);
        }
        set
        {
            ConditionId = value.Id;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ConditionCraftDcModifier));
            OnPropertyChanged(nameof(CombinedCraftModifier));
        }
    }

    public PoisonDuration SelectedPoisonDuration
    {
        get
        {
            return PoisonDurations?.FirstOrDefault(x => x?.Id == PoisonDurationId);
        }
        set
        {
            PoisonDurationId = value.Id;
            OnPropertyChanged();
            OnPropertyChanged(nameof(ConditionCraftDcModifier));
            OnPropertyChanged(nameof(CombinedCraftModifier));
        }
    }

    public PoisonDamageTarget SelectedPoisonDamageTarget
    {
        get
        {
            return PoisonDamageTargets?.FirstOrDefault(x => x?.Id == PoisonDamageTargetId);
        }
        set
        {
            PoisonDamageTargetId = value.Id;
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
            return PoisonSpecialEffects?.FirstOrDefault(x => x?.Id == PoisonSpecialEffectId);
        }
        set
        {
            PoisonSpecialEffectId = value.Id;
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