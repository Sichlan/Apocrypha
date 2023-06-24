using Apocrypha.CommonObject.Services.DiceRollerServices;
using Apocrypha.WPF.ViewModels;

namespace Apocrypha.WPF.Commands.DiceCommands;

public class RollDiceInDiceRollerViewModelCommand : AsyncCommandBase
{
    private readonly IDiceRollerService _diceRollerService;
    private readonly DiceRollerViewModel _diceRollerViewModel;

    public RollDiceInDiceRollerViewModelCommand(IDiceRollerService diceRollerService, DiceRollerViewModel diceRollerViewModel)
    {
        _diceRollerService = diceRollerService;
        _diceRollerViewModel = diceRollerViewModel;
    }

    protected override async Task ExecuteAsync(object parameter)
    {
        var result = await _diceRollerService.RollDice(_diceRollerViewModel.TextDocument.Text);

        var textResult = "";

        for (var i = 0; i < result.Count; i++)
        {
            var text = $"Roll {1 + i}: ";

            for (var j = 0; j < result[i].Count; j++)
                text += (text.EndsWith(": ") ? "" : ", ") + result[i][j];

            textResult += "\n" + text;
        }

        _diceRollerViewModel.Output = textResult.Trim('\n') + "\n-----\n" + _diceRollerViewModel.Output;
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return true;
    }
}