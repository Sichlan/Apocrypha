using Apocrypha.CommonObject.Services.DiceRollerServices;
using Apocrypha.WPF.Commands;
using Apocrypha.WPF.Commands.DiceCommands;
using ICSharpCode.AvalonEdit.Document;

namespace Apocrypha.WPF.ViewModels;

public class DiceRollerViewModel : BaseViewModel
{
    private readonly IDiceRollerService _diceRollerService;

    private string _output;

    public DiceRollerViewModel(IDiceRollerService diceRollerService)
    {
        _diceRollerService = diceRollerService;

        SetCommands();
    }

    private void SetCommands()
    {
        ClearHistoryCommand = new ClearRollHistoryCommand(this);
        RollDiceCommand = new RollDiceInDiceRollerViewModelCommand(_diceRollerService, this);
    }

    public TextDocument TextDocument { get; set; } = new("");

    public string Output
    {
        get
        {
            return _output;
        }
        set
        {
            _output = value;
            OnPropertyChanged(nameof(Output));
        }
    }

    public AsyncCommandBase RollDiceCommand { get; private set; }
    public AsyncCommandBase ClearHistoryCommand { get; private set; }
}