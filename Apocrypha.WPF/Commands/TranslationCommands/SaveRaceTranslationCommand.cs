using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Common.Translation;
using Apocrypha.CommonObject.Services;
using Apocrypha.WPF.State.Popups;

namespace Apocrypha.WPF.Commands.TranslationCommands;

public class SaveRaceTranslationCommand : AsyncCommandBase
{
    private readonly Race _race;
    private readonly ICollection<RaceTranslation> _newTranslationCollection;
    private readonly IShowGlobalPopupService _showGlobalPopupService;
    private readonly IDataService<RaceTranslation> _raceTranslationDataService;
    private readonly IEnumerable<int> _raceTranslationIdsToDelete;

    public SaveRaceTranslationCommand(Race race,
        ICollection<RaceTranslation> newTranslationCollection,
        IShowGlobalPopupService showGlobalPopupService,
        IDataService<RaceTranslation> raceTranslationDataService,
        IEnumerable<int> raceTranslationIdsToDelete)
    {
        _race = race;
        _newTranslationCollection = newTranslationCollection;
        _showGlobalPopupService = showGlobalPopupService;
        _raceTranslationDataService = raceTranslationDataService;
        _raceTranslationIdsToDelete = raceTranslationIdsToDelete;
    }

    protected override async Task ExecuteAsync(object parameter)
    {
        _race.Translations = _newTranslationCollection.ToTranslationCollection();

        foreach (var id in _raceTranslationIdsToDelete)
        {
            await _raceTranslationDataService.Delete(id);
        }

        await _showGlobalPopupService.ClosePopup();
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return true;
    }
}