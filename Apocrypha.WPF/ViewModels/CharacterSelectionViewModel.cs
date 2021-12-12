using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.WPF.State.Navigators.Authenticators;

namespace Apocrypha.WPF.ViewModels
{
    public class CharacterSelectionViewModel : BaseViewModel
    {
        private readonly IDataService<Character> _characterDataService;
        private readonly IAuthenticator _authenticator;

        public CharacterSelectionViewModel(IDataService<Character> characterDataService, IAuthenticator authenticator)
        {
            _characterDataService = characterDataService;
            _authenticator = authenticator;

            InitData();
        }

        private async Task InitData()
        {
            Characters = new ObservableCollection<Character>(await _characterDataService.GetAllWhere(x => x.CreatorUser.Id == _authenticator.CurrentUser.Id));
        }

        public ObservableCollection<Character> Characters { get; set; }
    }
}