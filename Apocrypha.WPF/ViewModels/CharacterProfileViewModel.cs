using System.Windows.Input;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.WPF.Commands;
using Apocrypha.WPF.State.Characters;

namespace Apocrypha.WPF.ViewModels;

public class CharacterProfileViewModel : BaseViewModel
{
    private readonly ICharacterStore _characterStore;
    private readonly IDataService<Allignment> _allignmentService;
    private IDataService<Character> _characterDataService;
    private Allignment _allignmentLg;
    private Allignment _allignmentLn;
    private Allignment _allignmentLe;
    private Allignment _allignmentNg;
    private Allignment _allignmentTn;
    private Allignment _allignmentNe;
    private Allignment _allignmentCg;
    private Allignment _allignmentCn;
    private Allignment _allignmentCe;

    public CharacterProfileViewModel(ICharacterStore characterStore, IDataService<Allignment> allignmentService,
        IDataService<Character> characterDataService)
    {
        _characterStore = characterStore;
        _allignmentService = allignmentService;
        _characterDataService = characterDataService;

        _characterStore.StateChange += CharacterStoreOnStateChange;

        SetCommands();
        InitAllignmentProperties();
    }

    private void SetCommands()
    {
        ChangeCharacterAllignmentCommand = new ChangeCharacterAllignmentCommand(_characterStore);
        SaveCharacterCommand = new SaveCharacterCommand(_characterStore, _characterDataService);
    }

    private async void InitAllignmentProperties()
    {
        var allignments = (await _allignmentService.GetAll()).ToList();

        AllignmentLg = allignments.FirstOrDefault(x => x.Abbreviation == "LG");
        AllignmentLn = allignments.FirstOrDefault(x => x.Abbreviation == "LN");
        AllignmentLe = allignments.FirstOrDefault(x => x.Abbreviation == "LE");
        AllignmentNg = allignments.FirstOrDefault(x => x.Abbreviation == "NG");
        AllignmentTn = allignments.FirstOrDefault(x => x.Abbreviation == "TN");
        AllignmentNe = allignments.FirstOrDefault(x => x.Abbreviation == "NE");
        AllignmentCg = allignments.FirstOrDefault(x => x.Abbreviation == "CG");
        AllignmentCn = allignments.FirstOrDefault(x => x.Abbreviation == "CN");
        AllignmentCe = allignments.FirstOrDefault(x => x.Abbreviation == "CE");
    }

    private void CharacterStoreOnStateChange()
    {
        OnPropertyChanged(nameof(CharacterName));
        OnPropertyChanged(nameof(DisplayName));
        OnPropertyChanged(nameof(CharacterHasDisplayName));
        OnPropertyChanged(nameof(TrueAllignment));
    }

    public Allignment AllignmentLg
    {
        get
        {
            return _allignmentLg;
        }
        private set
        {
            _allignmentLg = value;
            OnPropertyChanged();
        }
    }

    public Allignment AllignmentLn
    {
        get
        {
            return _allignmentLn;
        }
        private set
        {
            _allignmentLn = value;
            OnPropertyChanged();
        }
    }

    public Allignment AllignmentLe
    {
        get
        {
            return _allignmentLe;
        }
        private set
        {
            _allignmentLe = value;
            OnPropertyChanged();
        }
    }

    public Allignment AllignmentNg
    {
        get
        {
            return _allignmentNg;
        }
        private set
        {
            _allignmentNg = value;
            OnPropertyChanged();
        }
    }

    public Allignment AllignmentTn
    {
        get
        {
            return _allignmentTn;
        }
        private set
        {
            _allignmentTn = value;
            OnPropertyChanged();
        }
    }

    public Allignment AllignmentNe
    {
        get
        {
            return _allignmentNe;
        }
        private set
        {
            _allignmentNe = value;
            OnPropertyChanged();
        }
    }

    public Allignment AllignmentCg
    {
        get
        {
            return _allignmentCg;
        }
        private set
        {
            _allignmentCg = value;
            OnPropertyChanged();
        }
    }

    public Allignment AllignmentCn
    {
        get
        {
            return _allignmentCn;
        }
        private set
        {
            _allignmentCn = value;
            OnPropertyChanged();
        }
    }

    public Allignment AllignmentCe
    {
        get
        {
            return _allignmentCe;
        }
        private set
        {
            _allignmentCe = value;
            OnPropertyChanged();
        }
    }

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
            return !string.IsNullOrEmpty(DisplayName);
        }
    }

    public ICommand ChangeCharacterAllignmentCommand { get; set; }
    public AsyncCommandBase SaveCharacterCommand { get; set; }
}