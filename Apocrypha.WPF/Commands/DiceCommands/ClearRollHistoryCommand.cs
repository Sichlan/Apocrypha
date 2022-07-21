using Apocrypha.WPF.ViewModels;

namespace Apocrypha.WPF.Commands.DiceCommands;

public class ClearRollHistoryCommand : AsyncCommandBase
{
    private readonly DiceRollerViewModel _diceRollerViewModel;

    public ClearRollHistoryCommand(DiceRollerViewModel diceRollerViewModel)
    {
        _diceRollerViewModel = diceRollerViewModel;
    }

    protected override Task ExecuteAsync(object parameter)
    {
        _diceRollerViewModel.Output = "";

        return Task.CompletedTask;
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return true;
    }
}