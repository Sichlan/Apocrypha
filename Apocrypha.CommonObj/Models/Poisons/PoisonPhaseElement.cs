using System.ComponentModel.DataAnnotations;
using Apocrypha.CommonObject.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonPhaseElement : DatabaseObject
{
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public PoisonPhase PoisonPhase { get; set; }

    // Dice DC is calculated by (MAX DMG - MIN DMG) / 2 V
    public int? DamageDiceCount { get; set; }
    public int? DamageDiceSize { get; set; }
    public PoisonDamageTarget PoisonDamageTarget { get; set; }
    public PoisonDuration PoisonDuration { get; set; }
    public Condition Condition { get; set; }
    public PoisonSpecialEffect PoisonSpecialEffect { get; set; }
}