using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.State.Races;
using Apocrypha.WPF.ViewModels;

namespace Apocrypha.WPF.Commands.RaceCommands;

public class EditRaceCommand : AsyncCommandBase
{
    private readonly IRaceStore _raceStore;
    private readonly IRenavigator _editRaceRenavigator;

    public EditRaceCommand(IRaceStore raceStore, IRenavigator editRaceRenavigator)
    {
        _raceStore = raceStore;
        _editRaceRenavigator = editRaceRenavigator;
    }

    protected override Task ExecuteAsync(object parameter)
    {
        if (parameter is RaceListItemViewModel raceListItemViewModel)
        {
            _raceStore.ActiveRace = raceListItemViewModel.Race;
            _editRaceRenavigator.Renavigate();
        }

        return Task.CompletedTask;
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return parameter is RaceListItemViewModel;
    }
}