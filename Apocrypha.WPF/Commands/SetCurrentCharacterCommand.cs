using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.WPF.State.Characters;
using Apocrypha.WPF.State.Navigators;

namespace Apocrypha.WPF.Commands
{
    public class SetCurrentCharacterCommand : AsyncCommandBase
    {
        private readonly Character _character;
        private readonly ICharacterStore _characterStore;
        private readonly IRenavigator _renavigator;

        public SetCurrentCharacterCommand(Character character, ICharacterStore characterStore, IRenavigator renavigator = null)
        {
            _character = character;
            _characterStore = characterStore;
            _renavigator = renavigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _characterStore.CurrentCharacter = _character;
            
            if (_renavigator != null)
                _renavigator.Renavigate();
        }

        public override bool CanExecuteAsync(object parameter)
        {
            return true;
        }
    }
}