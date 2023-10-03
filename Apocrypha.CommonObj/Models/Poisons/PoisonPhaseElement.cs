using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Apocrypha.CommonObject.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonPhaseElement : DatabaseObject
{
    public int? DamageDiceCount { get; set; }
    public int? DamageDiceSize { get; set; }

    [ForeignKey(nameof(PoisonPhase))] public int PoisonPhaseId { get; set; }

    [ForeignKey(nameof(PoisonDamageTarget))]
    public int? PoisonDamageTargetId { get; set; }

    [ForeignKey(nameof(PoisonDuration))] public int? PoisonDurationId { get; set; }
    [ForeignKey(nameof(Condition))] public int? ConditionId { get; set; }

    [ForeignKey(nameof(PoisonSpecialEffect))]
    public int? PoisonSpecialEffectId { get; set; }

    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public PoisonPhase PoisonPhase { get; set; }

    public PoisonDamageTarget PoisonDamageTarget { get; set; }
    public PoisonDuration PoisonDuration { get; set; }
    public Condition Condition { get; set; }
    public PoisonSpecialEffect PoisonSpecialEffect { get; set; }
}