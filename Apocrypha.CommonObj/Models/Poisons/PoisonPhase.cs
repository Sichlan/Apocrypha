using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Apocrypha.CommonObject.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonPhase : DatabaseObject
{
    public int PhaseNumber { get; set; }

    [ForeignKey(nameof(Poison))] public int PoisonId { get; set; }

    [ForeignKey(nameof(PoisonPhaseDuration))]
    public int? PoisonPhaseDurationId { get; set; }

    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Poison Poison { get; set; }

    public PoisonDuration PoisonPhaseDuration { get; set; }

    public ICollection<PoisonPhaseElement> PoisonPhaseElements { get; set; }
}