using Apocrypha.CommonObject.Models;

namespace Apocrypha.WPF.State.Characters;

public interface ICharacterStore : IStateChanger
{
    Character CurrentCharacter { get; set; }
    bool HasActiveCharacter { get; }
}