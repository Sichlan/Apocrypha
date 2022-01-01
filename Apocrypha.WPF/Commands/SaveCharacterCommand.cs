using System;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.WPF.State.Characters;

namespace Apocrypha.WPF.Commands
{
    public class SaveCharacterCommand : AsyncCommandBase
    {
        private readonly ICharacterStore _characterStore;
        private readonly IDataService<Character> _characterDataService;

        public SaveCharacterCommand(ICharacterStore characterStore, IDataService<Character> characterDataService)
        {
            _characterStore = characterStore;
            _characterDataService = characterDataService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _characterStore.CurrentCharacter.LastModifiedDateTime = DateTime.Now;
            _characterStore.CurrentCharacter = await _characterDataService.Update(_characterStore.CurrentCharacter.Id, _characterStore.CurrentCharacter);
        }

        public override bool CanExecuteAsync(object parameter)
        {
            return true;
        }
    }
}