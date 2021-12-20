using System;
using Apocrypha.CommonObject.Models;

namespace Apocrypha.WPF.State.Characters
{
    public class CharacterStore : ICharacterStore
    {
        private Character _currentCharacter;

        public Character CurrentCharacter
        {
            get => _currentCharacter;
            set
            {
                _currentCharacter = value;
                StateChange?.Invoke();
            }
        }

        public event Action StateChange;
    }
}