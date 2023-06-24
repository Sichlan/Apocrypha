using Apocrypha.WPF.State.Popups;

namespace Apocrypha.WPF.Commands.TranslationCommands;

public class CancelTranslateObjectCommand : AsyncCommandBase
{
    private readonly IShowGlobalPopupService _showGlobalPopupService;

    public CancelTranslateObjectCommand(IShowGlobalPopupService showGlobalPopupService)
    {
        _showGlobalPopupService = showGlobalPopupService;
    }

    protected override async Task ExecuteAsync(object parameter)
    {
        //TODO: Ask user if cancellation is intended
        await _showGlobalPopupService.ClosePopup();
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return true;
    }
}