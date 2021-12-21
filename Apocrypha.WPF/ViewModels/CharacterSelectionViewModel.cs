using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.WPF.Commands;
using Apocrypha.WPF.State.Characters;
using Apocrypha.WPF.State.Navigators.Navigators;
using Apocrypha.WPF.State.Navigators.Users;

namespace Apocrypha.WPF.ViewModels
{
    public class CharacterSelectionViewModel : BaseViewModel
    {
        private readonly IDataService<Character> _characterDataService;
        private readonly ICharacterStore _characterStore;
        private readonly Random _random;
        private readonly ViewModelDelegateRenavigator<CharacterProfileViewModel> _profileRenavigator;
        private readonly IUserStore _userStore;

        public CharacterSelectionViewModel(IDataService<Character> characterDataService, IDataService<User> userDataService, IUserStore userStore,
            ICharacterStore characterStore, Random random, ViewModelDelegateRenavigator<CharacterProfileViewModel> profileRenavigator)
        {
            _characterDataService = characterDataService;
            _userStore = userStore;
            _characterStore = characterStore;
            _random = random;
            _profileRenavigator = profileRenavigator;

            NewCharacterCommand = new NewCharacterCommand(userDataService, characterStore, userStore, this, profileRenavigator);

            InitData();
        }

        public ObservableCollection<CharacterPreviewViewModel> CharacterPreviewViewModels { get; set; }


        public ICommand NewCharacterCommand { get; set; }

        public async Task InitData()
        {
            CharacterPreviewViewModels = new ObservableCollection<CharacterPreviewViewModel>(
                (await _characterDataService.GetAllWhere(x => x.CreatorUser.Id == _userStore.CurrentUser.Id)).Select(character =>
                    new CharacterPreviewViewModel(_random, character, _characterStore, _profileRenavigator)));
            OnPropertyChanged(nameof(CharacterPreviewViewModels));
        }
    }
}