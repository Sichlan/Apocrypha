using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.WPF.State.Characters;

namespace Apocrypha.WPF.Commands
{
    public class SetCurrentCharacterCommand : AsyncCommandBase
    {
        private readonly Character _character;
        private readonly ICharacterStore _characterStore;

        public SetCurrentCharacterCommand(Character character, ICharacterStore characterStore)
        {
            _character = character;
            _characterStore = characterStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _characterStore.CurrentCharacter = _character;
        }
    }
}