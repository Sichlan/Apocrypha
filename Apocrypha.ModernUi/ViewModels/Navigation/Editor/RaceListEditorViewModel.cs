using System.Collections.ObjectModel;
using System.Linq;
using Apocrypha.CommonObject.Models;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Resources.Localization;

namespace Apocrypha.ModernUi.ViewModels.Navigation.Editor;

public class RaceListEditorViewModel : NavigableViewModel
{
    public override string ViewModelTitle { get; } = Localization.RaceListViewModel;

    public ObservableCollection<RaceEditorViewModel> RaceEditorViewModels { get; set; }

    private readonly IDataService<Race> _raceDataService;
    private readonly CreateRaceEditorViewModel _raceEditorViewModelBuilder;

    public RaceListEditorViewModel(IDataService<Race> raceDataService, NavigateToPageCommand navigateToPageCommand,
        CreateRaceEditorViewModel raceEditorViewModelBuilder)
        : base(navigateToPageCommand)
    {
        _raceDataService = raceDataService;
        _raceEditorViewModelBuilder = raceEditorViewModelBuilder;

        InitRaces();
    }

    private async void InitRaces()
    {
        var results = await _raceDataService.GetAll();
        RaceEditorViewModels = new ObservableCollection<RaceEditorViewModel>(results.Select(x => _raceEditorViewModelBuilder(x)));
    }
}