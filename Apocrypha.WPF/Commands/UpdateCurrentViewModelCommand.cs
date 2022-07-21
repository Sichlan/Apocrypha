using Apocrypha.WPF.State;
using Apocrypha.WPF.State.Navigators;
using Apocrypha.WPF.ViewModels;
using Apocrypha.WPF.ViewModels.Factories;

namespace Apocrypha.WPF.Commands;

public class UpdateCurrentViewModelCommand : AsyncCommandBase
{
    private readonly INavigator _navigator;
    private readonly IApocryphaViewModelFactory _viewModelFactory;
    private readonly MainViewModel _mainViewModel;

    public UpdateCurrentViewModelCommand(INavigator navigator, IApocryphaViewModelFactory viewModelFactory, MainViewModel mainViewModel)
    {
        _navigator = navigator;
        _viewModelFactory = viewModelFactory;
        _mainViewModel = mainViewModel;
    }

    protected override Task ExecuteAsync(object parameter)
    {
        if (parameter is ViewType type)
        {
            _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(type);
            _mainViewModel.IsMenuExpanded = false;
        }

        return Task.CompletedTask;
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return true;
    }
}