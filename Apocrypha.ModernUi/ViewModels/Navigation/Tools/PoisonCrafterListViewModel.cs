using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
    private bool _isLoading;

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

    public bool IsLoading
    {
        get
        {
            return _isLoading;
        }
        set
        {
            if (value == _isLoading)
                return;

            _isLoading = value;
            OnPropertyChanged();
        }
    }

    public ICommand UpdateListCommand { get; }
    public ICommand DeletePoisonCommand { get; }

    public PoisonCrafterListViewModel(IDataService<Poison> poisonDataService,
        CreatePoisonCrafterViewModel poisonCrafterViewModelBuilder,
        NavigateToPageCommand navigateToPageCommand)
        : base(navigateToPageCommand)
    {
        _poisonDataService = poisonDataService;
        _poisonCrafterViewModelBuilder = poisonCrafterViewModelBuilder;

        UpdateListCommand = new RelayCommand(ExecuteUpdateListCommand, CanExecuteUpdateListCommand);
        DeletePoisonCommand = new RelayCommand<PoisonCrafterViewModel>(ExecuteDeletePoisonCommand, CanExecuteDeletePoisonCommand);
    }

    private bool CanExecuteDeletePoisonCommand(PoisonCrafterViewModel obj)
    {
        return true;
    }

    private void ExecuteDeletePoisonCommand(PoisonCrafterViewModel obj)
    {
        Task.Run(async () =>
        {
            IsLoading = true;

            await _poisonDataService.Delete(obj.Id);
            InitPoisons();

            IsLoading = false;
        });
    }

    private bool CanExecuteUpdateListCommand()
    {
        return true;
    }

    private void ExecuteUpdateListCommand()
    {
        InitPoisons();
    }

    private void InitPoisons()
    {
        Task.Run(async () =>
        {
            IsLoading = true;

            var results = await _poisonDataService.GetAll();
            PoisonCrafterViewModels = new ObservableCollection<PoisonCrafterViewModel>(results.Select(x => _poisonCrafterViewModelBuilder(x)));

            IsLoading = false;
        });
    }

    public override void OnNavigateTo()
    {
        InitPoisons();
    }
}