using Apocrypha.CommonObject.Models;

namespace Apocrypha.WPF.ViewModels;

public class RaceListItemViewModel : BaseViewModel
{
    private Race _race;

    public RaceListItemViewModel(Race race)
    {
        Race = race;
    }

    public Race Race
    {
        get
        {
            return _race;
        }
        set
        {
            _race = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(RuleBook));
        }
    }

    public RuleBook RuleBook
    {
        get
        {
            return Race.RuleBook;
        }
    }
}