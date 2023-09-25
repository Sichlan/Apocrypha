using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.ViewModels.Navigation.Tools;

public class PoisonCrafterListViewModel : NavigableViewModel
{
    private readonly IDataService<Poison> _poisonDataService;
    private readonly CreatePoisonCrafterViewModel _poisonCrafterViewModelBuilder;
    private ObservableCollection<PoisonCrafterViewModel> _poisonCrafterViewModels;

    public ObservableCollection<PoisonCrafterViewModel> PoisonCrafterViewModels
    {
        get
        {
            return _poisonCrafterViewModels;
        }
        set
        {
            if (Equals(value, _poisonCrafterViewModels))
                return;

            _poisonCrafterViewModels = value;
            OnPropertyChanged();
        }
    }

    public ICommand UpdateListCommand { get; }

    public PoisonCrafterListViewModel(IDataService<Poison> poisonDataService,
        CreatePoisonCrafterViewModel poisonCrafterViewModelBuilder,
        NavigateToPageCommand navigateToPageCommand)
        : base(navigateToPageCommand)
    {
        _poisonDataService = poisonDataService;
        _poisonCrafterViewModelBuilder = poisonCrafterViewModelBuilder;

        UpdateListCommand = new RelayCommand(ExecuteUpdateListCommand, CanExecuteUpdateListCommand);

        InitPoisons();
    }

    private bool CanExecuteUpdateListCommand()
    {
        return true;
    }

    private void ExecuteUpdateListCommand()
    {
        InitPoisons();
    }

    private async void InitPoisons()
    {
        var results = await _poisonDataService.GetAll();
        PoisonCrafterViewModels = new ObservableCollection<PoisonCrafterViewModel>(results.Select(x => _poisonCrafterViewModelBuilder(x)));
    }
}