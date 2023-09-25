using Apocrypha.CommonObject.Models.Common;

namespace Apocrypha.CommonObject.Models.Poisons;

public class PoisonPhase : DatabaseObject
{
    public Poison Poison { get; set; }
    public ICollection<PoisonPhaseElement> PoisonPhaseElements { get; set; }
    public int PhaseNumber { get; set; }
    public PoisonDuration PoisonPhaseDuration { get; set; }
}