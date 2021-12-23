using Apocrypha.CommonObject.Models;
using Apocrypha.WPF.State.Characters;

namespace Apocrypha.WPF.ViewModels
{
    public class CharacterProfileViewModel : BaseViewModel
    {
        private readonly ICharacterStore _characterStore;

        public CharacterProfileViewModel(ICharacterStore characterStore)
        {
            _characterStore = characterStore;
            
            _characterStore.StateChange += CharacterStoreOnStateChange;
        }

        private void CharacterStoreOnStateChange()
        {
            OnPropertyChanged(nameof(ActiveCharacter));
        }

        public Character ActiveCharacter =>
            _characterStore.CurrentCharacter;
    }
}