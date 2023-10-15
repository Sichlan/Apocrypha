using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Apocrypha.CommonObject.Models.Poisons;
using Apocrypha.CommonObject.Services;
using Apocrypha.ModernUi.Helpers;
using Apocrypha.ModernUi.Helpers.Commands.Navigation;
using Apocrypha.ModernUi.Resources.Localization;
using Apocrypha.ModernUi.Services.Randomizer;
using Apocrypha.ModernUi.Services.State.Users;
using Apocrypha.ModernUi.Services.UserInformationService;
using Apocrypha.ModernUi.ViewModels.Navigation;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.ViewModels.Tools;

public class PoisonCrafterListViewModel : NavigableViewModel
{
    private readonly IDataService<Poison> _poisonDataService;
    private readonly IUserStore _userStore;
    private readonly IPoisonRandomizerService _poisonRandomizerService;
    private readonly IUserInformationMessageService _userInformationMessageService;

    private readonly CreatePoisonCrafterViewModel _poisonCrafterViewModelBuilder;
    private ObservableCollection<PoisonCrafterViewModel> _poisonCrafterViewModels;
    private bool _isLoading;

    /// <inheritdoc />
    public override string ViewModelTitle => Localization.PoisonCrafterListViewModelTitle;

    public ObservableCollection<PoisonCrafterViewModel> PoisonCrafterViewModels
    {
        get => _poisonCrafterViewModels;
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
        get => _isLoading;
        set
        {
            if (value == _isLoading)
                return;

            _isLoading = value;
            OnPropertyChanged();
            DispatcherHelper.RunOnMainThread(() => UpdateListCommand.NotifyCanExecuteChanged());
        }
    }

    public IRelayCommand UpdateListCommand { get; }
    public IRelayCommand DeletePoisonCommand { get; }
    public ICommand GenerateRandomPoisonCommand { get; }

    public PoisonCrafterListViewModel(IDataService<Poison> poisonDataService,
        CreatePoisonCrafterViewModel poisonCrafterViewModelBuilder,
        NavigateToPageCommand navigateToPageCommand, IUserStore userStore,
        IPoisonRandomizerService poisonRandomizerService, IUserInformationMessageService userInformationMessageService)
        : base(navigateToPageCommand)
    {
        _poisonDataService = poisonDataService;
        _poisonCrafterViewModelBuilder = poisonCrafterViewModelBuilder;
        _userStore = userStore;
        _poisonRandomizerService = poisonRandomizerService;
        _userInformationMessageService = userInformationMessageService;

        UpdateListCommand = new RelayCommand(ExecuteUpdateListCommand, CanExecuteUpdateListCommand);
        DeletePoisonCommand = new RelayCommand<PoisonCrafterViewModel>(ExecuteDeletePoisonCommand, CanExecuteDeletePoisonCommand);
        GenerateRandomPoisonCommand = new RelayCommand(ExecuteGenerateRandomPoisonCommand, CanExecuteGenerateRandomPoisonCommand);

        _userStore.StateChange += () =>
        {
            DispatcherHelper.RunOnMainThread(() =>
            {
                DeletePoisonCommand.NotifyCanExecuteChanged();
            });
        };
    }

    private bool CanExecuteGenerateRandomPoisonCommand()
    {
        return true;
    }

    private async void ExecuteGenerateRandomPoisonCommand()
    {
        var poison = await _poisonRandomizerService.GenerateRandomPoison();
        var viewModel = _poisonCrafterViewModelBuilder(poison);
        NavigateToPageCommand.Execute(viewModel);
    }

    private bool CanExecuteDeletePoisonCommand(PoisonCrafterViewModel obj)
    {
        return obj.CreatorId == null || (_userStore.CurrentUser != null && _userStore.CurrentUser.Id == obj.CreatorId);
    }

    private void ExecuteDeletePoisonCommand(PoisonCrafterViewModel obj)
    {
        Task.Run(async () =>
        {
            try
            {
                IsLoading = true;

                await _poisonDataService.Delete(obj.Id);
                InitPoisons();
            }
            catch (Exception e)
            {
                //TODO: real exception message
                _userInformationMessageService.AddDisplayMessage(e.Message, InformationType.Error, null, e.ToString());
            }
            finally
            {
                IsLoading = false;
            }
        });
    }

    private bool CanExecuteUpdateListCommand()
    {
        return !IsLoading;
    }

    private void ExecuteUpdateListCommand()
    {
        InitPoisons();
    }

    private async void InitPoisons()
    {
        await Task.Run(async () =>
        {
            try
            {
                IsLoading = true;

                var results = await _poisonDataService.GetAll();
                PoisonCrafterViewModels = new ObservableCollection<PoisonCrafterViewModel>(results.Select(x => _poisonCrafterViewModelBuilder(x)));
            }
            catch (Exception e)
            {
                //TODO: real exception message
                _userInformationMessageService.AddDisplayMessage(e.Message, InformationType.Error, null, e.ToString());
            }
            finally
            {
                IsLoading = false;
            }
        });
    }

    /// <inheritdoc />
    public override void OnNavigateTo()
    {
        InitPoisons();
    }
}