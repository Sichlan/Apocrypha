using Apocrypha.WPF.State.Navigators;

namespace Apocrypha.WPF.Commands;

public class RenavigateCommand : AsyncCommandBase
{
    private readonly IRenavigator _renavigator;

    public RenavigateCommand(IRenavigator renavigator)
    {
        _renavigator = renavigator;
    }

    protected override Task ExecuteAsync(object parameter)
    {
        _renavigator.Renavigate();

        return Task.CompletedTask;
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return true;
    }
}