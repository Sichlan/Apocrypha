using System.Globalization;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.WPF.State.Popups;
using Apocrypha.WPF.ViewModels.Popup;

namespace Apocrypha.WPF.Commands.TranslationCommands;

public class TranslateRaceCommand : AsyncCommandBase
{
    private readonly Race _race;
    private readonly IShowGlobalPopupService _showGlobalPopupService;
    private readonly IEnumerable<CultureInfo> _cultureInfos;
    private readonly IDataService<RaceTranslation> _raceTranslationDataService;

    public TranslateRaceCommand(Race race, IShowGlobalPopupService showGlobalPopupService, IEnumerable<CultureInfo> cultureInfos,
        IDataService<RaceTranslation> raceTranslationDataService)
    {
        _race = race;
        _showGlobalPopupService = showGlobalPopupService;
        _cultureInfos = cultureInfos;
        _raceTranslationDataService = raceTranslationDataService;
    }

    protected override async Task ExecuteAsync(object parameter)
    {
        await _showGlobalPopupService.ShowPopup(new RaceTranslationEditorPopupViewModel(_race, _showGlobalPopupService, _cultureInfos,
            _raceTranslationDataService));
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return _race != null;
    }
}