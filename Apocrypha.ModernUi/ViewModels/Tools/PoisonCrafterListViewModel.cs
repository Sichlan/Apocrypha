﻿using System.Collections.ObjectModel;
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
using Apocrypha.ModernUi.ViewModels.Navigation;
using CommunityToolkit.Mvvm.Input;

namespace Apocrypha.ModernUi.ViewModels.Tools;

public class PoisonCrafterListViewModel : NavigableViewModel
{
    private readonly IDataService<Poison> _poisonDataService;
    private readonly IUserStore _userStore;
    private readonly IPoisonRandomizerService _poisonRandomizerService;

    private readonly CreatePoisonCrafterViewModel _poisonCrafterViewModelBuilder;
    private ObservableCollection<PoisonCrafterViewModel> _poisonCrafterViewModels;
    private bool _isLoading;

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
        }
    }

    public ICommand UpdateListCommand { get; }
    public IRelayCommand DeletePoisonCommand { get; }
    public ICommand GenerateRandomPoisonCommand { get; }

    public PoisonCrafterListViewModel(IDataService<Poison> poisonDataService,
        CreatePoisonCrafterViewModel poisonCrafterViewModelBuilder,
        NavigateToPageCommand navigateToPageCommand, IUserStore userStore,
        IPoisonRandomizerService poisonRandomizerService)
        : base(navigateToPageCommand)
    {
        _poisonDataService = poisonDataService;
        _poisonCrafterViewModelBuilder = poisonCrafterViewModelBuilder;
        _userStore = userStore;
        _poisonRandomizerService = poisonRandomizerService;

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