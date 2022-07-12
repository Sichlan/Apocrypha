using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.WPF.Commands;
using Apocrypha.WPF.State.Characters;

namespace Apocrypha.WPF.ViewModels
{
    public class CharacterProfileViewModel : BaseViewModel
    {
        private readonly ICharacterStore _characterStore;
        private readonly IDataService<Allignment> _allignmentService;

        public CharacterProfileViewModel(ICharacterStore characterStore, IDataService<Allignment> allignmentService)
        {
            _characterStore = characterStore;
            _allignmentService = allignmentService;

            _characterStore.StateChange += CharacterStoreOnStateChange;

            ChangeCharacterAllignmentCommand = new ChangeCharacterAllignmentCommand(_characterStore);

            InitAllignmentProperties().Wait();
        }

        private async Task InitAllignmentProperties()
        {
            var allignments = (await _allignmentService.GetAll()).ToList();

            AllignmentLG = allignments.FirstOrDefault(x => x.Abbreviation == "LG");
            AllignmentLN = allignments.FirstOrDefault(x => x.Abbreviation == "LN");
            AllignmentLE = allignments.FirstOrDefault(x => x.Abbreviation == "LE");
            AllignmentNG = allignments.FirstOrDefault(x => x.Abbreviation == "NG");
            AllignmentTN = allignments.FirstOrDefault(x => x.Abbreviation == "TN");
            AllignmentNE = allignments.FirstOrDefault(x => x.Abbreviation == "NE");
            AllignmentCG = allignments.FirstOrDefault(x => x.Abbreviation == "CG");
            AllignmentCN = allignments.FirstOrDefault(x => x.Abbreviation == "CN");
            AllignmentCE = allignments.FirstOrDefault(x => x.Abbreviation == "CE");
        }

        private void CharacterStoreOnStateChange()
        {
            OnPropertyChanged(nameof(CharacterName));
            OnPropertyChanged(nameof(DisplayName));
            OnPropertyChanged(nameof(CharacterHasDisplayName));
            OnPropertyChanged(nameof(TrueAllignment));
        }

        public Allignment AllignmentLG { get; private set; }
        public Allignment AllignmentLN { get; private set; }
        public Allignment AllignmentLE { get; private set; }
        public Allignment AllignmentNG { get; private set; }
        public Allignment AllignmentTN { get; private set; }
        public Allignment AllignmentNE { get; private set; }
        public Allignment AllignmentCG { get; private set; }
        public Allignment AllignmentCN { get; private set; }
        public Allignment AllignmentCE { get; private set; }
        
        public string CharacterName
        {
            get
            {
                return _characterStore.CurrentCharacter.CharacterName;
            }
            set
            {
                _characterStore.CurrentCharacter.CharacterName = value;
                OnPropertyChanged();
            }
        }

        public string DisplayName
        {
            get
            {
                return _characterStore.CurrentCharacter.DisplayName;
            }
            set
            {
                _characterStore.CurrentCharacter.DisplayName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CharacterHasDisplayName));
            }
        }

        public Allignment TrueAllignment
        {
            get
            {
                return _characterStore.CurrentCharacter.TrueAllignment;
            }
            set
            {
                _characterStore.CurrentCharacter.TrueAllignment = value;
                OnPropertyChanged();
            }
        }

        public bool CharacterHasDisplayName
        {
            get
            {
                return !String.IsNullOrEmpty(DisplayName);
            }
        }

        public ICommand ChangeCharacterAllignmentCommand { get; set; }
    }
}