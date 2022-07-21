using Apocrypha.CommonObject.Models;

namespace Apocrypha.WPF.State.Characters;

public class CharacterStore : ICharacterStore
{
    private Character _currentCharacter;

    public Character CurrentCharacter
    {
        get
        {
            return _currentCharacter;
        }
        set
        {
            _currentCharacter = value;
            StateChange?.Invoke();
        }
    }

    public bool HasActiveCharacter
    {
        get
        {
            return CurrentCharacter != null;
        }
    }

    public event Action StateChange;
}