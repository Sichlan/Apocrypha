using Apocrypha.CommonObject.Models;
using Apocrypha.WPF.State.PopupService;
using Apocrypha.WPF.ViewModels.Popup;

namespace Apocrypha.WPF.Commands.TranslationCommands;

public class TranslateRaceCommand : AsyncCommandBase
{
    private readonly Race _race;
    private readonly IShowGlobalPopupService _showGlobalPopupService;

    public TranslateRaceCommand(Race race, IShowGlobalPopupService showGlobalPopupService)
    {
        _race = race;
        _showGlobalPopupService = showGlobalPopupService;
    }

    protected override async Task ExecuteAsync(object parameter)
    {
        await _showGlobalPopupService.ShowPopup(new RaceTranslationEditorPopupViewModel(_race, _showGlobalPopupService));
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return _race != null;
    }
}