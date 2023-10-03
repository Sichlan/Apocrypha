using System.ComponentModel.DataAnnotations;
using Apocrypha.CommonObject.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonPhase : DatabaseObject
{
    [Required]
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public Poison Poison { get; set; }

    public ICollection<PoisonPhaseElement> PoisonPhaseElements { get; set; }
    public int PhaseNumber { get; set; }
    [Required] public PoisonDuration PoisonPhaseDuration { get; set; }
}