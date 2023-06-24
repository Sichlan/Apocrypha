using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.State.Races;

namespace Apocrypha.WPF.Commands.RaceCommands;

public class CancelEditRaceCommand : AsyncCommandBase
{
    private readonly IRaceStore _raceStore;
    private readonly IRenavigator _raceListRenavigator;

    public CancelEditRaceCommand(IRaceStore raceStore, IRenavigator raceListRenavigator)
    {
        _raceStore = raceStore;
        _raceListRenavigator = raceListRenavigator;
    }

    protected override Task ExecuteAsync(object parameter)
    {
        _raceStore.ActiveRace = null;
        _raceListRenavigator.Renavigate();

        return Task.CompletedTask;
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return true;
    }
}