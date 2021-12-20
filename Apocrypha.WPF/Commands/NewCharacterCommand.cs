using System.Linq;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.WPF.State.Characters;
using Apocrypha.WPF.State.Navigators.Users;
using Apocrypha.WPF.ViewModels;

namespace Apocrypha.WPF.Commands
{
    public class NewCharacterCommand : AsyncCommandBase
    {
        private readonly CharacterSelectionViewModel _characterSelectionViewModel;
        private readonly ICharacterStore _characterStore;
        private readonly IDataService<User> _userDataService;
        private readonly IUserStore _userStore;

        public NewCharacterCommand(IDataService<User> userDataService, ICharacterStore characterStore, IUserStore userStore,
            CharacterSelectionViewModel characterSelectionViewModel)
        {
            _userDataService = userDataService;
            _characterStore = characterStore;
            _userStore = userStore;
            _characterSelectionViewModel = characterSelectionViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            //TODO: Take character from a creation view.
            var character = new Character
                {CreatorUser = _userStore.CurrentUser};

            _userStore.CurrentUser.Characters.Add(character);
            _userStore.CurrentUser = await _userDataService.Update(_userStore.CurrentUser.Id, _userStore.CurrentUser);

            var updatedCharacter = _userStore.CurrentUser.Characters.Last();
            _characterStore.CurrentCharacter = updatedCharacter;

            await _characterSelectionViewModel.InitData();
        }
    }
}