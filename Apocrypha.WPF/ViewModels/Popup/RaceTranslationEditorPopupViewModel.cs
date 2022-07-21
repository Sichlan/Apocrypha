using System.Windows.Input;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Models.Common.Translation;
using Apocrypha.WPF.Commands.TranslationCommands;
using Apocrypha.WPF.State.PopupService;

namespace Apocrypha.WPF.ViewModels.Popup;

public class RaceTranslationEditorPopupViewModel : BaseViewModel, IPopupViewModel
{
    private readonly Race _race;
    private readonly IShowGlobalPopupService _showGlobalPopupService;
    private readonly TranslationCollection<RaceTranslation> _newTranslationCollection;

    public RaceTranslationEditorPopupViewModel(Race race, IShowGlobalPopupService showGlobalPopupService)
    {
        _race = race;
        _showGlobalPopupService = showGlobalPopupService;
        _newTranslationCollection = _race.Translations.Copy();

        SetCommands();
        UpdateTranslations();
    }

    private void UpdateTranslations()
    {
        OnPropertyChanged(nameof(NewTranslationCollection));
    }

    private void SetCommands()
    {
        CancelCommand = new CancelTranslateObjectCommand(_showGlobalPopupService);
    }

    public ICommand CancelCommand { get; set; }

    public event Action ClosePopup;


    public TranslationCollection<RaceTranslation> NewTranslationCollection
    {
        get
        {
            return _newTranslationCollection;
        }
    }

    public Race Race
    {
        get
        {
            return _race;
        }
    }
}