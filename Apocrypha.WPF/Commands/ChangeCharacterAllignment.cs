using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.WPF.State.Characters;

namespace Apocrypha.WPF.Commands
{
    public class ChangeCharacterAllignmentCommand : AsyncCommandBase
    {
        private readonly ICharacterStore _characterStore;

        public ChangeCharacterAllignmentCommand(ICharacterStore characterStore)
        {
            _characterStore = characterStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is Allignment allignment)
            {
                _characterStore.CurrentCharacter.TrueAllignment = allignment;
            }
        }

        public override bool CanExecuteAsync(object parameter)
        {
            return true;
        }
    }
}