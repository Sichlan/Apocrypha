using Apocrypha.CommonObject.Models;

namespace Apocrypha.WPF.State.Races;

public interface IRaceStore : IStateChanger
{
    Race ActiveRace { get; set; }
    bool HasActiveRace { get; }
}