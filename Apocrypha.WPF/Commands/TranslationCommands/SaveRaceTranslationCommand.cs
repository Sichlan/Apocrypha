using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Common.Translation;
using Apocrypha.WPF.State.Popups;

namespace Apocrypha.WPF.Commands.TranslationCommands;

public class SaveRaceTranslationCommand : AsyncCommandBase
{
    private readonly Race _race;
    private readonly TranslationCollection<RaceTranslation> _newTranslationCollection;
    private readonly IShowGlobalPopupService _showGlobalPopupService;

    public SaveRaceTranslationCommand(Race race, TranslationCollection<RaceTranslation> newTranslationCollection,
        IShowGlobalPopupService showGlobalPopupService)
    {
        _race = race;
        _newTranslationCollection = newTranslationCollection;
        _showGlobalPopupService = showGlobalPopupService;
    }

    protected override async Task ExecuteAsync(object parameter)
    {
        _race.Translations = _newTranslationCollection;
        await _showGlobalPopupService.ClosePopup();
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return true;
    }
}