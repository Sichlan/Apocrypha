using Wpf.Ui.Mvvm.Contracts;

namespace Apocrypha.WPF.Commands;

public class RenavigateCommand : AsyncCommandBase
{
    private readonly INavigationService _navigationService;
    private readonly Type _viewType;

    public RenavigateCommand(INavigationService navigationService, Type viewType)
    {
        _navigationService = navigationService;
        _viewType = viewType;
    }

    protected override Task ExecuteAsync(object parameter)
    {
        _navigationService.Navigate(_viewType);

        return Task.CompletedTask;
    }

    protected override bool CanExecuteAsync(object parameter)
    {
        return true;
    }
}