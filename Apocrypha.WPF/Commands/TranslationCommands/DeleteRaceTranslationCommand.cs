using Apocrypha.CommonObject.Models;

namespace Apocrypha.WPF.Commands.TranslationCommands;

public class DeleteRaceTranslationCommand : AsyncCommandBase
{
    private readonly ICollection<RaceTranslation> _raceTranslations;
    private readonly ICollection<int> _raceTranslationIdsToDelete;

    public DeleteRaceTranslationCommand(ICollection<RaceTranslation> raceTranslations, ICollection<int> raceTranslationIdsToDelete)
    {
        _raceTranslations = raceTranslations;
        _raceTranslationIdsToDelete = raceTranslationIdsToDelete;
    }

    protected override async Task ExecuteAsync(object parameter)
    {
        if (parameter is RaceTranslation raceTranslation
            && _raceTranslations.Contains(raceTranslation))
        {
            _raceTranslations.Remove(raceTranslation);

            if (raceTranslation.Id > 0)
                _raceTranslationIdsToDelete.Add(raceTranslation.Id);
        }
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return true;
    }
}