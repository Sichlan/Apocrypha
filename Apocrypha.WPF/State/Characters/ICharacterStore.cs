using Apocrypha.CommonObject.Models;
using Apocrypha.WPF.State.Navigators;

namespace Apocrypha.WPF.State.Characters
{
    public interface ICharacterStore : IStateChanger
    {
        Character CurrentCharacter { get; set; }
        bool HasActiveCharacter { get; }
    }
}